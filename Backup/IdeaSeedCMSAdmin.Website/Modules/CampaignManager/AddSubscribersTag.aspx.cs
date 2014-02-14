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
using CampaignManager.Core.Domain;
using CMData = CampaignManager.Data.Repositories;
using CampaignManager.Presentation;
using IdeaSeed.Core;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMS.Core.Security;
using IdeaSeedCMSAdmin.Web.Utils;
using System.Drawing;
using NHibernate.Exceptions;
using Iesi.Collections.Generic;

namespace IdeaSeedCMSAdmin.Website.Modules.CampaignManager
{
    public partial class AddSubscribersTag : AdminBasePage
    {
        #region Properties
        public int CurrentTagID
        {
            get
            {
                int result;
                if (int.TryParse(HttpContext.Current.Request.Url.Segments[3].Replace("/",""), out result))
                {
                    return result;
                }
                return 0;
            }
        }

        public bool IsAdd
        {
            get
            {
                if (HttpContext.Current.Request.Url.Segments[4].Contains("Add"))
                {
                    return true;
                }
                return false;
            }
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            RadAjaxManager ram = (RadAjaxManager)this.Master.FindControl("RadAjaxManager1");
            RadAjaxLoadingPanel alp = (RadAjaxLoadingPanel)this.Master.FindControl("AjaxLoadingPanel1");
            ram.AjaxSettings.AddAjaxSetting(rgSubscribers, rgSubscribers, alp);
            ram.AjaxSettings.AddAjaxSetting(btnSave, rgSubscribers, alp);
            ram.AjaxSettings.AddAjaxSetting(btnSave, divFilters);
            ram.AjaxSettings.AddAjaxSetting(lbSearchSubscribers, rgSubscribers, alp);
            if (!IsPostBack)
            {
                if (CurrentTagID > 0)
                {
                    SetTitle();
                    LoadSubscribers(true, IsAdd, false);
                }
            }
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }

        protected void ToggleSelectedState(object o, EventArgs e)
        {
            if ((o as IdeaSeed.Web.UI.CheckBox).Checked)
            {
                foreach (GridDataItem dataItem in rgSubscribers.MasterTableView.Items)
                {
                    (dataItem.FindControl("cbSelectRow") as IdeaSeed.Web.UI.CheckBox).Checked = true;
                    //dataItem.Selected = true;
                }
            }
            else
            {
                foreach (GridDataItem dataItem in rgSubscribers.MasterTableView.Items)
                {
                    (dataItem.FindControl("cbSelectRow") as IdeaSeed.Web.UI.CheckBox).Checked = false;
                    dataItem.Selected = false;
                }
            }
            rgSubscribers.PagerStyle.Position = GridPagerPosition.Bottom;
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadSubscribers(false, IsAdd, false);
        }

        protected void ApplyClicked(object o, EventArgs e)
        {
            foreach (GridDataItem row in rgSubscribers.MasterTableView.Items)
            {
                var cb = row.FindControl("cbSelectRow") as IdeaSeed.Web.UI.CheckBox;
                if (cb.Checked)
                {
                    var subscriberTags = new SubscriberCampaignTag();
                    subscriberTags.CampaignTagID = CurrentTagID;
                    subscriberTags.SubscriberID = Convert.ToInt32(cb.Attributes["subscriberID"]);
                    if (IsAdd)
                    {
                        new CMData.SubscriberCampaignTagRepository().Save(subscriberTags);
                    }
                    else
                    {
                        var subTags = new CMData.SubscriberCampaignTagRepository().GetByCampaignTagIDSubscriberID(CurrentTagID, Convert.ToInt32(cb.Attributes["subscriberID"]));
                        new CMData.SubscriberCampaignTagRepository().Delete(subTags[0]);
                    }
                }
            }
            ddlSearchColumn.SelectedIndex = 0;
            tbEndDate.DateInput.Text = "";
            tbSearch.Text = "";
            tbStartDate.DateInput.Text = "";
            LoadSubscribers(true, IsAdd, false);
        }

        protected void SearchSubscribersClicked(object o, EventArgs e)
        {

            LoadSubscribers(true, IsAdd, true);
        } 

        #endregion

        #region Methods

        private void LoadSubscribers(bool dataBind, bool isadd, bool search)
        {
            var list = new List<Subscriber>();
            var result = new List<Subscriber>().AsEnumerable();
            if (isadd)
            {
                list = new CMData.SubscriberRepository().GetSubscribersNotInCampaignTagGroup(CurrentTagID).OrderBy(s => s.LastName).ToList<Subscriber>();
                if (search)
                {
                    string firstname = "";
                    string lastname = "";
                    string email = "";
                    if (ddlSearchColumn.SelectedIndex > 0)
                    {
                        switch (ddlSearchColumn.SelectedValue)
                        {
                            case "Email":
                                email = tbSearch.Text;
                                result = from l in list
                                         where l.Email.ToLower().Contains(email.ToLower())
                                         select l;
                                break;
                            case "FirstName":
                                firstname = tbSearch.Text;
                                result = from l in list
                                         where l.FirstName.ToLower().Contains(firstname.ToLower())
                                         select l;
                                break;
                            case "LastName":
                                lastname = tbSearch.Text;
                                result = from l in list
                                         where l.LastName.ToLower().Contains(lastname.ToLower())
                                         select l;
                                break;
                        }
                        rgSubscribers.DataSource = result;
                    }
                    else
                    {
                        rgSubscribers.DataSource = list;
                    }
                }
                else
                {
                    rgSubscribers.DataSource = list;
                }
                if (dataBind)
                {
                    rgSubscribers.DataBind();
                }
            }
            else
            {
                list = new CMData.SubscriberRepository().GetSubscribersInCampaignTagGroup(CurrentTagID).OrderBy(s => s.LastName).ToList<Subscriber>();
                if (search)
                {
                    string firstname = "";
                    string lastname = "";
                    string email = "";
                    switch (ddlSearchColumn.SelectedValue)
                    {
                        case "Email":
                            email = tbSearch.Text;
                            result = from l in list
                                     where l.Email == email
                                     select l;
                            break;
                        case "FirstName":
                            firstname = tbSearch.Text;
                            result = from l in list
                                     where l.FirstName == firstname
                                     select l;
                            break;
                        case "LastName":
                            lastname = tbSearch.Text;
                            result = from l in list
                                     where l.LastName == lastname
                                     select l;
                            break;
                    }
                    rgSubscribers.DataSource = result;
                }
                else
                {
                    rgSubscribers.DataSource = list;
                }
                //rgSubscribers.DataSource = new CMData.SubscriberRepository().GetSubscribersInCampaignTagGroup(CurrentTagID).OrderBy(s => s.LastName);
                if (dataBind)
                {
                    rgSubscribers.DataBind();
                }
            }
        }

        private void SetTitle()
        {
            if (IsAdd)
            {
                lblTag.Text = "Add Tag: <font color='green'>" + new CMData.CampaignTagRepository().GetByID(CurrentTagID, false).Tag + "</font> To Selected Subscribers.";
            }
            else
            {
                lblTag.Text = "Delete Tag: <font color='green'>" + new CMData.CampaignTagRepository().GetByID(CurrentTagID, false).Tag + "</font> From Selected Subscribers.";
            }
        }
        #endregion
    }
}