using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMSAdmin.Presenters.ViewInterfaces;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Security;
using IdeaSeed.Core;
using IdeaSeedCMS.Services;

namespace IdeaSeedCMSAdmin.Presenters
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
            var views = new AdminApplicationViewServices().GetByPageType(((Page)SecurityContextManager.Current.CurrentPage).PageTypeID);
            foreach (var view in views)
            {
                _view.MainContentViews.Add(view);
            }
        }
    }
}
