using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using IdeaSeedCMSAdmin.Presenters;
using IdeaSeedCMS.Services;
using IdeaSeed.Core;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMSAdmin.Presenters.ViewInterfaces;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Domain.Interfaces;
using IdeaSeedCMS.Core.Security;
using Telerik.Web.UI;

namespace IdeaSeedCMSAdmin.Website
{
    public partial class Users : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = "Manage Users";
            if (!IsPostBack)
            {
                LoadUsers(true);
            }
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadUsers(false);
        }



        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    Response.Redirect("/User.aspx");

                    break;
                case RadGrid.EditCommandName:
                    Response.Redirect("/User.aspx?id=" + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString());
                    break;
                case RadGrid.DeleteCommandName:
                    var img = new UserServices().GetByID(Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString()));
                    new UserServices().Delete(img);
                    //LoadLinks(true);
                    break;
            }
        }

        private void LoadUsers(bool bindData)
        {
            var u = new UserServices().GetAll();
            rgUsers.DataSource = u;
            if (bindData)
                rgUsers.DataBind();
        }
    }
}