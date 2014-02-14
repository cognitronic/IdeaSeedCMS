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
    public class SchedulePresenter : Presenter
    {
        IScheduleView _view;

        public SchedulePresenter(IScheduleView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IScheduleView>();
            _view.OnLoadData += new EventHandler(_view_OnLoadData);
        }

        void _view_OnLoadData(object sender, EventArgs e)
        {
            var views = new AdminApplicationViewServices().GetByPageType((int)PageType.SCHEDULE_EVENT);
            foreach (var view in views)
            {
                _view.MainContentViews.Add(view);
            }
        }
    }
}
