using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace IdeaSeedCMS.Core.Domain.Interfaces
{
    public interface IStaff : IItem
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string AvatarPath { get; set; }
        string Bio { get; set; }
        string Title { get; set; }
        bool IsActive { get; set; }
    }
}
