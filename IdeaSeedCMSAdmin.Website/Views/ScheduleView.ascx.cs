using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMSAdmin.Presenters;
using IdeaSeedCMS.Core;
using IdeaSeedCMS.Services;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Security;
using Telerik.Web.UI;


namespace IdeaSeedCMSAdmin.Website.Views
{
    public partial class ScheduleView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadEvent();
            LoadSchedule(true);
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadSchedule(false);
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.EditCommandName:
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetEditMode", "isEditMode = true;", true);
                    break;
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    var i = new IdeaSeedCMS.Core.Domain.Schedule();
                    i.Name = "";
                    i.Description = "";
                    i.ScheduleEventID = 0;
                    i.ID = 0;
                    i.StartTime = DateTime.Now;
                    i.EndTime = DateTime.Now;
                    e.Item.OwnerTableView.InsertItem(new IdeaSeedCMS.Core.Domain.Schedule());
                    break;
                case RadGrid.UpdateCommandName:
                    var img = new ScheduleServices().GetByID(Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString()));
                    GridEditFormItem insertItem = e.Item as GridEditFormItem;
                    img.Name = (insertItem["Name"].FindControl("ddlDayOfWeek") as IdeaSeedCMSAdmin.Web.Controls.DayOfWeekDDL).SelectedValue;
                    img.ScheduleEventID = ((ScheduleEvent)SecurityContextManager.Current.CurrentItem.ItemReference).ID;
                    img.StartTime = (DateTime)(insertItem["StartTime"].FindControl("rtpStartTime") as RadTimePicker).DbSelectedDate;
                    img.EndTime = (DateTime)(insertItem["EndTime"].FindControl("rtpEndTime") as RadTimePicker).DbSelectedDate;
                    new ScheduleServices().Save(img);
                    break;
                case RadGrid.PerformInsertCommandName:
                    insertItem = e.Item as GridEditFormInsertItem;
                    img = new IdeaSeedCMS.Core.Domain.Schedule();
                    img.Name = (insertItem["Name"].FindControl("ddlDayOfWeek") as IdeaSeedCMSAdmin.Web.Controls.DayOfWeekDDL).SelectedValue;
                    img.ScheduleEventID = ((ScheduleEvent)SecurityContextManager.Current.CurrentItem.ItemReference).ID;
                    img.StartTime = (DateTime)(insertItem["StartTime"].FindControl("rtpStartTime") as RadTimePicker).DbSelectedDate;
                    img.EndTime = (DateTime)(insertItem["EndTime"].FindControl("rtpEndTime") as RadTimePicker).DbSelectedDate;
                    new ScheduleServices().Save(img);

                    LoadSchedule(true);

                    break;
                case RadGrid.DeleteCommandName:
                    img = new ScheduleServices().GetByID(Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString()));
                    new ScheduleServices().Delete(img);
                    LoadSchedule(true);
                    break;
            }
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            if (!SecurityContextManager.Current.CurrentURL.Contains("New"))
            {
                var se = new ScheduleEventServices().GetByID(((ScheduleEvent)SecurityContextManager.Current.CurrentItem.ItemReference).ID);
                se.Description = tbDescription.Text;
                se.EventTypeID = Convert.ToInt16(ddlEventType.SelectedValue);
                se.IsActive = cbIsActive.Checked;
                se.Name = tbName.Text;
                se.StaffID = Convert.ToInt16(ddlStaff.SelectedValue);
                new ScheduleEventServices().Save(se);
                Response.Redirect("/Schedules/" + se.ID.ToString());
            }
            else
            {
                var se = new ScheduleEvent();
                se.Description = tbDescription.Text;
                se.EventTypeID = Convert.ToInt16(ddlEventType.SelectedValue);
                se.IsActive = cbIsActive.Checked;
                se.Name = tbName.Text;
                se.StaffID = Convert.ToInt16(ddlStaff.SelectedValue);
                new ScheduleEventServices().Save(se);
            }
            LoadEvent();
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect("/Schedules");
        }

        private void LoadSchedule(bool bindData)
        {
            if (((ScheduleEvent)SecurityContextManager.Current.CurrentItem.ItemReference) != null && ((ScheduleEvent)SecurityContextManager.Current.CurrentItem.ItemReference).ID > 0)
            {
                rgSchedule.DataSource = new ScheduleServices().GetByFilters(null, ((ScheduleEvent)SecurityContextManager.Current.CurrentItem.ItemReference).ID);
            }
            else
            {
                rgSchedule.DataSource = null;
            }
            if (bindData)
                rgSchedule.DataBind();
        }

        private void LoadEvent()
        {
            if (((ScheduleEvent)SecurityContextManager.Current.CurrentItem.ItemReference) != null && ((ScheduleEvent)SecurityContextManager.Current.CurrentItem.ItemReference).ID > 0)
            {
                var se = ((ScheduleEvent)SecurityContextManager.Current.CurrentItem.ItemReference);
                cbIsActive.Checked = se.IsActive;
                tbDescription.Text = se.Description;
                tbName.Text = se.Name;
                ddlEventType.SelectedValue = se.EventTypeID.ToString();
                ddlStaff.SelectedValue = se.StaffID.ToString();
            }
        }
    }
}