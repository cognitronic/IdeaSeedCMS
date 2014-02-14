using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Presenters.ViewInterfaces;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Security;
using IdeaSeed.Core;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core;

namespace IdeaSeedCMS.Presenters
{
    public class BannerImagesPresenter : Presenter
    {
        IBannerImagesView _view;

        public BannerImagesPresenter(IBannerImagesView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IBannerImagesView>();
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
            var list = ApplicationContext.BannerImageData;
            foreach (var item in list)
            {
                sb.Append("<div class='slide'>");
                sb.Append("<img src='");
                sb.Append(item.Path);
                sb.Append("' alt='");
                sb.Append(item.ToolTip);
                sb.Append("' width='960px' height='400px' />");
                sb.Append("</div>");
            }
            _view.BannerHTML = sb.ToString();
        }

        void _view_InitView(object sender, EventArgs e)
        {

        }
    }
}
