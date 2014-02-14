using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Web.Routing;
using System.Web.Routing;
using IdeaSeedCMS.Core;
using IdeaSeedCMS.Core.Security;
using IdeaSeedCMS.Services;
using System.Configuration;

namespace IdeaSeed.Website
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            RouteBuilder builder = new RouteBuilder(RouteTable.Routes);
            builder.Run();

            //Register the newsletter links and message routes.
            CampaignManager.Web.CampaignTrackerURLRoutes routes = new CampaignManager.Web.CampaignTrackerURLRoutes();
            routes.RegisterRoutes(RouteTable.Routes);

            //Context.Cache.Insert(ResourceStrings.Cache_PrimaryPublicNavData, new PageServices().GetByNavigationTypeID(1, Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"])));
            Context.Cache.Insert(ResourceStrings.Cache_BannerImagesData, new BannerImageServices().GetAll());


        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
