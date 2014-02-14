using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using IdeaSeed.Web.UI;
using System.Data;
using Telerik.Web.UI;
using System.Configuration;
using System.IO;
using CampaignManager.Core;
using CMCore = CampaignManager.Core.Domain;
using CMData = CampaignManager.Data.Repositories;
using CMPresentation = CampaignManager.Presentation;
using IdeaSeed.Core;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMS.Core.Security;
using IdeaSeedCMSAdmin.Web.Utils;
using System.Drawing;

namespace IdeaSeedCMSAdmin.Website.Modules.CampaignManager
{
    public partial class NewCampaign : AdminBasePage
    {
        #region Properties
        private IList<CMCore.Subscriber> _recipients = new List<CMCore.Subscriber>();
        public IList<CMCore.Subscriber> Recipients
        {
            get
            {
                if (Session["CampaignRecipients"] != null)
                {
                    return (IList<CMCore.Subscriber>)Session["CampaignRecipients"];
                }
                return _recipients;
            }
            set
            {
                _recipients = value;
                Session["CampaignRecipients"] = _recipients;
            }
        }

        private List<string> TagControlsInUse
        {
            get
            {
                if (Session["TagControlsInUse"] != null)
                {
                    return (List<string>)Session["TagControlsInUse"];
                }
                return null;
            }

            set
            {
                Session["TagControlsInUse"] = value;
            }
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            //RadAjaxManager ram = (RadAjaxManager)this.Master.FindControl("RadAjaxManager1");
            //RadAjaxLoadingPanel alp = (RadAjaxLoadingPanel)this.Master.FindControl("AjaxLoadingPanel1");
            //ram.AjaxSettings.AddAjaxSetting(lbRecipients, divBody, alp);
            //ram.AjaxSettings.AddAjaxSetting(lbRecipients, divSubscribers);
            //ram.AjaxSettings.AddAjaxSetting(btnSend, divBody, alp);
            if (!IsPostBack)
            {
                SetImagesPath(reCampaignContent);
                divSentMessages.Visible = false;
                LoadTags();
                LoadTemplate();
                lbRecipients.Text = "0 recipients selected";
            }
        }

        protected void TagCheckChanged(object o, EventArgs e)
        {
            var addRecipients = new List<int>();
            var removeRecipients = new List<int>();
            var tempRecipients = new List<CMCore.Subscriber>();
            foreach (DataListItem item in dlTags.Items)
            {
                var cb = item.FindControl("cbTag") as IdeaSeed.Web.UI.CheckBox;
                if (cb.Checked)
                {
                    addRecipients.Add(Convert.ToInt32(cb.Attributes["tagID"]));
                }
                else
                {
                    removeRecipients.Add(Convert.ToInt32(cb.Attributes["tagID"]));
                }
            }

            //var cb = item.FindControl("cbTag") as IdeaSeed.Web.UI.CheckBox;
            if (removeRecipients != null && removeRecipients.Count > 0)
                foreach (var removeTag in removeRecipients)
                {
                    foreach (var r in new CMData.SubscriberRepository().GetSubscribersInCampaignTagGroup(removeTag))
                    {
                        if (tempRecipients != null && tempRecipients.Contains(r))
                        {
                            tempRecipients.Remove(r);
                        }
                    }
                }

            if (addRecipients != null && addRecipients.Count > 0)
            {
                foreach (var addTag in addRecipients)
                {
                    foreach (var r in new CMData.SubscriberRepository().GetSubscribersInCampaignTagGroup(addTag))
                    {
                        if (tempRecipients == null)
                        {
                            tempRecipients.Add(r);
                        }
                        else
                        {
                            if (!tempRecipients.Contains(r))
                            {
                                tempRecipients.Add(r);
                            }
                        }
                    }
                }
            }
            Recipients = tempRecipients;
            lbRecipients.Text = Recipients.Count.ToString() + " recipients selected";
        }

        protected void SendClicked(object o, EventArgs e)
        {
            if (CMPresentation.CampaignHelper.SelectedTemplateID > 0)
            {
                var campaign = new CMCore.Campaign();
                campaign.CampaignName = tbTemplateName.Text;
                campaign.CampaignTemplateID = CMPresentation.CampaignHelper.SelectedTemplateID;
                if (!string.IsNullOrEmpty(ddlCoupon.SelectedValue))
                {
                    CMPresentation.CampaignHelper.SelectedCouponID = Convert.ToInt16(ddlCoupon.SelectedValue);
                }
                campaign.DateTimeSent = DateTime.Now;
                campaign.Description = tbDescription.Text;
                campaign.EmailBody = reCampaignContent.Content;
                campaign.EmailFrom = ConfigurationManager.AppSettings["NEWSLETTERFROMEMAILADDRESS"];
                campaign.EmailSubject = tbSubject.Text;
                campaign.SentBy = SecurityContextManager.Current.CurrentUser.ID;
                campaign.TotalRecipients = 0;

                var manager = new CMPresentation.CampaignManager(campaign);
                campaign = manager.SaveCampaign(campaign);
                manager.BuildLinks(campaign);

                var subscribers = Recipients;
                manager.SendCampaign(campaign, (List<CMCore.Subscriber>)subscribers, SecurityContextManager.Current.CurrentUser.ID, false);
                divSentMessages.Visible = true;
                btnSend.Enabled = false;
            }
        }

        #endregion

        #region Methods

        private void LoadTags()
        {
            dlTags.DataSource = new CMData.CampaignTagRepository().GetAll();
            dlTags.DataBind();
        }

        private void LoadTemplate()
        {
            if (CMPresentation.CampaignHelper.SelectedTemplateID > 0)
            {
                var template = new CMData.CampaignTemplateRepository().GetByID(CMPresentation.CampaignHelper.SelectedTemplateID, false);
                if (template != null)
                {
                    tbDescription.Text = template.Description;
                    tbSubject.Text = template.EmailSubject;
                    tbTemplateName.Text = template.TemplateName;
                    reCampaignContent.Content = template.EmailBody;
                }
            }
        }

        #endregion
    }
}