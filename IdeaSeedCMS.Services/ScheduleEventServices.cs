using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Persistence.Repositories;

namespace IdeaSeedCMS.Services
{
    public class ScheduleEventServices
    {
        public ScheduleEvent GetByID(int id)
        {
            return new ScheduleEventRepository().GetByID(id, false);
        }

        public IList<ScheduleEvent> GetAll()
        {
            return new ScheduleEventRepository()
                .GetAll()
                .OrderBy(o => o.ID)
                .ToList<ScheduleEvent>();
        }

        public ScheduleEvent Save(ScheduleEvent item)
        {
            return new ScheduleEventRepository().SaveOrUpdate(item);
        }

        public void Delete(ScheduleEvent item)
        {
            new ScheduleEventRepository().Delete(item);
        }

        public IList<ScheduleEvent> GetByFilters(string name, DateTime? startTime, DateTime? endTime, int? staffID, int? eventTypeID)
        {
            return new ScheduleEventRepository().GetByFilters(name, startTime, endTime, staffID, eventTypeID);
        }
    }
}
