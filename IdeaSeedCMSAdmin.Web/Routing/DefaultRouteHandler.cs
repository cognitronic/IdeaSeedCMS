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
    public class DefaultRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public string ActualPath { get; set; }

        public DefaultRouteHandler(string virtualPath, string actualPath)
        {
            this.VirtualPath = virtualPath;
            this.ActualPath = actualPath;
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            HttpPageHelper.CurrentItem = null;
            var p = new IdeaSeedCMS.Core.Domain.Page();
            if (HttpPageHelper.CurrentUser == null)
                p = new PageServices().GetByNameAccessLevel(VirtualPath.Replace("-", " "), 60, Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]));
            else
                p = new PageServices().GetByNameAccessLevel(VirtualPath, HttpPageHelper.CurrentUser.AccessLevel, Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]));
            HttpPageHelper.CurrentPage = p;
            if (p != null)
            {
                var item = new Item();
                item.Description = p.Name;
                item.Name = p.Name;
                item.SEOTitle = p.SEOTitle;
                item.ItemReference = item;
                HttpPageHelper.CurrentItem = item;
            }
            AdminBasePage page;

            page = (AdminBasePage)BuildManager.CreateInstanceFromVirtualPath(ActualPath, typeof(System.Web.UI.Page));

            HttpPageHelper.IsValidRequest = true;
            return page;
        }

        #endregion
    }
}
