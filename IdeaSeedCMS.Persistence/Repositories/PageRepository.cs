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
    public class PageRepository : BaseRepository<Page, int>
    {
        public Page GetByNameAccessLevel(string name, int accesslevel, int appid)
        {
            return Session.CreateCriteria<Page>()
                .Add(Expression.Eq("Name", name))
                .Add(Expression.Eq("ApplicationID", appid))
                .Add(Expression.Eq("AccessLevel", accesslevel))
                .UniqueResult<Page>();
        }

        public IList<Page> GetByNavigationTypeAccessLevel(int navtype, int accesslevel, int appid)
        {
            return Session.CreateCriteria<Page>()
                .Add(Expression.Eq("IsActive", true))
                .Add(Expression.Eq("ApplicationID", appid))
                .Add(Expression.Eq("NavigationTypeID", navtype))
                .Add(Expression.Eq("AccessLevel", accesslevel))
                .List<Page>();
        }

        public IList<Page> GetByPageType(int pageType, int appid)
        {
            return Session.CreateCriteria<Page>()
                .Add(Expression.Eq("ApplicationID", appid))
                .Add(Expression.Eq("PageTypeID", pageType))
                .List<Page>();
        }

        public Page GetByURLRoute(string urlRoute, int appid)
        {
            return Session.CreateCriteria<Page>()
                .Add(Expression.Eq("ApplicationID", appid))
                .Add(Expression.Eq("IsActive", true))
                .Add(Expression.Eq("URLRoute", urlRoute))
                .UniqueResult<Page>();
        }

        public IList<Page> GetByApplicationID(int appid)
        {
            return Session.CreateCriteria<Page>()
                .Add(Expression.Eq("ApplicationID", appid))
                .Add(Expression.Eq("MarkedForDeletion", false))
                .List<Page>();
        }

        public IList<Page> GetByMarkedForDeletion(bool marked)
        {
            return Session.CreateCriteria<Page>()
                .Add(Expression.Eq("MarkedForDeletion", marked))
                .List<Page>();
        }

        public IList<Page> GetAllActive(int appid)
        {
            return Session.CreateCriteria<Page>()
                .Add(Expression.Eq("ApplicationID", appid))
                .Add(Expression.Eq("IsActive", true))
                .List<Page>();
        }

        public IList<Page> GetByNavigationTypeID(int navigationtypeid, int appid)
        {
            return Session.CreateCriteria<Page>()
                .Add(Expression.Eq("ApplicationID", appid))
                .Add(Expression.Eq("IsActive", true))
                .Add(Expression.Eq("NavigationTypeID", navigationtypeid))
                .List<Page>();
        }

        public IList<Page> GetSubPagesByParentID(int parentID, int appid)
        {
            return Session.CreateCriteria<Page>()
                .Add(Expression.Eq("ApplicationID", appid))
                    .Add(Expression.Eq("IsActive", true))
                    .Add(Expression.Eq("ParentID", parentID))
                    .List<Page>();
        }
    }
}
