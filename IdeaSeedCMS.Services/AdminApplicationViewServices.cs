using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Persistence.Repositories;

namespace IdeaSeedCMS.Services
{
    public class AdminApplicationViewServices
    {
        public AdminApplicationView GetByID(int id)
        {
            return new AdminApplicationViewRepository().GetByID(id, false);
        }

        public IList<AdminApplicationView> GetAll()
        {
            return new AdminApplicationViewRepository()
                .GetAll()
                .OrderBy(o => o.ID)
                .ToList<AdminApplicationView>();
        }

        public AdminApplicationView Save(AdminApplicationView item)
        {
            return new AdminApplicationViewRepository().SaveOrUpdate(item);
        }

        public void Delete(AdminApplicationView item)
        {
            new AdminApplicationViewRepository().Delete(item);
        }

        public IList<AdminApplicationView> GetByPageType(int pageTypeID)
        {
            return new AdminApplicationViewRepository().GetByPageType(pageTypeID);
        }
    }
}
