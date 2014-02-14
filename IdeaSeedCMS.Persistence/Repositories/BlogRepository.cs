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
    public class BlogRepository : BaseRepository<Blog, int>
    {
        public IList<Blog> GetByPostType(int postType)
        {
            return Session.CreateCriteria<Blog>()
                .Add(Expression.Eq("PostType", postType))
                .Add(Restrictions.Le("StartDate", DateTime.Now))
                .Add(Restrictions.Ge("EndDate", DateTime.Now.AddDays(-1)))
                .List<Blog>();
        }

        public Blog GetLatestByType(int postType)
        {
            return Session.CreateCriteria<Blog>()
                .Add(Expression.Eq("PostType", postType))
                .AddOrder(Order.Desc("StartDate"))
                .SetMaxResults(1)
                .UniqueResult<Blog>();
        }

        public Blog GetByTypeTitle(int postType, string title)
        {
            return Session.CreateCriteria<Blog>()
                .Add(Expression.Eq("PostType", postType))
                .Add(Expression.Eq("Title", title))
                .UniqueResult<Blog>();
        }

        public Blog GetByTitle(string title)
        {
            return Session.CreateCriteria<Blog>()
                .Add(Expression.Eq("Title", title))
                .UniqueResult<Blog>();
        }
    }
}
