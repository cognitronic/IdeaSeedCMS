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
    public partial class EventType : AdminBasePage
    {
        private IdeaSeedCMS.Core.Domain.ScheduleEventType SelectedEvent
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    return new ScheduleEventTypeServices().GetByID(Convert.ToInt16(Request.QueryString["id"]));
                }
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = "Event Type Detail";
            if (!IsPostBack)
                LoadBanner();
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            var b = new ScheduleEventType();
            if (SelectedEvent != null)
            {
                b = SelectedEvent;
            }
            b.Name = tbName.Text;
            b.Description = tbDescription.Text;
            new ScheduleEventTypeServices().Save(b);
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect("/EventTypes.aspx");
        }

        private void LoadBanner()
        {
            if (SelectedEvent != null)
            {
                tbName.Text = SelectedEvent.Name;
                tbDescription.Text = SelectedEvent.Description;

            }
        }
    }
}