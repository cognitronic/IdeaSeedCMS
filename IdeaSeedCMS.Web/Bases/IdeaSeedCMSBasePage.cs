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
using Telerik.Web.UI;

namespace IdeaSeedCMS.Web.Bases
{
    public class IdeaSeedCMSBasePage : System.Web.UI.Page, IView
    {
        #region Declarations
        protected const string TITLE_TEXT = "{~ SwoonCMS ~} ";

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
            //if (SecurityContextManager.Current == null || SecurityContextManager.Current.CurrentUser == null || SecurityContextManager.Current.CurrentUser.ID == 0)
            //{
            //    new WebSecurityContext().SignOutUser();
            //}

            //if (!SecurityContextManager.Current.CurrentURL.Contains("Blog"))
            //{
            //    if (((User)SecurityContextManager.Current.CurrentUser).AccessLevel < 60)
            //    {
            //        Response.Redirect("/Blog.aspx");
            //    }
            //}

            if (HttpPageHelper.CurrentPage != null)
            {
                if (SecurityContextManager.Current != null)
                {
                    SecurityContextManager.Current.CurrentPage = HttpPageHelper.CurrentPage;
                    SecurityContextManager.Current.CurrentAccessLevel = (AccessLevels)new SecurityServices().GetCurrentPageAccessLevel(SecurityContextManager.Current);
                    if (HttpPageHelper.CurrentItem != null)
                        SessionManager.Current[ResourceStrings.Session_CurrentItem] = HttpPageHelper.CurrentItem;
                }
            }
            InitializeSession();
            InitializeSecurityContextManagerValues();
        }

        protected override void OnLoad(EventArgs e)
        {
            ApplicationContext.BannerImageData = Cache[ResourceStrings.Cache_BannerImagesData] as IList<BannerImage>;
            base.OnLoad(e);

            //if (SecurityContextManager.Current.CurrentUser == null)
            //    SecurityContextManager.Current.CurrentUser = new UserServices().GetByID(1);
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
                }
            }
        }

        protected void ShowErrorModal(Control page, string message)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "key", "ShowErrorModal('" + message.Replace("\"", "").Replace("\r", "").Replace("\n", "").Replace("'", "") + "');", true);
        }

        protected void SetImagesPath(RadEditor re)
        {
            string[] viewImages;
            string[] uploadImages;
            string[] deleteImages;
            viewImages = new string[] { ConfigurationManager.AppSettings["IMAGEURL"] };
            uploadImages = new string[] { ConfigurationManager.AppSettings["IMAGEURL"] };
            deleteImages = new string[] { ConfigurationManager.AppSettings["IMAGEURL"] };
            re.ImageManager.ViewPaths = viewImages;
            re.ImageManager.UploadPaths = uploadImages;
            re.ImageManager.DeletePaths = deleteImages;
        }

        public string GetUserFullNameByUserID(int userid)
        {
            var u = new UserServices().GetByID(userid);
            if (u != null && u.ID > 0)
            {
                return u.FirstName + " " + u.LastName;
            }
            return "";
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
