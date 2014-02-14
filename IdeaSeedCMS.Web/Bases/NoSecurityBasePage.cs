using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using IdeaSeed.Web;
using IdeaSeed.Core;
using IdeaSeed.Core.Utils;
using IdeaSeedCMS.Web.Utils;
using IdeaSeedCMS.Web.Security;
using IdeaSeedCMS.Core;
using IdeaSeedCMS.Core.Security;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Services;

namespace IdeaSeedCMS.Web.Bases
{
    public class NoSecurityBasePage : System.Web.UI.Page, IView
    {
        #region Declarations
        protected const string TITLE_TEXT = "{~ CWM ~} ";

        public event EventHandler InitView;
        public event EventHandler LoadView;
        public event EventHandler UnloadView;
        #endregion

        #region Properties
        public string ViewTitle { get; set; }
        public string Message { get; set; }

        #endregion

        #region Events

        #region Overriden Events
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            //if (!HttpPageHelper.IsValidRequest)
            //{
            //    HttpContext.Current.Response.Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute(ResourceStrings.Page_Default));
            //}

            //try
            //{
            //    if (SecurityContextManager.Current.CurrentURL != SecurityContextManager.Current.BaseURL + HttpContext.Current.Request.UrlReferrer.AbsolutePath)
            //    {
            //        SecurityContextManager.Current.PreviousURL = SecurityContextManager.Current.BaseURL + HttpContext.Current.Request.UrlReferrer.AbsolutePath;
            //    }
            //}
            //catch (Exception exc)
            //{

            //}
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //Security Checking
            //if (SecurityContextManager.Current == null || SecurityContextManager.Current.CurrentUser.ID == 0)
            //{
            //    new WebSecurityContext().SignOutUser();
            //}

            //if (HttpPageHelper.CurrentPage != null)
            //{
            //    if (SecurityContextManager.Current != null)
            //    {
            //        SecurityContextManager.Current.CurrentPage = HttpPageHelper.CurrentPage;
            //        SecurityContextManager.Current.CurrentAccessLevel = (AccessLevels)new SecurityServices().GetCurrentPageAccessLevel(SecurityContextManager.Current);
            //        if (HttpPageHelper.CurrentItem != null)
            //            SessionManager.Current[ResourceStrings.Session_CurrentItem] = HttpPageHelper.CurrentItem;
            //    }
            //}
            InitializeSession();
            InitializeSecurityContextManagerValues();
        }

        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);
        }

        protected override void OnSaveStateComplete(EventArgs e)
        {
            base.OnSaveStateComplete(e);

        }

        #endregion


        #endregion

        #region Methods
        public void InitializeSession()
        {
            if (SessionManager.Current == null)
            {
                SessionManager.Current = new WebSessionProvider();
            }
            if (SecurityContextManager.Current == null)
            {
                SecurityContextManager.Current = new WebSecurityContext();
            }
        }

        public void InitializeSecurityContextManagerValues()
        {
            if (HttpPageHelper.CurrentPage != null)
            {
                if (SecurityContextManager.Current != null)
                {
                    SecurityContextManager
                        .Current
                        .CurrentPage = HttpPageHelper.CurrentPage;
                    if (HttpPageHelper.CurrentItem != null)
                        SessionManager.Current[ResourceStrings.Session_CurrentItem] = HttpPageHelper.CurrentItem;
                    if (HttpPageHelper.CurrentUser != null)
                        SecurityContextManager
                            .Current
                            .CurrentUser = HttpPageHelper.CurrentUser;
                    else
                        SecurityContextManager
                            .Current
                            .CurrentUser = null;
                }
            }
        }
        #endregion

        #region MVP Hookup Code
        protected T RegisterView<T>() where T : Presenter
        {
            return PresentationManager.RegisterView<T>(typeof(T), this, new WebSessionProvider());
        }

        protected void SelfRegister(System.Web.UI.Page page)
        {
            if (page != null && page is IView)
            {
                object[] attributes = page.GetType().GetCustomAttributes(typeof(PresenterTypeAttribute), true);

                if (attributes != null && attributes.Length > 0)
                {
                    foreach (Attribute viewAttribute in attributes)
                    {
                        if (viewAttribute is PresenterTypeAttribute)
                        {
                            PresentationManager.RegisterView((viewAttribute as PresenterTypeAttribute).PresenterType, page as IView, new WebSessionProvider());
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
        #endregion
    }
}
