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
    public class ScheduleRouteHandler  : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public ScheduleRouteHandler(string virtualPath)
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
                var p = new ScheduleEventServices().GetByID(Convert.ToInt32(id));

                var item = new Item();
                item.Description = p.Name;
                item.Name = p.Name;
                item.ItemReference = p;
                item.SEOTitle = p.Name;
                HttpPageHelper.CurrentItem = item;
            }
            else
            {
                var item = new Item();
                item.Description = "New Schedule Event";
                item.Name = "New Schedule Event";
                item.SEOTitle = "New Schedule Event";
                item.ItemReference = new ScheduleEvent();
                HttpPageHelper.CurrentItem = item;
            }
            var cp = new PageServices().GetByNameAccessLevel("Schedule", 60, Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"]));
            HttpPageHelper.CurrentPage = cp;
            AdminBasePage page;

            page = (AdminBasePage)BuildManager.CreateInstanceFromVirtualPath("~/Schedule.aspx", typeof(System.Web.UI.Page));

            HttpPageHelper.IsValidRequest = true;
            return page;
        }

        #endregion
    }
}
