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
    public partial class StaffList : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = "Staff List";
            if (!IsPostBack)
                LoadStaff(true);
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                Response.Redirect("/Staff.aspx");
            }

            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new StaffServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new StaffServices().Delete(t);
            }
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadStaff(false);
        }

        protected void EditStaffClicked(object o, EventArgs e)
        {
            Response.Redirect("/Staff.aspx?id=" + ((LinkButton)o).Attributes["itemid"]);
        }

        private void LoadStaff(bool bindData)
        {
            rgStaff.DataSource = new StaffServices().GetAll();
            if (bindData)
                rgStaff.DataBind();
        }
    }
}