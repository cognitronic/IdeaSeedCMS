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
    public class PagesRouteHandler  : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public PagesRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string id = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["id"]);
            string action = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["action"]);

            HttpPageHelper.CurrentItem = null;
            var p = new IdeaSeedCMS.Core.Domain.Page();
            AdminBasePage page;
            if (!this.VirtualPath.Equals("new"))
            {
                p = new PageServices().GetByID(Convert.ToInt32(id));
                var item = new Item();
                item.Description = p.Name;
                item.Name = p.Name;
                item.SEOTitle = p.SEOTitle;
                item.ItemReference = p;
                HttpPageHelper.CurrentItem = item;
                page = (AdminBasePage)BuildManager.CreateInstanceFromVirtualPath("~/Default.aspx", typeof(System.Web.UI.Page));
            }
            else
            {
                var item = new Item();
                item.Description = "New Root Page";
                item.Name = "New Root Page";
                item.SEOTitle = "New Root Page";
                item.ItemReference = p;
                HttpPageHelper.CurrentItem = item;
                page = (AdminBasePage)BuildManager.CreateInstanceFromVirtualPath("~/Page.aspx", typeof(System.Web.UI.Page));
            }
            HttpPageHelper.CurrentPage = p;

            

            

           

            HttpPageHelper.IsValidRequest = true;
            return page;
        }

        #endregion
    }
}
