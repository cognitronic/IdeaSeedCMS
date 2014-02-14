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
    public class DocumentLibraryRouteHandler  : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public DocumentLibraryRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string id = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["id"]);
            string action = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["action"]);

            HttpPageHelper.CurrentItem = null;
            var p = new IdeaSeedCMS.Core.Domain.DocumentLibrary();
            if (!string.IsNullOrEmpty(id))
            {
                p = new DocumentLibraryServices().GetByID(Convert.ToInt32(id));
            }

            var item = new Item();
            item.Description = p.Name;
            item.Name = p.Name;
            item.SEOTitle = p.Name;
            item.ItemReference = p;
            HttpPageHelper.CurrentItem = item;

            var cp = new PageServices().GetByNameAccessLevel("Document Library", 60, Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]));
            //cp.PageTypeID = (int)PageType.DOCUMENT;
            HttpPageHelper.CurrentPage = cp;

            AdminBasePage page;

            page = (AdminBasePage)BuildManager.CreateInstanceFromVirtualPath("~/DocumentDetails.aspx", typeof(System.Web.UI.Page));

            HttpPageHelper.IsValidRequest = true;
            return page;
        }

        #endregion
    }
}
