using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Core.Domain
{
    public class Page : IPage
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string SEOTitle { get; set; }
        public virtual string SEOKeywords { get; set; }
        public virtual string SEODescription { get; set; }
        public virtual int AccessLevel { get; set; }
        public virtual string URLRoute { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int? ParentID { get; set; }
        public virtual int SortOrder { get; set; }
        public virtual int NavigationTypeID { get; set; }
        public virtual string Title { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        private IList<PageLink> _links = new List<PageLink>();
        public virtual IList<PageLink> Links { get { return _links; } set { _links = value; } }
        private IList<PageContent> _content = new List<PageContent>();
        public virtual IList<PageContent> Content { get { return _content; } set { _content = value; } }
        private IList<IPage> _childPages = new List<IPage>();
        public virtual IList<IPage> ChildPages { get { return _childPages; } set { _childPages = value; } }
        public virtual bool IsExternal { get; set; }
        public virtual string ExternalURL { get; set; }
        public virtual string HeaderImagePath { get; set; }
        public virtual int PageTypeID { get; set; }
        public virtual int ApplicationID { get; set; }
        public virtual Application ApplicationRef { get; set; }
    }
}
