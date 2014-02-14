using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using IdeaSeed.Web.UI;
using System.Data;
using Telerik.Web.UI;
using System.Configuration;
using System.IO;
using CMCore = CampaignManager.Core.Domain;
using CampaignManager.Core;
using CMData = CampaignManager.Data.Repositories;
using CampaignManager.Presentation;
using IdeaSeed.Core;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMS.Core.Security;
using IdeaSeedCMSAdmin.Web.Utils;
using System.Drawing;

namespace IdeaSeedCMSAdmin.Website.Modules.CampaignManager
{
    public partial class ImportSubscribers : AdminBasePage
    {
        #region Declarations

        string[] emaillist = { };
        int emailsAdded = 0;
        int duplicateEmails = 0;
        List<int> tags = new List<int>();
        IList<CMCore.Subscriber> subscribers = new List<CMCore.Subscriber>();
        #endregion

        #region Properties
        private IList<CMCore.Subscriber> ImportedSubscribers
        {
            get
            {
                if (Session["ImportedSubscribers"] != null)
                {
                    return (IList<CMCore.Subscriber>)Session["ImportedSubscribers"];
                }
                return null;
            }
            set
            {
                Session["ImportedSubscribers"] = value;
            }
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Visible = false;
                LoadTags();
            }
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect(SecurityContextManager.Current.PreviousURL);
        }

        protected void ImportClicked(object o, EventArgs e)
        {
            UpdateProgressContext();
            ImportSubscriberList();
        }

        protected void AddTagsClicked(object o, EventArgs e)
        {
            UpdateProgressContext();
            AddTagsToSubscribers();
        }

        #endregion

        #region Methods

        private void LoadTags()
        {
            dlTags.DataSource = new CMData.CampaignTagRepository().GetAll();
            dlTags.DataBind();
        }

        private void ImportSubscriberList()
        {
            if (ruImport.UploadedFiles.Count > 0)
            {
                foreach (UploadedFile validFile in ruImport.UploadedFiles)
                {
                    using (StreamReader reader = new StreamReader(validFile.InputStream))
                    {
                        emaillist = reader.ReadToEnd().Split(',');
                    }
                }
            }

            foreach (var email in emaillist)
            {
                if (!CampaignManagerUtils.IsDuplicateSubscriber(email))
                {
                    var subscriber = new CMCore.Subscriber();
                    subscriber.Email = email.Replace("\"","");
                    subscriber.IsActive = true;
                    subscriber.DateCreated = DateTime.Now;
                    new CMData.SubscriberRepository().Save(subscriber);
                    subscribers.Add(subscriber);
                    emailsAdded++;
                }
                else
                {
                    duplicateEmails++;
                }
            }
            ImportedSubscribers = subscribers;
            lblReadyForImport.Text = emaillist.Length.ToString();
            lblEmailsImported.Text = emailsAdded.ToString();
            lblEmailsSkipped.Text = duplicateEmails.ToString();
        }

        private void AddTagsToSubscribers()
        {
            foreach (DataListItem item in dlTags.Items)
            {
                var cb = item.FindControl("cbTag") as IdeaSeed.Web.UI.CheckBox;
                if (cb.Checked)
                {
                    tags.Add(Convert.ToInt32(cb.Attributes["tagID"]));
                }
            }

            if (ImportedSubscribers != null && ImportedSubscribers.Count > 0)
            {
                foreach (var tag in tags)
                {
                    foreach (var s in ImportedSubscribers)
                    {
                        var subscriberTag = new CMCore.SubscriberCampaignTag();
                        subscriberTag.CampaignTagID = tag;
                        subscriberTag.SubscriberID = s.ID;
                        new CMData.SubscriberCampaignTagRepository().Save(subscriberTag);
                    }
                }
            }
            lblMessage.Visible = true;
            lblMessage.Text = "<b><font color='green'>Tags have been successfully applied.</font></b>";
        }

        private void UpdateProgressContext()
        {
            const int total = 100;

            RadProgressContext progress = RadProgressContext.Current;
            progress.Speed = "N/A";

            for (int i = 0; i < total; i++)
            {
                progress.PrimaryTotal = 1;
                progress.PrimaryValue = 1;
                progress.PrimaryPercent = 100;

                progress.SecondaryTotal = total;
                progress.SecondaryValue = i;
                progress.SecondaryPercent = i;

                progress.CurrentOperationText = "Percentage complete: " + i.ToString();

                if (!Response.IsClientConnected)
                {
                    //Cancel button was clicked or the browser was closed, so stop processing
                    break;
                }

                progress.TimeEstimated = (total - i) * 100;
                //Stall the current thread for 0.1 seconds
                System.Threading.Thread.Sleep(100);
            }
        }

        #endregion
    }
}