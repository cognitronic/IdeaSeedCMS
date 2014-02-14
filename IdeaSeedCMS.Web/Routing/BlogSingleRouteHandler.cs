using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Configuration;
using System.Web.Compilation;
using System.Web.UI;
using System.Collections;
using IdeaSeedCMS.Web.Utils;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core;
using IdeaSeedCMS.Web.Bases;

namespace IdeaSeedCMS.Web.Routing
{
    public class BlogSingleRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public BlogSingleRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string title = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["title"]);

            HttpPageHelper.CurrentItem = null;
            HttpPageHelper.CurrentBlog = null;

            var p = new IdeaSeedCMS.Core.Domain.Page();
            p = new PageServices().GetByNameAccessLevel(VirtualPath, 0, Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]));
            HttpPageHelper.CurrentPage = p;

            var b = new BlogServices().GetByTitle(title.Replace("-", " "));

            var item = new Item();
            item.Description = p.Name;
            item.Name = p.Name;
            item.SEOTitle = b.Title;
            item.SEODescription = b.SEODescription;
            item.SEOKeywords = b.SEOKeywords;
            item.ItemReference = item;
            p.SEODescription = b.SEODescription;
            p.SEOKeywords = b.SEOKeywords;
            p.SEOTitle = b.Title;
            HttpPageHelper.CurrentItem = item;
            HttpPageHelper.CurrentBlog = b;

            IdeaSeedCMSBasePage page;

            page = (IdeaSeedCMSBasePage)BuildManager.CreateInstanceFromVirtualPath(p.URLRoute, typeof(System.Web.UI.Page));

            HttpPageHelper.IsValidRequest = true;
            return page;
        }

        #endregion
    }
}
