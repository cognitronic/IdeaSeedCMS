using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.SessionState;
using IdeaSeed.Core;

namespace IdeaSeedCMSAdmin.Web.Security
{
    public class WebSessionProvider : ISessionProvider
    {
        private HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }

        public void Add(string name, object value)
        {
            Session.Add(name, value);
        }

        public void Clear()
        {
            Session.Clear();
        }

        public bool Contains(string name)
        {
            return Session[name] != null;
        }

        #region ISessionProvider Members

        object ISessionProvider.this[string name]
        {
            get
            {
                return Session[name];
            }
            set
            {
                Session[name] = value;
            }
        }

        object ISessionProvider.this[int index]
        {
            get
            {
                return Session[index];
            }
            set
            {
                Session[index] = value;
            }
        }

        #endregion
    }
}
