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
    public class InternalContentPresenter : Presenter
    {
        IInternalContentView _view;

        public InternalContentPresenter(IInternalContentView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IInternalContentView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {

        }

        void _view_LoadView(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            var item = ((Page)SecurityContextManager.Current.CurrentPage).Content[0];
            
            sb.Append("<div id='mainContent' class='grid_16'>");
           
            sb.Append("<h1>");
            sb.Append(item.Title);
            sb.Append("</h1>");
            sb.Append("<h2>");
            sb.Append(item.SubTitle);
            sb.Append("</h2>");
            sb.Append("<div>");
            sb.Append(item.PageData);
            sb.Append("<br />");
            sb.Append("</div></div>");
            _view.ContentHTML = sb.ToString();
        }

        void _view_InitView(object sender, EventArgs e)
        {

        }
    }
}
