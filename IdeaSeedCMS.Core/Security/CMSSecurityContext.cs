using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain.Interfaces;
using IdeaSeedCMS.Core.Domain;

namespace IdeaSeedCMS.Core.Security
{
    public interface CMSSecurityContext : ISecurityContext
    {
        AuthenticationResponse AuthenticateUser(string userName, string password, string url, ISecurityContext securityContext);
        ApplicationContext AppContext { get; set; }

        Application CurrentManagedApplication { get; set; }
    }
}
