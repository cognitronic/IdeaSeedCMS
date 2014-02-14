using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Persistence.Repositories;

namespace IdeaSeedCMS.Services
{
    public class ApplicationServices
    {
        public Application GetByID(int id)
        {
            return new ApplicationRepository().GetByID(id, false);
        }

        public IList<Application> GetAll()
        {
            return new ApplicationRepository()
                .GetAll()
                .OrderBy(o => o.ID)
                .ToList<Application>();
        }

        public Application Save(Application item)
        {
            return new ApplicationRepository().SaveOrUpdate(item);
        }

        public void Delete(Application item)
        {
            new ApplicationRepository().Delete(item);
        }

        public Application GetByName(string name)
        {
            return new ApplicationRepository().GetByName(name);
        }
    }
}
