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
    public class StaffRouteHandler  : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public StaffRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string staff = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["staff"]);

            HttpPageHelper.CurrentItem = null;
            var p = new IdeaSeedCMS.Core.Domain.Page();
            if(HttpPageHelper.CurrentUser == null)
                p = new PageServices().GetByNameAccessLevel(staff.Replace("-", " "), 0, Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]));
            else
                p = new PageServices().GetByNameAccessLevel(staff.Replace("-", " "), HttpPageHelper.CurrentUser.AccessLevel, Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]));
            HttpPageHelper.CurrentPage = p;

            var item = new Item();
            item.Description = p.Name;
            item.Name = p.Name;
            item.SEOTitle = p.SEOTitle;
            item.ItemReference = item;
            HttpPageHelper.CurrentItem = item;

            IdeaSeedCMSBasePage page;

            page = (IdeaSeedCMSBasePage)BuildManager.CreateInstanceFromVirtualPath(p.URLRoute, typeof(System.Web.UI.Page));

            HttpPageHelper.IsValidRequest = true;
            return page;
        }

        #endregion
    }
}
