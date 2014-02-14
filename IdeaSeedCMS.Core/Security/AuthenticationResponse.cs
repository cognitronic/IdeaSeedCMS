using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace IdeaSeedCMS.Core.Security
{
    public class AuthenticationResponse
    {
        public bool IsAuthenticated { get; set; }
        public string Message { get; set; }
        public AccessLevels CurrentAccessLevel { get; set; }
    }
}
