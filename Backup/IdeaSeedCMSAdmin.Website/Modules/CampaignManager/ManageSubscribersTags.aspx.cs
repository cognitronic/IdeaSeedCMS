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
using CampaignManager.Presentation;
using IdeaSeed.Core;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMS.Core.Security;
using IdeaSeedCMSAdmin.Web.Utils;
using System.Drawing;

namespace IdeaSeedCMSAdmin.Website.Modules.CampaignManager
{
    public partial class ManageSubscribersTags : AdminBasePage
    {
        #region Properties

        public bool IsAdd
        {
            get
            {
                if (Session["IsAdd"] != null)
                {
                    return (bool)Session["IsAdd"];
                }
                return false;
            }
        }

        public IList<CMCore.Subscriber> SelectedSubscribers
        {
            get
            {
                if (Session["SubscribersAddTags"] != null)
                {
                    return (IList<CMCore.Subscriber>)Session["SubscribersAddTags"];
                }
                return null;
            }
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            RadAjaxManager ram = (RadAjaxManager)this.Master.FindControl("RadAjaxManager1");
            RadAjaxLoadingPanel alp = (RadAjaxLoadingPanel)this.Master.FindControl("AjaxLoadingPanel1");
            ram.AjaxSettings.AddAjaxSetting(rgTags, rgTags, alp);
            ram.AjaxSettings.AddAjaxSetting(btnSave, rgTags, alp);
            ram.AjaxSettings.AddAjaxSetting(btnSave, lblMessage);
            if (!IsPostBack)
            {
                SetTitle();
                LoadSubscribers(true, IsAdd);
                lblMessage.Visible = false;
            }
        }

        protected void ToggleSelectedState(object o, EventArgs e)
        {
            if ((o as IdeaSeed.Web.UI.CheckBox).Checked)
            {
                foreach (GridDataItem dataItem in rgTags.MasterTableView.Items)
                {
                    (dataItem.FindControl("cbSelectRow") as IdeaSeed.Web.UI.CheckBox).Checked = true;
                    //dataItem.Selected = true;
                }
            }
            else
            {
                foreach (GridDataItem dataItem in rgTags.MasterTableView.Items)
                {
                    (dataItem.FindControl("cbSelectRow") as IdeaSeed.Web.UI.CheckBox).Checked = false;
                    dataItem.Selected = false;
                }
            }
            rgTags.PagerStyle.Position = GridPagerPosition.Bottom;
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadSubscribers(false, IsAdd);
        }

        protected void ApplyClicked(object o, EventArgs e)
        {
            if (SelectedSubscribers != null)
            {
                int totalUpdated = 0;
                //Iterate through selected subscribers
                foreach (var subscriber in SelectedSubscribers)
                {
                    //iterate through selected tags
                    foreach (GridDataItem row in rgTags.MasterTableView.Items)
                    {
                        var cb = row.FindControl("cbSelectRow") as IdeaSeed.Web.UI.CheckBox;
                        if (cb.Checked)
                        {
                            int campiagnTagID = Convert.ToInt32(cb.Attributes["campaignTagID"]);
                            if (IsAdd)
                            {
                                if (!CampaignManagerUtils.SubscriberHasTag(subscriber.ID, campiagnTagID))
                                {
                                    var subscriberTags = new CMCore.SubscriberCampaignTag();
                                    subscriberTags.CampaignTagID = campiagnTagID;
                                    subscriberTags.SubscriberID = subscriber.ID;

                                    new CMData.SubscriberCampaignTagRepository().Save(subscriberTags);
                                }
                            }
                            else
                            {
                                if (CampaignManagerUtils.SubscriberHasTag(subscriber.ID, campiagnTagID))
                                {
                                    var subTags = new CMData.SubscriberCampaignTagRepository().GetByCampaignTagIDSubscriberID(campiagnTagID, subscriber.ID);
                                    new CMData.SubscriberCampaignTagRepository().Delete(subTags[0]);
                                }
                            }
                            totalUpdated++;
                        }
                    }
                }
                lblMessage.Visible = true;
                lblMessage.Text = "<b><font color='green'>" + totalUpdated.ToString() + "</font> tags where updated on <font color='red'>" + SelectedSubscribers.Count.ToString() + "</font> subscriber(s).</b>";
            }
        }

        #endregion

        #region Methods

        private void LoadSubscribers(bool dataBind, bool isadd)
        {
            rgTags.DataSource = new CMData.CampaignTagRepository().GetAll().OrderBy(t => t.Tag);
            if (dataBind)
            {
                rgTags.DataBind();
            }
        }

        private void SetTitle()
        {
            string count = "0";
            if (SelectedSubscribers != null)
            {
                count = SelectedSubscribers.Count.ToString();
            }

            if (IsAdd)
            {
                lblSubscribers.Text = "Add Tags to <font color='green'>" + count + "</font> selected subscribers.";
            }
            else
            {
                lblSubscribers.Text = "Delete Tags from <font color='green'>" + count + "</font> subscriber(s).";
            }
        }
        #endregion
    }
}