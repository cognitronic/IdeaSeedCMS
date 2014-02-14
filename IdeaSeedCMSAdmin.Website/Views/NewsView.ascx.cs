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

namespace IdeaSeedCMSAdmin.Website.Views
{
    public partial class NewsView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadNews(true);
        }

        protected void EditEventClicked(object o, EventArgs e)
        {
            Response.Redirect("/News/" + ((LinkButton)o).Attributes["eventid"]);
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadNews(false);
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    Response.Redirect("/News/New");
                break;
                case RadGrid.DeleteCommandName:
                    var s = new BlogServices().GetByID(Convert.ToInt32(((LinkButton)e.Item.FindControl("lbDelete")).Attributes["linkid"]));
                    new BlogServices().Delete(s);
                    LoadNews(true);
                break;
            }
        }

        private void LoadNews(bool bindData)
        {
            rgNews.DataSource = new BlogServices().GetAll();
            if (bindData)
                rgNews.DataBind();
        }
    }
}