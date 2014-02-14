using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdeaSeedCMSAdmin.Web.Bases;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Configuration;
using IdeaSeed.Core.Mail;
using System.Web.UI.HtmlControls;
using IdeaSeed.Web.UI;
using IdeaSeedCMS.Services;
using CampaignManager.Data.Repositories;
using CampaignManager.Core.Domain;
using IdeaSeedCMS.Core.Security;
using IdeaSeedCMS.Core.Domain;

namespace IdeaSeedCMSAdmin.Website.MasterPages
{
    public partial class Main : System.Web.UI.MasterPage
    {
        public IdeaSeed.Web.UI.DropDownList MasterApplicationDDL
        {
            get
            {
                return ddlMainApplication;
            }
        }

        public HtmlGenericControl MasterHeader
        {
            get
            {
                return header;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SecurityContextManager.Current != null && SecurityContextManager.Current.CurrentUser != null && SecurityContextManager.Current.CurrentUser.ID > 0)
            {
                lbLogout.Visible = true;
            }
            else
            {
                lbLogout.Visible = false;
            }
            if (!IsPostBack)
            {
                if (SecurityContextManager.Current.CurrentManagedApplication != null)
                {
                    ddlMainApplication.SelectedValue = SecurityContextManager.Current.CurrentManagedApplication.ID.ToString();
                    lbSelectedSite.NavigateUrl = SecurityContextManager.Current.CurrentManagedApplication.Domain;
                }
            }
        }

        protected void ApplicationChanged(object o, EventArgs e)
        { 
            if(!string.IsNullOrEmpty(ddlMainApplication.SelectedValue))
                SecurityContextManager.Current.CurrentManagedApplication = new ApplicationServices().GetByID(Convert.ToInt16(ddlMainApplication.SelectedValue));
        }

        protected void LogoutClicked(object o, EventArgs e)
        {
            if (SecurityContextManager.Current != null)
                SecurityContextManager.Current.SignOutUser();
            else
                Response.Redirect(IdeaSeedCMS.Core.ResourceStrings.Page_Login);
        }

        public ContentPlaceHolder MainContent
        {
            get
            {
                return cpMainContent;
            }
        }

    }
}