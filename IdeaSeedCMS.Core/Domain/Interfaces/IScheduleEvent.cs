using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Core.Domain.Interfaces
{
    public interface IScheduleEvent
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        bool IsActive { get; set; }
        int EventTypeID { get; set; }
    }
}
