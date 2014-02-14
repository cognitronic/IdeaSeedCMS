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
    public partial class ImportCouponCodes : AdminBasePage
    {
        #region Declarations

        string[] codelist = { };
        int codesAdded = 0;
        int duplicateCodes = 0;
        IList<CMCore.CouponCode> codes = new List<CMCore.CouponCode>();
        #endregion

        #region Properties
        private IList<CMCore.CouponCode> ImportedCodes
        {
            get
            {
                if (Session["ImportedCodes"] != null)
                {
                    return (IList<CMCore.CouponCode>)Session["ImportedCodes"];
                }
                return null;
            }
            set
            {
                Session["ImportedCodes"] = value;
            }
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Visible = false;
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

        #endregion

        #region Methods
        private void ImportSubscriberList()
        {
            if (ruImport.UploadedFiles.Count > 0)
            {
                foreach (UploadedFile validFile in ruImport.UploadedFiles)
                {
                    using (StreamReader reader = new StreamReader(validFile.InputStream))
                    {
                        codelist = reader.ReadToEnd().Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    }
                }
            }

            foreach (var code in codelist)
            {
                string[] c = code.Split(',');
                var cc = new CMCore.CouponCode();
                cc.Code = c[0];
                cc.CodeText = c[1];
                cc.CouponID = Convert.ToInt16(Request.Url.Segments[3]);
                cc.IsAssigned = false;
                cc.IsRedeemed = false;
                new CMData.CouponCodeRepository().Save(cc);
                codes.Add(cc);
                codesAdded++;
            }
            ImportedCodes = codes;
            lblReadyForImport.Text = codelist.Length.ToString();
            lblEmailsImported.Text = codesAdded.ToString();
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