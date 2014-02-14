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
    public class PageContentRepository : BaseRepository<PageContent, int>
    {
        public PageContent GetByPageID(int pageID)
        {
            return Session.CreateCriteria<PageContent>()
                .Add(Expression.Eq("PageID", pageID))
                .UniqueResult<PageContent>();
        }
    }
}
