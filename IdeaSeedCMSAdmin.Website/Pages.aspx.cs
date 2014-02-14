using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMS.Core;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Services;
using IdeaSeed.Core;
using Telerik.Web.UI;
using IdeaSeedCMS.Core.Security;
using System.Configuration;

namespace IdeaSeedCMSAdmin.Website
{
    public partial class Pages : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = "Page Management";
            if (!IsPostBack)
            {
                LoadPages(true);
                rtlPages.ExpandAllItems();
            }
        }

        protected void AddRootPageClicked(object o, EventArgs e)
        {
            Response.Redirect("/Pages/New");
        }

        protected void EditClicked(object o, EventArgs e)
        {
            if (!string.IsNullOrEmpty(((IdeaSeed.Web.UI.LinkButton)o).Attributes["externalURL"]))
            {
                Response.Redirect(((IdeaSeed.Web.UI.LinkButton)o).Attributes["externalURL"]);
            }
            else
            {
                Response.Redirect("/Pages/" + ((IdeaSeed.Web.UI.LinkButton)o).Attributes["itemID"] + "/edit");
            }
        }

        protected void DeleteClicked(object o, EventArgs e)
        {
            var p = new PageServices().GetByID(Convert.ToInt16(((IdeaSeed.Web.UI.LinkButton)o).Attributes["itemID"]));
            if (p != null)
                p.MarkedForDeletion = true;
                p.Name = p.Name + "_del_" + DateTime.Now.ToString();
                p.IsActive = false;
                p.LastUpdated = DateTime.Now;
                p.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                p.NavigationTypeID = (int)NavigationType.NONE;
                new PageServices().Save(p);
            LoadPages(true);
            //HttpContext.Current.Cache.Remove(ResourceStrings.Cache_PrimaryPublicNavData);
            //Context.Cache.Insert(ResourceStrings.Cache_PrimaryPublicNavData, new PageServices().GetByNavigationTypeID(1, Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"])));
        }

        protected void AddSubPageClicked(object o, EventArgs e)
        {
            Response.Redirect("/Pages/" + ((IdeaSeed.Web.UI.LinkButton)o).Attributes["itemID"] + "/add");
        }

        protected void NeedDataSource(object o, TreeListNeedDataSourceEventArgs e)
        {
            LoadPages(false);
        }

        private void LoadPages(bool bindData)
        {
            if (SecurityContextManager.Current.CurrentManagedApplication != null)
            {
                rtlPages.DataSource = new PageServices().GetByApplicationID(SecurityContextManager.Current.CurrentManagedApplication.ID);
                if (bindData)
                {
                    rtlPages.DataBind();
                }
            }
        }
    }
}