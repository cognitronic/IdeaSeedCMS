using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdeaSeedCMSAdmin.Presenters.ViewInterfaces;
using IdeaSeedCMSAdmin.Presenters;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Security;
using IdeaSeed.Core;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMS.Core;
using Telerik.Web.UI;
using IdeaSeedCMS.Services;
using System.Configuration;

namespace IdeaSeedCMSAdmin.Website
{
    public partial class Banners : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = "Banner List";
            if (!IsPostBack)
                LoadBanner(true);
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                Response.Redirect("/Banner.aspx");
            }
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadBanner(false);
        }

        protected void EditBannerClicked(object o, EventArgs e)
        {
            Response.Redirect("/Banner.aspx?id=" + ((LinkButton)o).Attributes["itemid"]);
        }

        protected void DeleteClicked(object o, EventArgs e)
        {
            var p = new BannerImageServices().GetByID(Convert.ToInt16(((IdeaSeed.Web.UI.LinkButton)o).Attributes["itemID"]));
            new BannerImageServices().Delete(p);
            Context.Cache.Remove(ResourceStrings.Cache_BannerImagesData);
            Context.Cache.Insert(ResourceStrings.Cache_BannerImagesData, new BannerImageServices().GetAll());
            LoadBanner(true);
        }

        private void LoadBanner(bool bindData)
        {
            rgList.DataSource = new BannerImageServices().GetAll();
            if (bindData)
                rgList.DataBind();
        }
    }
}