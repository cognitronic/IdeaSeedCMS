using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace IdeaSeedCMS.Core.Domain.Interfaces
{
    public interface IPage : IBaseApplicationPage
    {
        int ID { get; set; }
        string Name { get; set; }
        string DisplayName { get; set; }
        string SEOTitle { get; set; }
        string SEOKeywords { get; set; }
        string SEODescription { get; set; }
        int AccessLevel { get; set; }
        string URLRoute { get; set; }
        bool IsActive { get; set; }
        int? ParentID { get; set; }
        int SortOrder { get; set; }
        int NavigationTypeID { get; set; }
        IList<PageLink> Links { get; set; }
        IList<PageContent> Content { get; set; }
        bool IsExternal { get; set; }
        string ExternalURL { get; set; }
        string HeaderImagePath { get; set; }
        IList<IPage> ChildPages { get; set; }
        int PageTypeID { get; set; }
        int ApplicationID { get; set; }
    }
}
