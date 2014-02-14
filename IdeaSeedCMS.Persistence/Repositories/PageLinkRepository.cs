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
    public class PageLinkRepository : BaseRepository<PageLink, int>
    {
        public IList<PageLink> GetByPageID(int pageID)
        {
            return Session.CreateCriteria<PageLink>()
                .Add(Expression.Eq("PageID", pageID))
                .List<PageLink>();
        }
    }
}
