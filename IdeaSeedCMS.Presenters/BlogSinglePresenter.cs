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
    public class BlogSinglePresenter : Presenter
    {
        IBlogSingleView _view;

        public BlogSinglePresenter(IBlogSingleView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IBlogSingleView>();
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

            var item = ApplicationContext.CurrentBlog;

            var url = SecurityContextManager.Current.BaseURL + "/Blog/";
            //switch (item.PostType)
            //{
            //    case (int)BlogPostType.ARTS:
            //        url += "Arts/";
            //        break;
            //    case (int)BlogPostType.BUSINESS:
            //        url += "Business/";
            //        break;
            //    case (int)BlogPostType.CITY:
            //        url += "City/";
            //        break;
            //}
            url += item.Title.Replace(" ", "-");

            string fb = "<iframe src='http://www.facebook.com/widgets/like.php?href=" + url + "&amp;layout=standard&amp;show_faces=true&amp;width=300&amp;action=like&amp;font=verdana&amp;colorscheme=light' scrolling='no' frameborder='0' style='border:none; width:300px; height:25px; '></iframe>";

            
            sb.Append("<div id='mainContent' class='grid_9'>");
            sb.Append("<div  class='upperpost'><div class='post postLrg'>");
           
            sb.Append("<h1>");
            sb.Append(item.Title);
            sb.Append("</h1>");
            sb.Append("'<img src='");
            string blogImage = "BLOGIMAGE_" + item.PostType.ToString();
            sb.Append(ConfigurationManager.AppSettings[blogImage]);
            sb.Append("' alt'");
            sb.Append(item.Title);
            sb.Append("' /><div class='meta'><span class='user'>");
            sb.Append(item.BlogUser.FirstName);
            sb.Append(" ");
            sb.Append(item.BlogUser.LastName);
            sb.Append("</span><span class='date'>");
            sb.Append(item.StartDate.ToShortDateString());
            sb.Append("</span><span class='comments'>");
            sb.Append(fb);
            sb.Append("</span></div><br />");
            sb.Append(item.BlogContent);

            sb.Append("<br /><br /><br />");
            sb.Append("</div></div>");
            _view.BlogHTML = sb.ToString();
        }

        void _view_InitView(object sender, EventArgs e)
        {

        }
    }
}
