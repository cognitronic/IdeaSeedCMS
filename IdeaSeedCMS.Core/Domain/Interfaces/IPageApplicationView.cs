using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;

namespace IdeaSeedCMS.Core.Domain.Interfaces
{
    public interface IPageApplicationView
    {
        int ID { get; set; }
        int PageID { get; set; }
        int ApplicationViewID { get; set; }
        ApplicationViewLayout ViewLayout { get; set; }
        int SortOrder { get; set; }
        ApplicationView ApplicationView { get; set; }
        string ViewProperties { get; set; }
    }
}
