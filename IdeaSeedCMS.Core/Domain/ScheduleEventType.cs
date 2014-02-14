using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Core.Domain
{
    public class ScheduleEventType : IScheduleEventType
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
