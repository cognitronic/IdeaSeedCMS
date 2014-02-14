using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using IdeaSeed.Core.Data.NHibernate;
using IdeaSeedCMS.Core.Domain;

namespace IdeaSeedCMS.Persistence.Repositories
{
    public class StaffRepository : BaseRepository<Staff, int>
    {
        public Staff GetByEmail(string email)
        {
            return Session.CreateCriteria<Staff>()
                .Add(Expression.Eq("Email", email))
                .UniqueResult<Staff>();
        }
    }
}
