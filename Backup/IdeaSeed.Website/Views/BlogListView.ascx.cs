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
    [PresenterType(typeof(BlogListPresenter))]
    public partial class BlogListView : BaseWebUserControl, IBlogListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, e);
            }
        }

        public event EventHandler LoadView;

        public event EventHandler OnLinkClicked;

        #region IBlogListView Members

        public string BlogHTML
        {
            get
            {
                return divContent.InnerHtml;
            }
            set
            {
                divContent.InnerHtml = value;
            }
        }

        public string Links
        {
            get;
            set;
        }

        #endregion
    }
}