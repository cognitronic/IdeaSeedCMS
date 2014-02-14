using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using IdeaSeed.Core;
using IdeaSeed.Web;
using System.Web.SessionState;
using IdeaSeedCMS.Core.Security;
using IdeaSeedCMS.Core;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMSAdmin.Web.Security
{
    public class WebSecurityContext : CMSSecurityContext, IRequiresSessionState
    {
        public WebSecurityContext()
        {
            this.SignOut += new EventHandler(WebSecurityContext_SignOut);
        }

        void WebSecurityContext_SignOut(object sender, EventArgs e)
        {
            SecurityContextManager.Current = null;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Response.Cookies.Clear();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect(ResourceStrings.Page_Login);
        }

        public AuthenticationResponse AuthenticateUser(string userName, string password, string url, ISecurityContext securityContext)
        {
            var u = new UserServices().GetByUsernamePassword(userName, SecurityUtils.GetMd5Hash(password));
            var response = new AuthenticationResponse();
            if (u != null)
            {
                if (!u.IsActive)
                {
                    response.IsAuthenticated = false;
                    response.CurrentAccessLevel = AccessLevels.NOACCESS;
                    response.Message = "Your account has been marked as inactive.";
                }
                else
                {
                    CreateAuthenticationTicket(u.UserName, u.ID.ToString(), DateTime.Now.AddMinutes(240), url);
                    u.LastLoginDate = DateTime.Now;
                    securityContext.CurrentUser = u;
                    securityContext.IsAuthenticated = true;
                    response.IsAuthenticated = true;
                    response.CurrentAccessLevel = AccessLevels.FULLACCESS;
                    //new UserRepository().SaveOrUpdate(u);
                    //UserServices.LoadUserPreferences(SecurityContextManager.Current.CurrentUser);
                }
            }
            else
            {
                securityContext.IsAuthenticated = false;
                response.IsAuthenticated = false;
                securityContext.CurrentUser = null;
                response.Message = "Invalid username or password.  Please try again.";
            }

            return response;
        }

        private static void CreateAuthenticationTicket(string username, string userData, DateTime expiration, string url)
        {
            FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, username, DateTime.Now, expiration, true, userData);
            string encryptedCookie = FormsAuthentication.Encrypt(tkt);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedCookie);
            cookie.Expires = tkt.Expiration;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public bool IsAuthenticated
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_IsAuthenticated] != null)
                {
                    return (bool)SessionManager.Current[ResourceStrings.Session_IsAuthenticated];
                }
                else
                {
                    SignOutUser();
                    return false;
                }
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_IsAuthenticated] = value;
            }
        }

        public IBaseApplicationPage CurrentPage
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentPage] != null)
                {
                    return (IdeaSeedCMS.Core.Domain.Page)SessionManager.Current[ResourceStrings.Session_CurrentPage];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentPage] = value;
            }
        }

        public IBaseUser CurrentUser
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentUser] != null)
                {
                    return (User)SessionManager.Current[ResourceStrings.Session_CurrentUser];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentUser] = value;
            }
        }

        public IBaseEntity CurrentItem
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentItem] != null)
                {
                    return (Item)SessionManager.Current[ResourceStrings.Session_CurrentItem];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentItem] = value;
            }
        }

        public string BaseURL
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentBaseURL] != null)
                {
                    return SessionManager.Current[ResourceStrings.Session_CurrentBaseURL].ToString();
                }
                else
                {
                    SessionManager.Current[ResourceStrings.Session_CurrentBaseURL] = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
                    return SessionManager.Current[ResourceStrings.Session_CurrentBaseURL].ToString();
                }
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentBaseURL] = value;
            }
        }

        public string PreviousURL
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentPreviousURL] != null)
                {
                    return SessionManager.Current[ResourceStrings.Session_CurrentPreviousURL].ToString();
                }
                return ResourceStrings.Page_Default;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentPreviousURL] = value;
            }
        }

        public string CurrentURL
        {
            get
            {
                return HttpContext.Current.Request.Url.ToString();
            }
        }

        public AccessLevels CurrentAccessLevel
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentAccessLevel] != null)
                {
                    return (AccessLevels)SessionManager.Current[ResourceStrings.Session_CurrentAccessLevel];
                }
                return AccessLevels.NOACCESS;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentAccessLevel] = value;
            }
        }

        public Application CurrentManagedApplication
        {
            get
            {
                if (SessionManager.Current["CurrentManagedApplication"] != null)
                {
                    return (Application)SessionManager.Current["CurrentManagedApplication"];
                }
                return null;
            }
            set
            {
                SessionManager.Current["CurrentManagedApplication"] = value;
            }
        }

        public event EventHandler SignOut;

        protected virtual void OnSignOut(EventArgs e)
        {
            var handler = this.SignOut;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public ApplicationContext AppContext
        {
            get;
            set;
        }

        public void SignOutUser()
        {
            SecurityContextManager.Current = null;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Response.Cookies.Clear();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect(ResourceStrings.Page_Login);
        }
    }
}
