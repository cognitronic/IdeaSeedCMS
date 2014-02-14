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
    public partial class Tags : AdminBasePage
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            RadAjaxManager ram = (RadAjaxManager)this.Master.FindControl("RadAjaxManager1");
            RadAjaxLoadingPanel alp = (RadAjaxLoadingPanel)this.Master.FindControl("AjaxLoadingPanel1");
            ram.AjaxSettings.AddAjaxSetting(rgTags, rgTags);
            if (!IsPostBack)
            {
                LoadTags(true);
            }
        }

        protected void AddUserClicked(object o, EventArgs e)
        {
            Response.Redirect("/Campaign-Manager/Add-Subscribers/" + ((IdeaSeed.Web.UI.LinkButton)o).Attributes["tagid"] + "/Add");
        }

        protected void RemoveUserClicked(object o, EventArgs e)
        {
            Response.Redirect("/Campaign-Manager/Add-Subscribers/" + ((IdeaSeed.Web.UI.LinkButton)o).Attributes["tagid"] + "/Remove");
        }

        protected void TagItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                e.Canceled = true;
                var i = new CampaignTag();
                i.Tag = "";
                i.ID = 0;
                i.IsPublic = false;
                e.Item.OwnerTableView.InsertItem(i);
            }

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var tag = new CampaignTag();
                tag.Tag = (e.Item.FindControl("tbTag") as IdeaSeed.Web.UI.TextBox).Text;
                tag.IsPublic = (e.Item.FindControl("cbIsPublic") as IdeaSeed.Web.UI.CheckBox).Checked;
                new CMData.CampaignTagRepository().Save(tag);
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                var tag = new CMData.CampaignTagRepository().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"], false);
                tag.Tag = (e.Item.FindControl("tbTag") as IdeaSeed.Web.UI.TextBox).Text;
                tag.IsPublic = (e.Item.FindControl("cbIsPublic") as IdeaSeed.Web.UI.CheckBox).Checked;
                new CMData.CampaignTagRepository().SaveOrUpdate(tag);
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var tag = new CMData.CampaignTagRepository().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"], false);
                try
                {
                    new CMData.CampaignTagRepository().Delete(tag);
                }
                catch (Exception ex)
                {
                    ShowErrorModal(this, "This tag is associated with one or more subscribers, or campaigns and cannot be deleted.  You must first remove this tag from all subscribers and campaigns.");
                }
            }
        }

        protected void TagNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadTags(false);
        }

        #endregion

        #region Methods

        private void LoadTags(bool dataBind)
        {
            rgTags.DataSource = new CMData.CampaignTagRepository().GetAll().OrderBy(t => t.Tag);
            if (dataBind)
            {
                rgTags.DataBind();
            }
        }

        protected string TotalSubscribers(int campaignTagID)
        {
            var total = new CMData.SubscriberRepository().GetSubscribersInCampaignTagGroup(campaignTagID);
            if (total != null)
            {
                return total.Count.ToString();
            }
            return "0";
        }
        #endregion
    }
}