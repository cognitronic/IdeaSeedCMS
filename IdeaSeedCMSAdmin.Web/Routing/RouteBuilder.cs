using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using IdeaSeedCMS.Core.Domain;
using System.Collections.Generic;
using System.Web.Routing;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core;

namespace IdeaSeedCMSAdmin.Web.Routing
{
    public class RouteBuilder
    {
        public RouteCollection Routes { get; private set; }
        public RouteBuilder(RouteCollection routes)
        {
            Routes = routes;
        }

        public void Run()
        {

            Route defaultRoute = new Route("Home", new DefaultRouteHandler("", "Home"));
            Routes.Add(defaultRoute);

            BuildPageRoutes();
            BuildCampaignRoutes();

            defaultRoute = new Route("", new DefaultRouteHandler("", "Home"));
            Routes.Add(defaultRoute);

        }

        public void BuildPageRoutes()
        {
            Route route = new Route("Pages/{id}/{action}", new PagesRouteHandler("default"));
            route.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            route.Constraints = new RouteValueDictionary { { "action", @"^\D+" } };
            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("id", route.Constraints["id"]);
            routeValues.Add("action", route.Constraints["action"]);
            route.DataTokens = routeValues;
            Routes.Add(route);

            route = new Route("Pages/New", new PagesRouteHandler("new"));
            Routes.Add(route);

            route = new Route("Pages", new DefaultRouteHandler("", "~/Pages.aspx"));
            Routes.Add(route);

            route = new Route("Schedules/{id}", new ScheduleRouteHandler("default"));
            route.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            routeValues = new RouteValueDictionary();
            routeValues.Add("id", route.Constraints["id"]);
            route.DataTokens = routeValues;
            Routes.Add(route);

            route = new Route("Schedules/New", new ScheduleRouteHandler("default"));
            routeValues = new RouteValueDictionary();
            routeValues.Add("new", "New");
            route.DataTokens = routeValues;
            Routes.Add(route);

            route = new Route("Schedules", new SchedulesRouteHandler("Schedules", "~/Schedules.aspx"));
            Routes.Add(route);

            route = new Route("News/{id}", new BlogRouteHandler("default"));
            route.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            routeValues = new RouteValueDictionary();
            routeValues.Add("id", route.Constraints["id"]);
            route.DataTokens = routeValues;
            Routes.Add(route);

            route = new Route("News/New", new BlogRouteHandler("default"));
            routeValues = new RouteValueDictionary();
            routeValues.Add("new", "New");
            route.DataTokens = routeValues;
            Routes.Add(route);

            route = new Route("News", new DefaultRouteHandler("News", "~/Default.aspx"));
            Routes.Add(route);

            route = new Route("Document-Library/{id}/{action}", new DocumentLibraryRouteHandler("default"));
            route.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            route.Constraints = new RouteValueDictionary { { "action", @"^\D+" } };
            routeValues = new RouteValueDictionary();
            routeValues.Add("id", route.Constraints["id"]);
            routeValues.Add("action", route.Constraints["action"]);
            route.DataTokens = routeValues;
            Routes.Add(route);

            route = new Route("Document-Library/New", new DocumentLibraryRouteHandler("default"));
            route.DataTokens = routeValues;
            Routes.Add(route);

            route = new Route("Document-Library", new DefaultRouteHandler("Document-Library", "~/Default.aspx"));
            Routes.Add(route);

        }

        public void BuildCampaignRoutes()
        {
            Route route = new Route("Campaign-Manager/Dashboard", new CampaignManagerRouteHandler("Campaign-Manager/Dashboard", ResourceStrings.CampaignManager_Dashboard));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Templates", new CampaignManagerRouteHandler("Campaign-Manager/Templates", ResourceStrings.CampaignManager_Templates));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Subscribers", new CampaignManagerRouteHandler("Campaign-Manager/Subscribers", ResourceStrings.CampaignManager_Subscribers));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Tags", new CampaignManagerRouteHandler("Campaign-Manager/Tags", ResourceStrings.CampaignManager_Tags));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Template", new CampaignManagerRouteHandler("Campaign-Manager/Template", ResourceStrings.CampaignManager_Template));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Campaign-Viewer", new CampaignManagerRouteHandler("Campaign-Manager/Viewer", ResourceStrings.CampaignManager_Viewer));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Forward-To-A-Friend", new CampaignManagerRouteHandler("Campaign-Manager/Forward-Friend", ResourceStrings.CampaignManager_ForwardFriend));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Import-Subscribers", new CampaignManagerRouteHandler("Campaign-Manager/Import-Subscribers", ResourceStrings.CampaignManager_ImportSubscribers));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Manage-Subscribers-Tags", new CampaignManagerRouteHandler("Campaign-Manager/Manage-Subscribers-Tags", ResourceStrings.CampaignManager_ManageSubscribersTags));
            Routes.Add(route);

            route = new Route("Campaign-Manager/New-Campaign", new CampaignManagerRouteHandler("Campaign-Manager/New-Campaign", ResourceStrings.CampaignManager_NewCampaign));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Add-Subscribers/{id}/{action}", new CampaignManagerRouteHandler("Campaign-Manager/Add-Subscribers", ResourceStrings.CampaignManager_AddSubscribers_Tags));
            route.Constraints = new RouteValueDictionary { { "id", @"^\D+" } };
            route.Constraints = new RouteValueDictionary { { "action", @"^\D+" } };
            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("id", route.Constraints["id"]);
            routeValues.Add("action", route.Constraints["action"]);
            route.DataTokens = routeValues;
            Routes.Add(route);

            route = new Route("Campaign-Manager/Add-Subscribers", new CampaignManagerRouteHandler("Campaign-Manager/Add-Subscribers", ResourceStrings.CampaignManager_AddSubscribers_Tags));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Coupons/{id}", new CampaignManagerRouteHandler("Campaign-Manager/New-Coupons", ResourceStrings.CampaignManager_NewCoupon));
            route.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            routeValues = new RouteValueDictionary();
            routeValues.Add("id", route.Constraints["id"]);
            route.DataTokens = routeValues;
            Routes.Add(route);

            route = new Route("Campaign-Manager/New-Coupon", new CampaignManagerRouteHandler("Campaign-Manager/New-Coupon", ResourceStrings.CampaignManager_NewCoupon));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Import-Coupon-Codes/{id}", new CampaignManagerRouteHandler("Campaign-Manager/Import-Coupon-Codes", ResourceStrings.CampaignManager_Import_Coupon_Codes));
            route.Constraints = new RouteValueDictionary { { "id", @"^\d+" } };
            routeValues = new RouteValueDictionary();
            routeValues.Add("id", route.Constraints["id"]);
            route.DataTokens = routeValues;
            Routes.Add(route);

            route = new Route("Campaign-Manager/Coupons", new CampaignManagerRouteHandler("Campaign-Manager/Coupons", ResourceStrings.CampaignManager_Coupons));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Manage-Coupon-Codes", new CampaignManagerRouteHandler("Campaign-Manager/Manage-Coupon-Codes", ResourceStrings.CampaignManager_Manage_Coupon_Codes));
            Routes.Add(route);

            route = new Route("Campaign-Manager/Campaign-Manager-Settings", new CampaignManagerRouteHandler("Campaign-Manager-Settings", ResourceStrings.CampaignManager_Campaign_Manager_Settings));
            Routes.Add(route);
        }
    }
}
