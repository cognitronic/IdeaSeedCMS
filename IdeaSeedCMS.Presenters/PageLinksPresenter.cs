using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Presenters.ViewInterfaces;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Security;
using IdeaSeed.Core;
using System.Configuration;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core;

namespace IdeaSeedCMS.Presenters
{
    public class PageLinksPresenter : Presenter
    {
        IPageLinksView _view;

        public PageLinksPresenter(IPageLinksView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IPageLinksView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.OnGetItems += new EventHandler<CWMGridArg>(_view_OnGetItems);
        }

        void _view_OnGetItems(object sender, CWMGridArg e)
        {
            GetItemResults(e);
        }

        void GetItemResults(CWMGridArg e)
        {
            _view.Links = ((Page)SecurityContextManager.Current.CurrentPage).Links;
            _view.LoadResultSet(e);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {

        }

        void _view_LoadView(object sender, EventArgs e)
        {
            
        }

        void _view_InitView(object sender, EventArgs e)
        {

        }

        
    }
}
