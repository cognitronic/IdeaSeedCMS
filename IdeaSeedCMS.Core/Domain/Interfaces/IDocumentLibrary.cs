using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeed.Core;

namespace IdeaSeedCMS.Core.Domain.Interfaces
{
    public interface IDocumentLibrary : IBaseAuditable, IBaseItem
    {
        string Path { get; set; }
        bool IsFolder { get; set; }
        int? ParentID { get; set; }
        int ApplicationID { get; set; }
    }
}
