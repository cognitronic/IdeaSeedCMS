using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain;

namespace IdeaSeedCMS.Presenters.ViewInterfaces
{
    public interface IPageLinksView : IView
    {
        IList<PageLink> Links { get; set; }
        event EventHandler<CWMGridArg> OnGetItems;
        void LoadResultSet(CWMGridArg args);
    }
}
