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
    public partial class CampaignManagerSettings : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                LoadSettings(true);
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditableItem)
                {
                    var setting = new CMData.CampaignManagerSettingRepository().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"], false);
                    setting.Value = (e.Item.FindControl("tbValue") as IdeaSeed.Web.UI.TextBox).Text;
                    new CMData.CampaignManagerSettingRepository().Save(setting);
                    LoadSettings(true);
                }
            }
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadSettings(false);
        }

        private void LoadSettings(bool bindData)
        {
            rgSettings.DataSource = new CMData.CampaignManagerSettingRepository().GetAll();
            if (bindData)
                rgSettings.DataBind();
        }
    }
}