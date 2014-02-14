using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Persistence.Repositories;

namespace IdeaSeedCMS.Services
{
    public class StaffServices
    {
        public Staff GetByID(int id)
        {
            return new StaffRepository().GetByID(id, false);
        }

        public IList<Staff> GetAll()
        {
            return new StaffRepository()
                .GetAll()
                .OrderBy(o => o.LastName)
                .ToList<Staff>(); ;
        }

        public Staff Save(Staff item)
        {
            return new StaffRepository().SaveOrUpdate(item);
        }

        public void Delete(Staff item)
        {
            new StaffRepository().Delete(item);
        }

        public Staff GetByEmail(string email)
        {
            return new StaffRepository().GetByEmail(email);
        }
    }
}
