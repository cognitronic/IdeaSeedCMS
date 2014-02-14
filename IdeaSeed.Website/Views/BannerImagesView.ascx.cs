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
    [PresenterType(typeof(BannerImagesPresenter))]
    public partial class BannerImagesView : BaseWebUserControl, IBannerImagesView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
        }
        public new event EventHandler LoadView;
        #region IBannerImagesView Members

        public string BannerHTML
        {
            get
            {
                return divImages.InnerHtml;
            }
            set
            {
                divImages.InnerHtml = value;
            }
        }

        #endregion
    }
}