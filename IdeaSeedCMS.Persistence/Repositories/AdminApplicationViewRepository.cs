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
    public class AdminApplicationViewRepository : BaseRepository<AdminApplicationView, int>
    {
        public IList<AdminApplicationView> GetByPageType(int pageTypeID)
        {
            return Session.CreateCriteria<AdminApplicationView>()
                .Add(Expression.Eq("PageTypeID", pageTypeID))
                .List<AdminApplicationView>();
        }
    }
}
