using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdeaSeedCMS.Core.Domain.Interfaces
{
    public interface IPageContent
    {
        int ID { get; set; }
        int PageID { get; set; }
        string Title { get; set; }
        string SubTitle { get; set; }
        string PageData { get; set; }
        int EnteredBy { get; set; }
        int ChangedBy { get; set; }
        DateTime DateCreated { get; set; }
        DateTime LastUpdated { get; set; }
        Page PageRef { get; set; }
    }
}
