using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Persistence.Repositories;

namespace IdeaSeedCMS.Services
{
    public class ScheduleEventTypeServices
    {
        public ScheduleEventType GetByID(int id)
        {
            return new ScheduleEventTypeRepository().GetByID(id, false);
        }

        public IList<ScheduleEventType> GetAll()
        {
            return new ScheduleEventTypeRepository()
                .GetAll()
                .OrderBy(o => o.ID)
                .ToList<ScheduleEventType>();
        }

        public ScheduleEventType Save(ScheduleEventType item)
        {
            return new ScheduleEventTypeRepository().SaveOrUpdate(item);
        }

        public void Delete(ScheduleEventType item)
        {
            new ScheduleEventTypeRepository().Delete(item);
        }

        
    }
}
