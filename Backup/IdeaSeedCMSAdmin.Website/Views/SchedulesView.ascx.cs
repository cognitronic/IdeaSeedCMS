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
    public partial class SchedulesView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSchedules(true);
        }

        protected void EditEventClicked(object o, EventArgs e)
        {
            Response.Redirect("/Schedules/" + ((LinkButton)o).Attributes["eventid"]);
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadSchedules(false);
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                Response.Redirect("/Schedules/New");
            }
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new ScheduleEventServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new ScheduleEventServices().Delete(t);
            }
        }

        private void LoadSchedules(bool bindData)
        {
            rgSchedules.DataSource = new ScheduleEventServices().GetAll();
            if (bindData)
                rgSchedules.DataBind();
        }
    }
}