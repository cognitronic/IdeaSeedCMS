using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdeaSeedCMS.Presenters.ViewInterfaces;
using IdeaSeedCMS.Presenters;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Security;
using IdeaSeed.Core;
using IdeaSeedCMS.Web.Bases;
using IdeaSeedCMS.Core;
using Telerik.Web.UI;

namespace IdeaSeed.Website.Views
{
    [PresenterType(typeof(SchedulePresenter))]
    public partial class ScheduleView : BaseWebUserControl, IScheduleView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, e);
            }
            LoadData(true);
        }

        protected void SearchClicked(object o, EventArgs e)
        {
            if (ddlEventType.SelectedIndex > 0)
                SelectedEventTypeID = Convert.ToInt16(ddlEventType.SelectedValue);
            if (ddlStaff.SelectedIndex > 0)
                SelectedStaffID = Convert.ToInt16(ddlStaff.SelectedValue);
            if (this.LoadView != null)
            {
                this.LoadView(this, e);
            }
            LoadData(true);
        }

        protected void NeedDataSource(object o, RadListViewNeedDataSourceEventArgs e)
        {
            LoadData(false);
        }

        private void LoadData(bool bindData)
        {
            dlMonday.DataSource = this.MondayScheduleList;
            if (bindData)
                dlMonday.DataBind();
            dlTuesday.DataSource = this.TuesdayScheduleList;
            if (bindData)
                dlTuesday.DataBind();
            dlWednesday.DataSource = this.WednesdayScheduleList;
            if (bindData)
                dlWednesday.DataBind();
            dlThursday.DataSource = this.ThursdayScheduleList;
            if (bindData)
                dlThursday.DataBind();
            dlFriday.DataSource = this.FridayScheduleList;
            if (bindData)
                dlFriday.DataBind();
            dlSaturday.DataSource = this.SaturdayScheduleList;
            if (bindData)
                dlSaturday.DataBind();
        }


        public event EventHandler LoadView;

        public event EventHandler OnLinkClicked;

        #region IScheduleView Members

        public IList<Schedule> MondayScheduleList
        {
            get;
            set;
        }

        public IList<Schedule> TuesdayScheduleList
        {
            get;
            set;
        }

        public IList<Schedule> WednesdayScheduleList
        {
            get;
            set;
        }

        public IList<Schedule> ThursdayScheduleList
        {
            get;
            set;
        }

        public IList<Schedule> FridayScheduleList
        {
            get;
            set;
        }

        public IList<Schedule> SaturdayScheduleList
        {
            get;
            set;
        }

        public IList<Schedule> SundayScheduleList
        {
            get;
            set;
        }

        public int? SelectedStaffID
        {
            get
            {
                if (ddlStaff.SelectedIndex > 0)
                {
                    return Convert.ToInt16(ddlStaff.SelectedValue);
                }
                return null;
            }
            set
            {
                ddlStaff.SelectedValue = value.ToString();
            }
        }

        public int? SelectedEventTypeID
        {
            get
            {
                if (ddlEventType.SelectedIndex > 0)
                {
                    return Convert.ToInt16(ddlEventType.SelectedValue);
                }
                return null;
            }
            set
            {
                ddlEventType.SelectedValue = value.ToString();
            }
        }

        #endregion
    }
}