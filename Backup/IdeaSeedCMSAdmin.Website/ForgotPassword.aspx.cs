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

namespace IdeaSeedCMSAdmin.Website
{
    public partial class ForgotPassword : NoSecurityBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = "Forgot Password";
            if (!IsPostBack)
            {
                divMessage.Visible = false;
                divPassword.Visible = false;
                divPasswordAnswer.Visible = false;
                divEmail.Visible = true;
            }
        }

        protected void VerifyEmailClicked(object o, EventArgs e)
        {

            var u = new UserServices().GetByUserName(tbUsername.Text);
            if (u != null)
            {
                this.EmailCorrect = true;
                this.CurrentUser = u;
            }
            else
            {
                this.EmailCorrect = false;
                this.Message = "Email not found, try again.";
            }
            if (EmailCorrect)
            {
                divEmail.Visible = false;
                divPasswordAnswer.Visible = true;
                lblQuestion.Text = this.CurrentUser.PasswordQuestion;
            }
            else
            {
                divMessage.Visible = true;
            }
        }

        protected void VerifyAnswerClicked(object o, EventArgs e)
        {
            if (this.CurrentUser != null)
            {
                if (this.CurrentUser.PasswordAnswer.ToLower().Equals(this.Answer.ToLower()))
                {
                    this.AnswerCorrect = true;
                }
                else
                {
                    this.AnswerCorrect = false;
                    this.Message = "Incorrect answer, try again.";
                }
            }
            if (AnswerCorrect)
            {
                divPasswordAnswer.Visible = false;
                divMessage.Visible = false;
                divPassword.Visible = true;
            }
            else
            {
                divMessage.Visible = true;
            }
        }

        protected void VerifyPasswordsClicked(object o, EventArgs e)
        {
            var u = new UserServices().GetByUserName(this.Username);
            if (this.Password.Equals(this.ConfirmPassword))
            {
                u.Password = SecurityUtils.GetMd5Hash(this.ConfirmPassword);
                new UserServices().Save(u);
                this.Message = "Password Changed Successfully!<br />Please <a style='display: inline !important;' href='/Login.aspx'>login</a>";
                PasswordMatch = true;
                lbVerifyPasswords.Visible = false;
            }
            else
            {
                this.Message = "Passwords do not match.";
            }

            if (PasswordMatch)
            {
                divPassword.Visible = false;
            }
            divMessage.Visible = true;
        }

        public string Password
        {
            get
            {
                return tbPassword.Text;
            }
            set
            {
                tbPassword.Text = value;
            }
        }

        public string ConfirmPassword
        {
            get
            {
                return tbConfirmPassword.Text;
            }
            set
            {
                tbConfirmPassword.Text = value;
            }
        }

        public string Message
        {
            get
            {
                return lblMessage.Text;
            }
            set
            {
                lblMessage.Text = value;
            }
        }

        public string Answer
        {
            get
            {
                return tbAnswer.Text;
            }
            set
            {
                tbAnswer.Text = value;
            }
        }

        public string Username
        {
            get
            {
                return tbUsername.Text;
            }
            set
            {
                tbUsername.Text = value;
            }
        }

        public bool PasswordMatch
        {
            get;
            set;
        }

        public bool AnswerCorrect
        {
            get;
            set;
        }

        public bool EmailCorrect
        {
            get;
            set;
        }

        public IdeaSeedCMS.Core.Domain.User CurrentUser
        {
            get
            {
                if (Session["FPUser"] != null && ((IdeaSeedCMS.Core.Domain.User)Session["FPUser"]).ID > 0)
                {
                    return ((IdeaSeedCMS.Core.Domain.User)Session["FPUser"]);
                }
                return null;
            }
            set
            {
                Session["FPUser"] = value;
            }
        }
    }
}