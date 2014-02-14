using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdeaSeedCMSAdmin.Presenters.ViewInterfaces;
using IdeaSeedCMSAdmin.Presenters;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Security;
using IdeaSeed.Core;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMS.Core;
using Telerik.Web.UI;
using IdeaSeedCMS.Services;
using System.Configuration;

namespace IdeaSeedCMSAdmin.Website
{
    public partial class Banner : AdminBasePage
    {
        const int MaxTotalBytes = 1048576; // 1 MB
        int totalBytes;

        private IdeaSeedCMS.Core.Domain.BannerImage SelectedBanner
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    return new BannerImageServices().GetByID(Convert.ToInt16(Request.QueryString["id"]));
                }
                return null;
            }
        }

        public bool? IsRadAsyncValid
        {
            get
            {
                if (Session["IsRadAsyncValid"] == null)
                {
                    Session["IsRadAsyncValid"] = true;
                }

                return Convert.ToBoolean(Session["IsRadAsyncValid"].ToString());
            }
            set
            {
                Session["IsRadAsyncValid"] = value;
            }
        }

        public void RadAsyncUpload1_ValidatingFile(object sender, Telerik.Web.UI.Upload.ValidateFileEventArgs e)
        {
            if ((totalBytes < MaxTotalBytes) && (e.UploadedFile.ContentLength < MaxTotalBytes))
            {
                e.IsValid = true;
                totalBytes += e.UploadedFile.ContentLength;
                IsRadAsyncValid = true;
            }
            else
            {
                e.IsValid = false;
                IsRadAsyncValid = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = "Banner Detail";
            if (!IsPostBack)
                LoadBanner();
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            var b = new BannerImage();
            if (SelectedBanner != null)
            {
                b = SelectedBanner;
            }
            if (radAsyncUpload.UploadedFiles.Count > 0)
            {
                UploadedFile file = radAsyncUpload.UploadedFiles[0];
                string filePath = DateTime.Now.Ticks.ToString() + "_" +
                    file.FileName;
                //string filePath = file.FileName;
                file.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["BANNERIMAGEPATH"]) + filePath, false);
                b.Path = ConfigurationManager.AppSettings["BANNERIMAGEPATH"] + filePath;
            }
            b.Title = tbTitle.Text;
            b.SubText = "";
            b.ToolTip = tbToolTip.Text;
            new BannerImageServices().Save(b);
            Context.Cache.Remove(ResourceStrings.Cache_BannerImagesData);
            Context.Cache.Insert(ResourceStrings.Cache_BannerImagesData, new BannerImageServices().GetAll());
            Response.Redirect("/Banners.aspx");
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect("/Banners.aspx");
        }

        private void LoadBanner()
        {
            if (SelectedBanner != null)
            {
                tbTitle.Text = SelectedBanner.Title;
                tbToolTip.Text = SelectedBanner.ToolTip;
                RadBinaryImage1.ImageUrl = SelectedBanner.Path;

            }
        }
    }
}