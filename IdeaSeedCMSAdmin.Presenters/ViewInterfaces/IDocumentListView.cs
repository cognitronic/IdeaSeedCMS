using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain;

namespace IdeaSeedCMSAdmin.Presenters.ViewInterfaces
{
    public interface IDocumentListView : IView
    {
        IList<DocumentLibrary> ResultSet { get; set; }
    }
}
