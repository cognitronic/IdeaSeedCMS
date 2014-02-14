using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Presenters.ViewInterfaces
{
    public interface IPrimaryNavView : IView
    {
        event EventHandler OnLoadNav;
        event EventHandler OnLinkClicked;
        string PrimaryNavText { get; set; }
    }
}
