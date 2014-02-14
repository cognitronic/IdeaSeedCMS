using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdeaSeedCMS.Core.Domain.Interfaces
{
    public interface ISchedule
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int ScheduleEventID { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
    }
}
