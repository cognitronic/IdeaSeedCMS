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
    public class DocumentLibraryRepository : BaseRepository<DocumentLibrary, int>
    {
        public IList<DocumentLibrary> GetByFilters(bool isDeleted, int appid)
        {
            return Session.CreateCriteria<DocumentLibrary>()
                    .Add(Expression.Eq("MarkedForDeletion", isDeleted))
                    .Add(Expression.Eq("ApplicationID", appid))
                    .List<DocumentLibrary>();
        }

        public IList<DocumentLibrary> GetByParentID(int parentID)
        {
            return Session.CreateCriteria<DocumentLibrary>()
                    .Add(Expression.Eq("ParentID", parentID))
                    .List<DocumentLibrary>();
        }
    }
}
