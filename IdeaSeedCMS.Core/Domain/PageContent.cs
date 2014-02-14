using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Core.Domain
{
    public class PageContent : IPageContent
    {
        public virtual int ID { get; set; }
        public virtual int PageID { get; set; }
        public virtual string Title { get; set; }
        public virtual string SubTitle { get; set; }
        public virtual string PageData { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual Page PageRef { get; set; }
    }
}
