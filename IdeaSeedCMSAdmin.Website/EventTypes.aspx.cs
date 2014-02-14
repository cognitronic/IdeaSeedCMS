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
    public partial class EventTypes : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = "Event Types List";
            if (!IsPostBack)
                LoadBanner(true);
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                Response.Redirect("/EventType.aspx");
            }

            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var t = new ScheduleEventTypeServices().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
                new ScheduleEventTypeServices().Delete(t);
            }
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadBanner(false);
        }

        protected void EditItemClicked(object o, EventArgs e)
        {
            Response.Redirect("/EventType.aspx?id=" + ((LinkButton)o).Attributes["itemid"]);
        }

        private void LoadBanner(bool bindData)
        {
            rgList.DataSource = new ScheduleEventTypeServices().GetAll();
            if (bindData)
                rgList.DataBind();
        }
    }
}