using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain.Interfaces;
using IdeaSeedCMS.Core.Domain;

namespace IdeaSeedCMS.Presenters.ViewInterfaces
{
    public interface IScheduleView : IView
    {
        IList<Schedule> MondayScheduleList { get; set; }
        IList<Schedule> TuesdayScheduleList { get; set; }
        IList<Schedule> WednesdayScheduleList { get; set; }
        IList<Schedule> ThursdayScheduleList { get; set; }
        IList<Schedule> FridayScheduleList { get; set; }
        IList<Schedule> SaturdayScheduleList { get; set; }
        IList<Schedule> SundayScheduleList { get; set; }
        int? SelectedStaffID { get; set; }
        int? SelectedEventTypeID { get; set; }
    }
}
