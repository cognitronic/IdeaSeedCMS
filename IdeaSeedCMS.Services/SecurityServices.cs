using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Persistence.Repositories;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Security;

namespace IdeaSeedCMS.Services
{
    public class SecurityServices
    {
        #region ISecurityServices Members

        public IdeaSeedCMS.Core.Security.AuthenticationResponse AuthenticateUser(string userName, string password, string url, ISecurityContext securityContext)
        {
            var u = new UserRepository().GetByEmailPassword(userName, SecurityUtils.GetMd5Hash(password));
            var response = new IdeaSeedCMS.Core.Security.AuthenticationResponse();
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
                    CreateAuthenticationTicket(u.UserName, u.ID.ToString(), DateTime.Now.AddMinutes(60), url);
                    u.LastLoginDate = DateTime.Now;
                    SecurityContextManager.Current.CurrentUser = u;
                    securityContext.CurrentUser = u;
                    SessionManager.Current["Current_User"] = u;
                    securityContext.IsAuthenticated = true;
                    response.IsAuthenticated = true;
                    response.CurrentAccessLevel = AccessLevels.FULLACCESS;

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
            //FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, username, DateTime.Now, expiration, true, userData);
            //string encryptedCookie = FormsAuthentication.Encrypt(tkt);
            //HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedCookie);
            //cookie.Expires = tkt.Expiration;
            //cookie.Path = FormsAuthentication.FormsCookiePath;
            //HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void Signout()
        {
            var response = new IdeaSeedCMS.Core.Security.AuthenticationResponse();
            SecurityContextManager.Current.IsAuthenticated = false;
            response.IsAuthenticated = false;
            SecurityContextManager.Current.CurrentUser = null;
        }

        public void CreateAuthenticationTicket()
        {
            throw new NotImplementedException();
        }

        public int GetCurrentPageAccessLevel(ISecurityContext securityContext)
        {
            //var pageUser = new PageRepository().getb(securityContext.CurrentPage.ID, securityContext.CurrentUser.ID);
            //if there is page level security, return access level
            //if (pageUser != null)
            //{
            //    return pageUser.AccessLevel;
            //}
            ////else, loop through the current user's module access and if user has access to the current page module, return access level
            //foreach (var m in securityContext.CurrentUser.UserModules)
            //{
            //    if (securityContext.CurrentPage.ModuleID == m.ModuleID)
            //    {
            //        return m.AccessLevel;
            //    }
            //}
            //otherwise no access.
            return (int)AccessLevels.NOACCESS;
        }

        public static bool IsUsernameAvailable(string username)
        {
            var u = new UserRepository().GetByEmail(username);
            if (u == null || u.ID < 1)
                return true;
            return false;
        }


        #endregion
    }
}
