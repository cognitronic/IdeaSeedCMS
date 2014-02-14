using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMSAdmin.Presenters.ViewInterfaces
{
    public interface IDefaultPageView : IView
    {
        event EventHandler OnLoadData;
        IList<IAdminApplicationView> MainContentViews { get; set; }
    }
}
