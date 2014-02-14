using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Presenters.ViewInterfaces;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Security;
using IdeaSeed.Core;
using System.Configuration;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core;

namespace IdeaSeedCMS.Presenters
{
    public class SchedulePresenter : Presenter
    {
        IScheduleView _view;

        public SchedulePresenter(IScheduleView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IScheduleView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {

        }

        void _view_LoadView(object sender, EventArgs e)
        {
            _view.MondayScheduleList = EventsList("Monday", _view.SelectedEventTypeID, _view.SelectedStaffID).OrderBy(o => o.Name).ToList<Schedule>();
            _view.TuesdayScheduleList = EventsList("Tuesday", _view.SelectedEventTypeID, _view.SelectedStaffID).OrderBy(o => o.Name).ToList<Schedule>();
            _view.WednesdayScheduleList = EventsList("Wednesday", _view.SelectedEventTypeID, _view.SelectedStaffID).OrderBy(o => o.Name).ToList<Schedule>();
            _view.ThursdayScheduleList = EventsList("Thursday", _view.SelectedEventTypeID, _view.SelectedStaffID).OrderBy(o => o.Name).ToList<Schedule>();
            _view.FridayScheduleList = EventsList("Friday", _view.SelectedEventTypeID, _view.SelectedStaffID).OrderBy(o => o.Name).ToList<Schedule>();
            _view.SaturdayScheduleList = EventsList("Saturday", _view.SelectedEventTypeID, _view.SelectedStaffID).OrderBy(o => o.Name).ToList<Schedule>();
            _view.SundayScheduleList = EventsList("Sunday", _view.SelectedEventTypeID, _view.SelectedStaffID).OrderBy(o => o.Name).ToList<Schedule>();
        }

        void _view_InitView(object sender, EventArgs e)
        {

        }

        private IList<Schedule> EventsList(string schedule, int? eventTypeID, int? staffID)
        {
            var list = new List<Schedule>();
            foreach (var m in new ScheduleServices().GetByFilters(schedule, null).OrderBy(o => DateTime.Parse(o.StartTime.ToShortTimeString())))
            {
                if (eventTypeID != null && staffID != null)
                {
                    if (m.ScheduledEventRef.EventTypeID == eventTypeID && m.ScheduledEventRef.StaffID == staffID)
                    {
                        list.Add(m);
                    }
                }
                else if (eventTypeID != null)
                {
                    if (m.ScheduledEventRef.EventTypeID == eventTypeID)
                    {
                        list.Add(m);
                    }
                }
                else if (staffID != null)
                {
                    if (m.ScheduledEventRef.StaffID == staffID)
                    {
                        list.Add(m);
                    }
                }
                else
                {
                    list.Add(m);
                }
            }
            return list;
        }
    }
}
