using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Presenters.ViewInterfaces
{
    public interface IContactUsView : IView
    {
        string Name { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string Message { get; set; }
        event EventHandler SendMessage;
        bool IsSuccessful { get; set; }
    }
}
