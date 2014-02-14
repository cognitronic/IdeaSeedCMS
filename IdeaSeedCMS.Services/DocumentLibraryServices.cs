using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Persistence.Repositories;

namespace IdeaSeedCMS.Services
{
    public class DocumentLibraryServices
    {
        public IList<DocumentLibrary> GetAll()
        {
            return new DocumentLibraryRepository().GetAll();
        }

        public DocumentLibrary Save(DocumentLibrary item)
        {
            return new DocumentLibraryRepository().SaveOrUpdate(item);
        }

        public void Delete(DocumentLibrary item)
        {
            new DocumentLibraryRepository().Delete(item);
        }

        public DocumentLibrary GetByID(int id)
        {
            return new DocumentLibraryRepository().GetByID(id, false);
        }
        public IList<DocumentLibrary> GetByFilters(bool isDeleted, int appid)
        {
            return new DocumentLibraryRepository().GetByFilters(isDeleted, appid);
        }

        public IList<DocumentLibrary> GetByParentID(int parentID)
        {
            return new DocumentLibraryRepository().GetByParentID(parentID);
        }
    }
}
