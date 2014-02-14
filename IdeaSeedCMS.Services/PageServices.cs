using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Persistence.Repositories;

namespace IdeaSeedCMS.Services
{
    public class PageServices
    {
        public Page GetByID(int id)
        {
            return new PageRepository().GetByID(id, false);
        }

        public IList<Page> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new PageRepository()
                .GetPagedList(startRow, pageSize, out count)
                .OrderBy(o => o.SortOrder)
                .ToList<Page>();
        }

        public IList<Page> GetByPageType(int pageType, int appid)
        {
            return new PageRepository().GetByPageType(pageType, appid);
        }

        public IList<Page> GetAll()
        {
            return new PageRepository()
                .GetAll()
                .OrderBy(o => o.SortOrder)
                .ToList<Page>();
        }

        public Page GetByURLRoute(string urlRoute, int appid)
        {
            return new PageRepository().GetByURLRoute(urlRoute, appid);
        }

        public Page Save(Page item)
        {
            return new PageRepository().SaveOrUpdate(item);
        }

        public void Delete(Page item)
        {
            new PageRepository().Delete(item);
        }

        public IList<Page> GetByNavigationTypeAccessLevel(int navtype, int accesslevel, int appid)
        {
            return new PageRepository()
                .GetByNavigationTypeAccessLevel(navtype, accesslevel, appid)
                .OrderBy(o => o.SortOrder)
                .ToList<Page>();
        }

        public IList<Page> GetByNavigationTypeID(int navtype, int appid)
        {
            return new PageRepository()
                .GetByNavigationTypeID(navtype, appid)
                .OrderBy(o => o.SortOrder)
                .ToList<Page>();
        }

        public IList<Page> GetByMarkedForDeletion(bool marked)
        {
            return new PageRepository()
            .GetByMarkedForDeletion(marked)
            .ToList<Page>();
        }

        public IList<Page> GetAllActive(int appid)
        {
            return new PageRepository()
                .GetAllActive(appid)
                .OrderBy(o => o.SortOrder)
                .ToList<Page>();
        }

        public Page GetByNameAccessLevel(string name, int accesslevel, int appid)
        {
            return new PageRepository()
            .GetByNameAccessLevel(name, accesslevel, appid);
        }

        public IList<Page> GetByApplicationID(int appid)
        {
            return new PageRepository().GetByApplicationID(appid);
        }
    }
}
