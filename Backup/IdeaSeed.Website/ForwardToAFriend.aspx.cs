using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using IdeaSeedCMS.Presenters;
using IdeaSeed.Core;
using IdeaSeedCMS.Web.Bases;
using IdeaSeedCMS.Presenters.ViewInterfaces;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Domain.Interfaces;
using IdeaSeedCMS.Core.Security;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Text;

namespace IdeaSeed.Website
{
    public partial class ForwardToAFriend : IdeaSeedCMSBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = "Forward To A Friend";
            Master.PrimaryNavView.Visible = false;
            if (!IsPostBack)
            {
                lblMessage.Visible = false;
                lblBody.Text = new CampaignManager.Data.Repositories.CampaignManagerSettingRepository().GetBySetting("Forward_To_A_Friend_Text").Value;
            }
        }

        protected void SendEmailsClicked(object o, EventArgs e)
        {
            string letter = @"<html><head>

<title>Forward NewsLetter To A Friend</title>
<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'>
</head><body style='background-image: none; background-color: white; color: black;' leftmargin='0' topmargin='0' bgcolor='#ffffff' marginheight='0' marginwidth='0'>
    <div>
        <a href='" + ConfigurationManager.AppSettings["BASEURL"] + @"'><img src='http://" + ConfigurationManager.AppSettings["LOGOURL"] + @"' alt='Modesto Power' border='0'/></a>
    </div>
    <hr />
    " + new CampaignManager.Data.Repositories.CampaignManagerSettingRepository().GetBySetting("Forward_To_A_Friend_Email_Body").Value + @"
</body></html>";
            string[] emails = tbEmails.Text.Split(',');

            StringBuilder sb = new StringBuilder();
            sb.Append(letter);
            bool emailsent = false;
            foreach (string s in emails)
            {
                if (IsValidEmailAddress(s))
                {
                    try
                    {
                        emailsent = true;
                        IdeaSeed.Core.Mail.EmailUtils.SendEmail(s, tbSenderEmail.Text, "", ConfigurationManager.AppSettings["FORWARDTOAFRIENDRECIPIENTS"], new CampaignManager.Data.Repositories.CampaignManagerSettingRepository().GetBySetting("Forward_To_A_Friend_Email_Subject").Value, sb.ToString(), false, "");
                    }
                    catch (Exception exc)
                    { 
                        
                    }
                }
            }
            if (emailsent)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Thank you for sharing our newsletter!!";
                if (!string.IsNullOrEmpty(Request.QueryString["sid"]))
                {
                    var g = Guid.Parse(Request.QueryString["sid"]);
                    var cs = new CampaignManager.Data.Repositories.CampaignSubscriberRepository().GetByID(g, false);
                    if (cs != null)
                    {
                        var s = new CampaignManager.Data.Repositories.SubscriberRepository().GetByID(cs.SubscriberID, false);
                        var cff = new CampaignManager.Core.Domain.CampaignForwardToAFriend();
                        cff.CampaignID = cs.CampaignID;
                        cff.DateForwarded = DateTime.Now;
                        cff.Emails = tbEmails.Text;
                        cff.SubscriberID = s.ID;
                        new CampaignManager.Data.Repositories.CampaignForwardToAFriendRepository().Save(cff);
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "The email addresses you entered are invalid.  Please enter valid email addresses and try again.";
                }
            }
        }

        public static bool IsValidEmailAddress(string sEmail)
        {
            if (sEmail == null)
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(sEmail, @"
            ^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", RegexOptions.IgnorePatternWhitespace);
            }
        }
    }
}