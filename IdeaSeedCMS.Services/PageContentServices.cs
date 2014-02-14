using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Persistence.Repositories;

namespace IdeaSeedCMS.Services
{
    public class PageContentServices
    {
        public PageContent GetByID(int id)
        {
            return new PageContentRepository().GetByID(id, false);
        }

        public IList<PageContent> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new PageContentRepository()
                .GetPagedList(startRow, pageSize, out count)
                .OrderBy(o => o.ID)
                .ToList<PageContent>();
        }

        public IList<PageContent> GetAll()
        {
            return new PageContentRepository()
                .GetAll()
                .OrderBy(o => o.ID)
                .ToList<PageContent>();
        }

        public PageContent Save(PageContent item)
        {
            return new PageContentRepository().SaveOrUpdate(item);
        }

        public void Delete(PageContent item)
        {
            new PageContentRepository().Delete(item);
        }

        public PageContent GetByPageID(int pageID)
        {
            return new PageContentRepository()
                .GetByPageID(pageID);
        }
    }
}
