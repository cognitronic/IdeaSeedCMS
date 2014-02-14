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
    public class ApplicationRepository : BaseRepository<Application, int>
    {
        public Application GetByName(string name)
        {
            return Session.CreateCriteria<Application>()
                .Add(Expression.Eq("Name", name))
                .UniqueResult<Application>();
        }
    }
}
