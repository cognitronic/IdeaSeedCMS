using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Presenters.ViewInterfaces
{
    public interface IBlogListView : IView
    {
        string BlogHTML { get; set; }
        string Links { get; set; }
    }
}
