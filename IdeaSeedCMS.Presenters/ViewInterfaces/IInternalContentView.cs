using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Presenters.ViewInterfaces
{
    public interface IInternalContentView : IView
    {
        string ContentHTML { get; set; }
    }
}
