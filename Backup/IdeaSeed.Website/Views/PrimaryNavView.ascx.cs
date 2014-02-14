using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdeaSeedCMS.Presenters.ViewInterfaces;
using IdeaSeedCMS.Presenters;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Security;
using IdeaSeed.Core;
using IdeaSeedCMS.Web.Bases;
using IdeaSeedCMS.Core;

namespace IdeaSeed.Website.Views
{
    [PresenterType(typeof(PrimaryNavPresenter))]
    public partial class PrimaryNavView : BaseWebUserControl, IPrimaryNavView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.OnLoadNav != null)
            {
                this.OnLoadNav(this, e);
            }
            rsShare.UrlToShare = SecurityContextManager.Current.CurrentURL;
            if ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage != null)
                rsShare.TitleToShare = ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).SEOTitle;
        }

        protected void NewsletterClicked(object o, EventArgs e)
        {
            Response.Redirect("/Contact");
        }

        #region IPrimaryNavView Members

        public event EventHandler OnLoadNav;

        public event EventHandler OnLinkClicked;

        public string PrimaryNavText
        {
            get
            {
                return navContainer.InnerHtml;
            }
            set
            {
                navContainer.InnerHtml = value;
            }
        }

        #endregion
    }
}