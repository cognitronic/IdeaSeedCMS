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
    public class ApplicationViewRepository : BaseRepository<ApplicationView, int>
    {
        public ApplicationView GetByName(string name)
        {
            return Session.CreateCriteria<ApplicationView>()
                .Add(Expression.Eq("Name", name))
                .UniqueResult<ApplicationView>();
        }
    }
}
