using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using IdeaSeedCMSAdmin.Presenters;
using IdeaSeed.Core;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMSAdmin.Presenters.ViewInterfaces;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Domain.Interfaces;
using IdeaSeedCMS.Core.Security;

namespace IdeaSeedCMSAdmin.Website
{
    [PresenterType(typeof(SchedulePresenter))]
    public partial class Schedule : AdminBasePage, IScheduleView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadViewControls(Master.MainContent);
            Master.Page.Title = "Schedules";
        }

        private void LoadViewControls(ContentPlaceHolder mainContent)
        {
            base.SelfRegister(HttpContext.Current.Handler as System.Web.UI.Page);
            if (this.OnLoadData != null)
            {
                this.OnLoadData(this, EventArgs.Empty);
            }
            foreach (var view in MainContentViews)
            {
                Control c = LoadControl(view.ViewPath);
                mainContent.Controls.Add(c);
            }
        }

        #region IPageManagerView Members

        public event EventHandler OnLoadData;

        private IList<IAdminApplicationView> _mainContentViews = new List<IAdminApplicationView>();
        public IList<IAdminApplicationView> MainContentViews
        {
            get
            {
                return _mainContentViews;
            }
            set
            {
                _mainContentViews = value;
            }
        }

        #endregion
    }
}