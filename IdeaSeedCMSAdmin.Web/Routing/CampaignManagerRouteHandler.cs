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
using System.Web.SessionState;

namespace IdeaSeedCMSAdmin.Web.Routing
{
    public class CampaignManagerRouteHandler : IRouteHandler, IRequiresSessionState
    {
        public string VirtualPath { get; set; }

        public string ActualPath { get; set; }

        public CampaignManagerRouteHandler(string virtualPath, string actualPath)
        {
            this.VirtualPath = virtualPath;
            this.ActualPath = actualPath;
        }

        #region IRouteHandler Members;

        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            var p = new PageServices().GetByURLRoute(VirtualPath, Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]));
            HttpPageHelper.CurrentPage = p;
            var page = new System.Web.UI.Page();
            page = (System.Web.UI.Page)BuildManager.CreateInstanceFromVirtualPath(ActualPath, typeof(System.Web.UI.Page));
            HttpPageHelper.IsValidRequest = true;

            return page;
        }
        #endregion
    }
}
