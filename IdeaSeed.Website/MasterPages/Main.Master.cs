using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdeaSeedCMS.Web.Bases;
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
using Telerik.Web.UI;

namespace IdeaSeed.Website.MasterPages
{
    public partial class Main : BaseMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                lblCopy.Text = DateTime.Now.Year.ToString();
                lblNewsletterMessage.Visible = false;
        }

        public Views.PrimaryNavView PrimaryNavView
        {
            get
            {
                return primaryNav;
            }
        }

        protected void NewsletterClicked(object o, EventArgs e)
        {
            Response.Redirect("/Contact");
            //try
            //{
            //    SaveNewSubscriber(tbNewsletterSignup.Text);
            //    try
            //    {
            //        var sb = new StringBuilder();
            //        sb.Append("<html><body><a href='http://" + ConfigurationManager.AppSettings["BASEURL"] + "'><img src='http://" + ConfigurationManager.AppSettings["LOGOURL"] + "' alt='logo' /></a><br /><br />Thank you for registering with our newsletter!!");
            //        var messageSent = EmailUtils.SendEmail(tbNewsletterSignup.Text.Trim(), new CampaignManager.Data.Repositories.CampaignManagerSettingRepository().GetBySetting("Newsletter_From_Email").Value, "", ConfigurationManager.AppSettings["NEWSLETTER_EMAIL_RECIPIENTS"], new CampaignManager.Data.Repositories.CampaignManagerSettingRepository().GetBySetting("Newsletter_Email_Subject").Value, sb.ToString().Trim(), false, "");
            //        tbNewsletterSignup.Text = "";
            //        lblNewsletterMessage.Visible = true;
            //    }
            //    catch (Exception exc)
            //    {
            //        tbNewsletterSignup.Text = "";
            //        lblNewsletterMessage.Visible = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex.GetBaseException().GetType() == typeof(SqlException))
            //    {
            //        lblNewsletterMessage.Visible = true;
            //        lblNewsletterMessage.Text = "<font color='red'>Already Registered!!!</font>";
            //    }
            //    else
            //        lblNewsletterMessage.Text = "<font color='red'>Try Back Later.</font>";
            //}
        }

        private void SaveNewSubscriber(string email)
        {
            var s = new SubscriberRepository().GetByEmail(email);
            if (s == null)
            {
                s = new Subscriber();
                s.Email = email;
                s.DateCreated = DateTime.Now;
                s.IsActive = true;
                new SubscriberRepository().Save(s);

                var t = new CampaignManager.Core.Domain.SubscriberCampaignTag();
                t.CampaignTagID = Convert.ToInt16(ConfigurationManager.AppSettings["ALLSUBSCRIBERSTAGID"]);
                t.SubscriberID = s.ID;
                new CampaignManager.Data.Repositories.SubscriberCampaignTagRepository().Save(t);
            }
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