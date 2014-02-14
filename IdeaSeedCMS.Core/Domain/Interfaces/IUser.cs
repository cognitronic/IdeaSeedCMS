using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace IdeaSeedCMS.Core.Domain.Interfaces
{
    public interface IUser : IBaseUser, IItem
    {
        string PasswordQuestion { get; set; }
        string PasswordAnswer { get; set; }
        DateTime PasswordLastChangedDate { get; set; }
        DateTime LastLoginDate { get; set; }
        bool IsActive { get; set; }
        int AccessLevel { get; set; }
    }
}
