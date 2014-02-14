using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdeaSeedCMS.Core.Domain.Interfaces
{
    public interface IAdminApplicationView
    {
        int ID { get; set; }
        int PageTypeID { get; set; }
        string ViewPath { get; set; }
        int AccessLevel { get; set; }
    }
}
