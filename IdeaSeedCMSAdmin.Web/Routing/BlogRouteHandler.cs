using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Configuration;
using System.Web.Compilation;
using System.Web.UI;
using System.Collections;
using IdeaSeedCMSAdmin.Web.Utils;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core;
using IdeaSeedCMSAdmin.Web.Bases;

namespace IdeaSeedCMSAdmin.Web.Routing
{
    public class BlogRouteHandler  : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public BlogRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string id = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["id"]);
            string isnew = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["new"]);

            HttpPageHelper.CurrentItem = null;
            if (!string.IsNullOrEmpty(id))
            {
                var p = new BlogServices().GetByID(Convert.ToInt32(id));

                var item = new Item();
                item.Description = p.Title;
                item.Name = p.Title;
                item.ItemReference = p;
                item.SEOTitle = p.Title;
                item.SEODescription = p.SEODescription;
                item.SEOKeywords = p.SEOKeywords;
                HttpPageHelper.CurrentItem = item;
            }
            else
            {
                var item = new Item();
                item.Description = "New Blog";
                item.Name = "New Blog";
                item.SEOTitle = "New Blog";
                item.ItemReference = new Blog();
                HttpPageHelper.CurrentItem = item;
            }
            var cp = new PageServices().GetByNameAccessLevel("News", 60, Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]));
            HttpPageHelper.CurrentPage = cp;
            AdminBasePage page;

            page = (AdminBasePage)BuildManager.CreateInstanceFromVirtualPath("~/News.aspx", typeof(System.Web.UI.Page));

            HttpPageHelper.IsValidRequest = true;
            return page;
        }

        #endregion
    }
}
