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
    public class StaffProfilePresenter : Presenter
    {
        IStaffProfileView _view;

        public StaffProfilePresenter(IStaffProfileView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IStaffProfileView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {

        }

        void _view_LoadView(object sender, EventArgs e)
        {
            var content = new PageContentServices().GetByPageID(SecurityContextManager.Current.CurrentPage.ID);
            var links = new PageLinkServices().GetByPageID(SecurityContextManager.Current.CurrentPage.ID);
            var image = new StringBuilder();
            image.Append("<p><img src='");
            image.Append(((Page)SecurityContextManager.Current.CurrentPage).HeaderImagePath);
            image.Append("' alt='' width='690px' height='210px'  /></p><h3>");
            image.Append(content.Title);
            image.Append("</h3><h5>");
            image.Append(content.SubTitle);
            image.Append("</h5><hr />");
            _view.ProfileContent = image.ToString() +  content.PageData;
            var sb = new StringBuilder();
            if (links != null && links.Count > 0)
            {
                sb.Append("<ul class='simple-nav'>");
                foreach (var link in links)
                {
                    sb.Append("<li><a href='");
                    sb.Append(link.URL);
                    sb.Append("' target='_blank'>");
                    sb.Append(link.Title);
                    sb.Append("</a></li>");
                }
                sb.Append("</ul>");
            }
            else
            {
                sb.Append("No Links Found");
            }
            _view.Links = sb.ToString();
        }

        void _view_InitView(object sender, EventArgs e)
        {

        }
    }
}
