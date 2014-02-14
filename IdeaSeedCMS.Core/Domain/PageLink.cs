using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Core.Domain
{
    public class PageLink : IPageLink
    {
        public virtual int ID { get; set; }
        public virtual int PageID { get; set; }
        public virtual string ImagePath { get; set; }
        public virtual string Title { get; set; }
        public virtual string URL { get; set; }
        public virtual string LinkContent { get; set; }
        public virtual Page PageRef { get; set; }
    }
}
