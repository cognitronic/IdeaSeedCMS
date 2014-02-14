using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain.Interfaces;
using IdeaSeedCMS.Core.Domain;

namespace IdeaSeedCMS.Presenters.ViewInterfaces
{
    public interface IStaffProfileView : IView
    {
        string Links { get; set; }
        string ProfileContent { get; set; }
    }
}
