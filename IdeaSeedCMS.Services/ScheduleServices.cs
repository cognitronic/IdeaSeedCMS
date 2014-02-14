using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Persistence.Repositories;

namespace IdeaSeedCMS.Services
{
    public class ScheduleServices
    {
        public Schedule GetByID(int id)
        {
            return new ScheduleRepository().GetByID(id, false);
        }

        public IList<Schedule> GetAll()
        {
            return new ScheduleRepository()
                .GetAll()
                .OrderBy(o => o.ID)
                .ToList<Schedule>();
        }

        public Schedule Save(Schedule item)
        {
            return new ScheduleRepository().SaveOrUpdate(item);
        }

        public void Delete(Schedule item)
        {
            new ScheduleRepository().Delete(item);
        }

        public IList<Schedule> GetByFilters(string name, int? eventID)
        {
            return new ScheduleRepository().GetByFilters(name, eventID);
        }
    }
}
