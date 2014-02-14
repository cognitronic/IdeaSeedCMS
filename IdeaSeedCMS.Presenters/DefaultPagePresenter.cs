using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Presenters.ViewInterfaces;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Security;
using IdeaSeed.Core;
using IdeaSeedCMS.Services;

namespace IdeaSeedCMS.Presenters
{
    public class DefaultPagePresenter : Presenter
    {
        IDefaultPageView _view;

        public DefaultPagePresenter(IDefaultPageView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IDefaultPageView>();
            _view.OnLoadData += new EventHandler(_view_OnLoadData);
        }

        void _view_OnLoadData(object sender, EventArgs e)
        {
            var views = new PageViewServices().GetPageApplicationViewsByPageID(SecurityContextManager.Current.CurrentPage.ID);
            var list = new List<ApplicationView>();
            foreach (var view in views)
            {
                if (view.ApplicationView != null)
                {
                    switch (view.ViewLayout)
                    { 
                        case ApplicationViewLayout.MAIN:
                            _view.MainContentViews.Add(view);
                            break;
                    }
                }
            }
        }
    }
}
