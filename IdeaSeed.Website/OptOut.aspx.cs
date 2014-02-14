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

namespace IdeaSeed.Website
{
    public partial class OptOut : IdeaSeedCMSBasePage
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = "Newsletter Opt Out";
            Master.PrimaryNavView.Visible = false;
            if (!IsPostBack)
            {
                lblMessage.Visible = false;
                lblBody.Text = new CampaignManager.Data.Repositories.CampaignManagerSettingRepository().GetBySetting("Opt_Out_Text").Value;
            }
        }

        protected void OptOutClicked(object o, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["sid"]))
            {
                var g = Guid.Parse(Request.QueryString["sid"]);
                var cs = new CampaignManager.Data.Repositories.CampaignSubscriberRepository().GetByID(g, false);
                if (cs != null)
                {
                    var s = new CampaignManager.Data.Repositories.SubscriberRepository().GetByID(cs.SubscriberID, false);
                    s.IsActive = false;
                    new CampaignManager.Data.Repositories.SubscriberRepository().Save(s);

                    var oo = new CampaignManager.Core.Domain.CampaignOptOut();
                    oo.CampaignID = Convert.ToInt32(Request.QueryString["amp;cid"]);
                    oo.DateUnsubscribed = DateTime.Now;
                    oo.SubscriberID = s.ID;
                    new CampaignManager.Data.Repositories.CampaignOptedOutRepository().Save(oo);
                }
                lblMessage.Visible = true;
                lblMessage.Text = "<b>We're sorry to see you go!!</b><br/><br />You have been successfully removed from the mailing list.";
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "We could not find your clientid in the system, which most likely means you've already been removed.  Please click on the Opt Out link in your email to try again.  If you are still receiving unwanted notifications, please contact PrimeShine.  Sorry for the inconvienence!!";
            }
        }

        #endregion
    }
}