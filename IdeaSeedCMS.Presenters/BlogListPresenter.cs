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
    public class BlogListPresenter : Presenter
    {
        IBlogListView _view;

        public BlogListPresenter(IBlogListView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IBlogListView>();
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
            IList<Blog> list = new List<Blog>();
            if ((int)ApplicationContext.CurrentBlogPostType > 0)
            {
                list = new BlogServices().GetByPostType((int)ApplicationContext.CurrentBlogPostType);
            }
            else
            {
                list = new BlogServices().GetAll();
            }
            int i = 0;
            foreach (var item in list)
            {
                i++;
                sb.Append("<div class='inner-content'><h4>");
                sb.Append(item.Title);
                sb.Append("</h4><p>Posted by: <span style='color: #346699;'>");
                sb.Append(item.BlogUser.FirstName);
                sb.Append(" ");
                sb.Append(item.BlogUser.LastName);
                sb.Append("</span> on <span style='color: #346699;'>");
                sb.Append(item.StartDate.ToShortDateString());
                sb.Append("</span></p><p>");
                sb.Append(item.BlogContent);
                sb.Append("</p><div class='horizontal-line'></div><br /></div>");
                if (i == 1)
                {
                    var links = new PageLinkServices().GetByPageID(SecurityContextManager.Current.CurrentPage.ID);
                    //var sblinks = new StringBuilder();
                    if (links != null && links.Count > 0)
                    {
                        sb.Append("<div class='one-fourth last'><p><strong class='colored'>Links</strong></p><ul class='simple-nav'>");
                        foreach (var link in links)
                        {
                            sb.Append("<li><a href='");
                            sb.Append(link.URL);
                            sb.Append("' target='_blank'>");
                            sb.Append(link.Title);
                            sb.Append("</a></li>");
                        }
                        sb.Append("</ul></div>");
                    }
                    else
                    {
                        sb.Append("<div class='one-fourth last'><p><strong class='colored'>Links</strong></p><ul class='simple-nav'><li>No Links Found</li></ul></div>");
                    }
                }
            }
            i = 0;
            _view.BlogHTML = sb.ToString();

            
            //_view.Links = sblinks.ToString();
        }

        void _view_InitView(object sender, EventArgs e)
        {

        }
    }
}
