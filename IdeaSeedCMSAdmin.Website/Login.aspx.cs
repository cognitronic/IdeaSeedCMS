using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using IdeaSeed.Core;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Domain.Interfaces;
using IdeaSeedCMS.Core.Security;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core;


namespace IdeaSeedCMSAdmin.Website
{
    public partial class Login : NoSecurityBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = "Login";
        }

        protected void LoginClicked(object o, EventArgs e)
        {
            string userName = tbUsername.Text;
            string password = tbPassword.Text;

            var response = new SecurityServices().AuthenticateUser(userName, password, "", SecurityContextManager.Current);
            if (response.IsAuthenticated)
            {
                SecurityContextManager.Current.CurrentManagedApplication = new ApplicationServices().GetByID(Convert.ToInt16(this.Master.MasterApplicationDDL.Items[1].Value));
                Response.Redirect(ResourceStrings.Page_Admin_Default);
            }
            else
            {
                lblLoginMessage.Visible = true;
                lblLoginMessage.Text = "Invalid username or password.<br/>Please try again.";
            }
        }

        protected void ForgotPasswordClicked(object o, EventArgs e)
        {
            Response.Redirect(ResourceStrings.Page_ForgotPassword);
        }
    }
}