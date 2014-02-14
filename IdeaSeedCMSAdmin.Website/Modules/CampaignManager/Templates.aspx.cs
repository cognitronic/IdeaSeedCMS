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
using CampaignManager.Data.Repositories;
using CampaignManager.Presentation;
using IdeaSeed.Core;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMS.Core.Security;
using IdeaSeed.Web;
using IdeaSeedCMSAdmin.Web.Utils;
using System.Drawing;
using NHibernate.Exceptions;
using Iesi.Collections.Generic;

namespace IdeaSeedCMSAdmin.Website.Modules.CampaignManager
{
    public partial class Templates : AdminBasePage
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CampaignHelper.SelectedTemplateID = 0;
                LoadTemplates(true);
            }
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                CampaignHelper.SelectedTemplateID = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"];
                Response.Redirect("Template");
            }

            if (e.CommandName == "NewCampaign")
            {
                CampaignHelper.SelectedTemplateID = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"];
                Response.Redirect("New-Campaign");
            }

            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                Response.Redirect("Template");
            }

            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var template = new CampaignTemplateRepository().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"], false);
                new CampaignTemplateRepository().Delete(template);
            }
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadTemplates(false);
        }

        #endregion

        #region Methods

        private void LoadTemplates(bool dataBind)
        {
            rgTemplates.DataSource = new CampaignTemplateRepository().GetAll().OrderBy(t => t.TemplateName);
            if (dataBind)
            {
                rgTemplates.DataBind();
            }
        }
        #endregion
    }
}