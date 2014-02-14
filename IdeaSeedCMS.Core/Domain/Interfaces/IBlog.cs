using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdeaSeedCMS.Core.Domain.Interfaces
{
    public interface IBlog
    {
        int ID { get; set; }
        string Title { get; set; }
        int EnteredBy { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string BlogContent { get; set; }
        int PostType { get; set; }
        string SEOKeywords { get; set; }
        string SEODescription { get; set; }
        IUser BlogUser { get; set; }
    }
}
