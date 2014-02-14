using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Persistence.Repositories;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Services
{
    public class PageViewServices
    {
        public IOrderedEnumerable<PageApplicationView> GetPageApplicationViewsByPageID(int pageID)
        {
            return new PageApplicationViewRepository().GetByPageID(pageID).OrderBy(o => o.SortOrder);
        }

        public PageApplicationView GetPageApplicationViewsByPageIDApplicationViewID(int pageID, int appViewID)
        {
            return new PageApplicationViewRepository().GetByPageIDApplicationViewID(pageID, appViewID);
        }

        public PageApplicationView Save(PageApplicationView item)
        {
            return new PageApplicationViewRepository().SaveOrUpdate(item);
        }
    }
}
