using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdeaSeedCMS.Presenters.ViewInterfaces;
using IdeaSeedCMS.Presenters;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Security;
using IdeaSeed.Core;
using IdeaSeedCMS.Web.Bases;
using IdeaSeedCMS.Core;
using CMCore = CampaignManager.Core.Domain;
using CampaignManager.Core;
using CMData = CampaignManager.Data.Repositories;

namespace IdeaSeed.Website.Views
{
    [PresenterType(typeof(ContactUsPresenter))]
    public partial class ContactUsView : BaseWebUserControl, IContactUsView
    {
        List<int> tags = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
            LoadTags();
        }

        public new event EventHandler LoadView;

        private CMCore.Subscriber SaveNewSubscriber(string email)
        {
            var s = new CMData.SubscriberRepository().GetByEmail(email);
            if (s == null)
            {
                s = new CMCore.Subscriber();
                s.Email = email;
                s.DateCreated = DateTime.Now;
                s.IsActive = true;
                new CMData.SubscriberRepository().Save(s);
                return s;
            }
            return null;
        }
        protected void SendClicked(object o, EventArgs e)
        {
            if (this.SendMessage != null)
            {
                this.SendMessage(this, EventArgs.Empty);
            }
            if (IsSuccessful)
            {
                foreach (DataListItem item in dlTags.Items)
                {
                    var cb = item.FindControl("cbTag") as IdeaSeed.Web.UI.CheckBox;
                    if (cb.Checked)
                    {
                        tags.Add(Convert.ToInt32(cb.Attributes["tagID"]));
                    }
                }

                var s = SaveNewSubscriber(tbEmail.Text);
                if (s != null)
                {
                    foreach (var tag in tags)
                    {
                        var subscriberTag = new CMCore.SubscriberCampaignTag();
                        subscriberTag.CampaignTagID = tag;
                        subscriberTag.SubscriberID = s.ID;
                        new CMData.SubscriberCampaignTagRepository().Save(subscriberTag);
                    }
                }

                lblMessage.Text = "<span style='color: #ff0000;'>Thank you for your inquiry!  A staff member will contact you shortly.</span>";
                lbSubmit.Enabled = false;
            }
            else
            {
                lblMessage.Text = "<span style='color: #ff0000;'>An unexpected error occurred.  Please call us at 209.526.1314 regarding your inquiry</span>";
            }
        }

        private void LoadTags()
        {
            dlTags.DataSource = new CMData.CampaignTagRepository().GetByIsPublic(true);
            dlTags.DataBind();
        }

        #region IContactUsView Members

        public string Name
        {
            get
            {
                return tbName.Text;
            }
            set
            {
                tbName.Text = value;
            }
        }

        public string Email
        {
            get
            {
                return tbEmail.Text;
            }
            set
            {
                tbEmail.Text = value;
            }
        }

        public string Phone
        {
            get
            {
                return tbPhone.Text;
            }
            set
            {
                tbPhone.Text = value;
            }
        }

        public string Message
        {
            get
            {
                return tbMessage.Text;
            }
            set
            {
                tbMessage.Text = value;
            }
        }

        public bool IsSuccessful
        {
            get;
            set;
        }

        public event EventHandler SendMessage;

        #endregion
    }
}