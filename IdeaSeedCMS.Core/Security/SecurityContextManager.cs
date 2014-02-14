using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdeaSeedCMS.Core.Security
{
    public class SecurityContextManager
    {
        private static CMSSecurityContext _securityContext;

        private SecurityContextManager()
        { 
        
        }

        public static CMSSecurityContext Current
        {
            get
            {
                return _securityContext;
            }
            set
            {
                _securityContext = value;
            }
        }

    }
}
