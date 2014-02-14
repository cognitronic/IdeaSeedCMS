using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Core.Domain
{
    public class Schedule : ISchedule
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int ScheduleEventID { get; set; }
        public virtual ScheduleEvent ScheduledEventRef { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
    }
}
