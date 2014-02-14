using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Persistence.Repositories;

namespace IdeaSeedCMS.Services
{
    public class PageLinkServices
    {
        public PageLink GetByID(int id)
        {
            return new PageLinkRepository().GetByID(id, false);
        }

        public IList<PageLink> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new PageLinkRepository()
                .GetPagedList(startRow, pageSize, out count)
                .OrderBy(o => o.ID)
                .ToList<PageLink>();
        }

        public IList<PageLink> GetAll()
        {
            return new PageLinkRepository()
                .GetAll()
                .OrderBy(o => o.ID)
                .ToList<PageLink>();
        }

        public PageLink Save(PageLink item)
        {
            return new PageLinkRepository().SaveOrUpdate(item);
        }

        public void Delete(PageLink item)
        {
            new PageLinkRepository().Delete(item);
        }

        public IList<PageLink> GetByPageID(int pageID)
        {
            return new PageLinkRepository()
                .GetByPageID(pageID)
                .OrderBy(o => o.ID)
                .ToList<PageLink>();
        }
    }
}
