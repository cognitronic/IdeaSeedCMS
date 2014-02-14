using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Core.Domain
{
    public class ScheduleEvent : IScheduleEvent
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int StaffID { get; set; }
        public virtual int EventTypeID { get; set; }
        public virtual Staff StaffRef { get; set; }
        public virtual ScheduleEventType EventTypeRef { get; set; }
    }
}
