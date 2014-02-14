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
    [PresenterType(typeof(StaffProfilePresenter))]
    public partial class StaffProfileView : BaseWebUserControl, IStaffProfileView
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

        #region IStaffProfileView Members

        public string Links
        {
            get
            {
                return divLinks.InnerHtml;
            }
            set
            {
                divLinks.InnerHtml = value;
            }
        }

        public string ProfileContent
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

        #endregion
    }
}