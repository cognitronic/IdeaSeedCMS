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

namespace IdeaSeedCMS.Web.Routing
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

            Route defaultRoute = new Route("Home", new DefaultRouteHandler("Home"));
            Routes.Add(defaultRoute);

            BuildStaffRoutes();
            BuildProgramRoutes();
            //BuildVisitorRoutes();
            //BuildBusinessRoutes();
            //BuildMediaRoutes();
            BuildBlogRoutes();

            defaultRoute = new Route("Contact", new DefaultRouteHandler("Contact"));
            Routes.Add(defaultRoute);

            defaultRoute = new Route("Schedule", new DefaultRouteHandler("Schedule"));
            Routes.Add(defaultRoute);

            defaultRoute = new Route("", new DefaultRouteHandler("Home"));
            Routes.Add(defaultRoute);

        }

        public void BuildStaffRoutes()
        {
            Route route = new Route("Our-Trainers/{staff}", new StaffRouteHandler("Our Trainers"));
            route.Constraints = new RouteValueDictionary { { "staff", @"^\D+" } };
            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("name", route.Constraints["staff"]);
            route.DataTokens = routeValues;
            Routes.Add(route);

            route = new Route("Our-Trainers", new DefaultRouteHandler("Our Trainers"));
            Routes.Add(route);
            
        }

        public void BuildProgramRoutes()
        {
            Route route = new Route("What-We-Offer/{staff}", new StaffRouteHandler("What We Offer"));
            route.Constraints = new RouteValueDictionary { { "staff", @"^\D+" } };
            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add("name", route.Constraints["staff"]);
            route.DataTokens = routeValues;
            Routes.Add(route);

            route = new Route("What-We-Offer", new DefaultRouteHandler("What We Offer"));
            Routes.Add(route);

        }

        public void BuildVisitorRoutes()
        {
            Route route = new Route("Attractions", new DefaultRouteHandler("Attractions"));
            Routes.Add(route);

            route = new Route("American-Graffiti", new DefaultRouteHandler("American Graffiti"));
            Routes.Add(route);
            route = new Route("Arts-Entertainment", new DefaultRouteHandler("Arts Entertainment"));
            Routes.Add(route);
            route = new Route("Nearby-Destinations", new DefaultRouteHandler("Nearby Destinations"));
            Routes.Add(route);
            route = new Route("Modesto-Real-Estate", new DefaultRouteHandler("Modesto Real Estate"));
            Routes.Add(route);
        }

        public void BuildBusinessRoutes()
        {
            Route route = new Route("Agriculture-Agribusiness", new DefaultRouteHandler("Agriculture Agribusiness"));
            Routes.Add(route);

            route = new Route("Business-Directory", new DefaultRouteHandler("Business Directory"));
            Routes.Add(route);
            route = new Route("Support-For-Business", new DefaultRouteHandler("Support For Business"));
            Routes.Add(route);
            route = new Route("Education-Opportunities", new DefaultRouteHandler("Education Opportunities"));
            Routes.Add(route);
        }

        public void BuildMediaRoutes()
        {
            Route route = new Route("Some-Images", new DefaultRouteHandler("Some Images"));
            Routes.Add(route);

            route = new Route("Maybe-Videos", new DefaultRouteHandler("Maybe Videos"));
            Routes.Add(route);
            route = new Route("Events", new DefaultRouteHandler("Events"));
            Routes.Add(route);
            route = new Route("Our-Community", new DefaultRouteHandler("Our Community"));
            Routes.Add(route);
        }

        public void BuildBlogRoutes()
        {
            Route route = new Route("News/{title}", new BlogSingleRouteHandler("News"));
            route.Constraints = new RouteValueDictionary { { "title", @"^\D+" } };
            Routes.Add(route);

            route = new Route("News", new BlogRouteHandler("News"));
            Routes.Add(route);
        }

        public void BuildUtilityRoutes()
        {
            Route loginRoute = new Route("Login", new DefaultRouteHandler("Login"));
            Routes.Add(loginRoute);

        }
    }
}
