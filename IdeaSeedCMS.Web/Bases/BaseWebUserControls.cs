using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using IdeaSeed.Core;
using IdeaSeedCMS.Web.Security;
using IdeaSeedCMS.Core.Security;
using IdeaSeedCMS.Core;

namespace IdeaSeedCMS.Web.Bases
{
    public class BaseWebUserControl : System.Web.UI.UserControl, IView
    {
        public string Message { get; set; }
        public string ViewTitle { get; set; }
        public event EventHandler InitView;
        public event EventHandler LoadView;
        public event EventHandler UnloadView;

        protected T RegisterView<T>() where T : Presenter
        {
            return PresentationManager.RegisterView<T>(typeof(T), this, new WebSessionProvider());
        }

        protected void SelfRegister(System.Web.UI.UserControl control)
        {
            if (control != null && control is IView)
            {
                object[] attributes = control.GetType().GetCustomAttributes(typeof(PresenterTypeAttribute), true);

                if (attributes != null && attributes.Length > 0)
                {
                    foreach (Attribute viewAttribute in attributes)
                    {
                        if (viewAttribute is PresenterTypeAttribute)
                        {
                            //Had to grab the application context that gets created in the global.asax and shoved into the httpcontext.current.items collection.  In order to use it I have to assign it to the ISessionProvider because presenters have no knowledge of httpcontext.
                            var sessionProvider = new WebSessionProvider();
                            SessionManager.Current = sessionProvider;
                            //if (HttpContext.Current.Items[ResourceStrings.Session_ApplicationContext] != null)
                            //{
                            //    SessionManager.Current[ResourceStrings.Session_ApplicationContext] = (ApplicationContext)HttpContext.Current.Items[ResourceStrings.Session_ApplicationContext];
                            //}
                            PresentationManager.RegisterView((viewAttribute as PresenterTypeAttribute).PresenterType, control as IView, sessionProvider);

                            if (SecurityContextManager.Current == null)
                            {
                                SecurityContextManager.Current = new WebSecurityContext();
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
