using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using IdeaSeedCMSAdmin.Presenters;
using IdeaSeedCMS.Services;
using IdeaSeed.Core;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMSAdmin.Presenters.ViewInterfaces;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Domain.Interfaces;
using IdeaSeedCMS.Core.Security;
using Telerik.Web.UI;

namespace IdeaSeedCMSAdmin.Website
{
    public partial class User : AdminBasePage
    {
        private IdeaSeedCMS.Core.Domain.User SelectedUser
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    var p = new UserServices().GetByID(Convert.ToInt32(Request.QueryString["id"]));
                    if (p != null && p.ID > 0)
                    {
                        return p;
                    }
                    return null;
                }
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUser();
            }
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            SaveUser();
            Response.Redirect("/Users.aspx");
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect("/Users.aspx");
        }

        protected void LoadUser()
        {
            if (SelectedUser != null)
            {
                tbEmail.Text = SelectedUser.Email;
                tbFirstName.Text = SelectedUser.FirstName;
                tbLastName.Text = SelectedUser.LastName;
                cbIsActive.Checked = SelectedUser.IsActive;
                tbQuestion.Text = SelectedUser.PasswordQuestion;
                tbAnswer.Text = SelectedUser.PasswordAnswer;
                ddlRole.SelectedValue = SelectedUser.AccessLevel.ToString();
            }
        }

        private void SaveUser()
        {
            var p = new IdeaSeedCMS.Core.Domain.User();
            if (SelectedUser != null)
            {
                p = SelectedUser;
                if (!string.IsNullOrEmpty(tbPassword.Text))
                {
                    p.Password = SecurityUtils.GetMd5Hash(tbPassword.Text);
                }
            }
            else
            {
                p.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                p.DateCreated = DateTime.Now;
                p.PasswordAnswer = tbPassword.Text;
                p.PasswordLastChangedDate = DateTime.Now;
                p.PasswordQuestion = tbPassword.Text;
                p.MarkedForDeletion = false;
                p.Password = SecurityUtils.GetMd5Hash(tbPassword.Text);
            }
            p.FirstName = tbFirstName.Text;
            p.LastName = tbLastName.Text;
            p.IsActive = cbIsActive.Checked;
            p.LastLoginDate = DateTime.Now;
            p.PasswordAnswer = tbAnswer.Text;
            p.PasswordQuestion = tbQuestion.Text;
            p.LastUpdated = DateTime.Now;
            p.PasswordLastChangedDate = DateTime.Now;
            p.Email = tbEmail.Text;
            p.AccessLevel = Convert.ToInt16(ddlRole.SelectedValue);
            new UserServices().Save(p);
        }
    }
}