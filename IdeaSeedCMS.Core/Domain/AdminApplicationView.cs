using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Core.Domain
{
    public class AdminApplicationView : IAdminApplicationView
    {
        public virtual int ID { get; set; }
        public virtual int PageTypeID { get; set; }
        public virtual string ViewPath { get; set; }
        public virtual int AccessLevel { get; set; }
    }
}
