using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Security;
using IdeaSeed.Core;
using IdeaSeedCMS.Core;
//using IdeaSeedCMSAdmin.Web.Utils;

namespace IdeaSeedCMSAdmin.Web.Bases
{
    public class BaseMasterPage : System.Web.UI.MasterPage
    {
        protected override void OnLoad(EventArgs e)
        {
            if (SessionManager.Current != null)
            {
                //BuildNav();
                //HttpPageHelper.CurrentWebsite = (Website)SecurityContextManager.Current.CurrentWebsite;
            }
            base.OnLoad(e);
        }

        public void BuildNav()
        {
            var sb = new StringBuilder();
            var list = (Cache[ResourceStrings.Cache_PrimaryPublicNavData] as IList<Page>).OrderBy(o => o.SortOrder);
            sb.Append("<div id='main_navigation' class='main-menu '><ul>");
            foreach (var page in list)
            {
                sb.Append("<li>");
                string[] routes = page.URLRoute.ToLower().Split('/');
                sb.Append("<a href='");
                if (page.Name.Equals("Our Trainers") || page.Name.Equals("What We Offer"))
                {
                    sb.Append(SecurityContextManager.Current.CurrentURL);
                }
                else
                {
                    sb.Append(Request.Url.GetLeftPart(UriPartial.Authority));
                    sb.Append("/");
                    sb.Append(page.Name.Replace(" ", "-"));
                }
                sb.Append("' alt='");
                sb.Append(page.Name);
                sb.Append("'>");
                sb.Append(page.DisplayName);
                sb.Append("</a>");
                if (page.ChildPages.Count > 0)
                {
                    sb.Append("<ul>");
                    foreach (var kid in page.ChildPages)
                    {
                        sb.Append("<li><a href='");
                        sb.Append(Request.Url.GetLeftPart(UriPartial.Authority));
                        sb.Append("/");
                        sb.Append(page.Name.Replace(" ", "-"));
                        sb.Append("/");
                        sb.Append(kid.Name.Replace(" ", "-"));
                        sb.Append("'>");
                        sb.Append(kid.DisplayName);
                        sb.Append("</a></li>");
                    }
                    sb.Append("</ul>");
                }
                else
                {
                    sb.Append("</li>");
                }
            }
            sb.Append("</ul></div>");

            MasterPageContext.PrimaryNavText = sb.ToString();
            //BuildSubNav((int)SecurityContextManager.Current.CurrentPage.ParentID);
        }

        public void BuildSubNav(int parentID)
        {
            //var list = new PageServices().GetSubPagesByParentID(parentID).OrderBy(o => o.LoadOrder);
            //if (list != null)
            //{
            //    var sb = new StringBuilder();
            //    sb.Append("<div id='tabs'><div class='container'><ul>");
            //    foreach (var page in list)
            //    {
            //        string[] routes = page.URLRoute.ToLower().Split('/');
            //        if (routes[routes.Length - 1] == HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Length - 1].Replace("/", "").ToLower() || routes[routes.Length - 1] == "page")
            //        {
            //            sb.Append("<li>");
            //            sb.Append("<a href='");
            //            sb.Append(Request.Url.GetLeftPart(UriPartial.Authority));
            //            sb.Append("/");
            //            sb.Append(page.URLRoute);
            //            sb.Append("' alt='");
            //            sb.Append(page.Name);
            //            sb.Append("' class='current'><span>");
            //            sb.Append(page.Name);
            //            sb.Append("</span></a>");
            //            sb.Append("</li>");
            //        }
            //        else
            //        {
            //            sb.Append("<li>");
            //            sb.Append("<a href='");
            //            sb.Append(Request.Url.GetLeftPart(UriPartial.Authority));
            //            sb.Append("/");
            //            sb.Append(page.URLRoute);
            //            sb.Append("' alt='");
            //            sb.Append(page.Name);
            //            sb.Append("'><span>");
            //            sb.Append(page.Name);
            //            sb.Append("</span></a>");
            //            sb.Append("</li>");
            //        }
            //    }
            //    sb.Append("</ul></div></div>");
            //    MasterPageContext.SubNavText = sb.ToString();
            //}
        }
    }
}
