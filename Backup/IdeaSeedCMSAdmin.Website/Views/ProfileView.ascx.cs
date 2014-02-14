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
using IdeaSeedCMSAdmin.Web.Utils;

namespace IdeaSeedCMSAdmin.Website.Views
{
    public partial class ProfileView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpPageHelper.SetImagesPath(reContent);
            if (!IsPostBack)
            {
                if (SecurityContextManager.Current.CurrentURL.Contains("/edit"))
                {
                    LoadPageContent();
                    LoadLinks(true);
                }
            }
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            SavePage();
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect("/Pages");
        }

        protected void PreviewClicked(object o, EventArgs e)
        {

        }


        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadLinks(false);
        }

        private void LoadLinks(bool bindData)
        {
            rgPageLinks.DataSource = new PageLinkServices().GetByPageID(SecurityContextManager.Current.CurrentPage.ID);
            if (bindData)
                rgPageLinks.DataBind();
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.EditCommandName:
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SetEditMode", "isEditMode = true;", true);
                    break;
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    var i = new PageLink();
                    i.Title = "";
                    i.ImagePath = "";
                    i.ID = 0;
                    e.Item.OwnerTableView.InsertItem(new PageLink());
                    break;
                case RadGrid.UpdateCommandName:
                    var img = new PageLinkServices().GetByID(Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString()));
                    GridEditFormItem insertItem = e.Item as GridEditFormItem;
                    img.Title = (insertItem["Title"].FindControl("tbTitle") as RadTextBox).Text;
                    img.PageID = SecurityContextManager.Current.CurrentPage.ID;
                    img.URL = (insertItem["URL"].FindControl("tbURL") as RadTextBox).Text;
                    new PageLinkServices().Save(img);
                    LoadLinks(true);
                    break;
                case RadGrid.PerformInsertCommandName:
                    insertItem = e.Item as GridEditFormInsertItem;
                    img = new PageLink();
                    img.Title = (insertItem["Title"].FindControl("tbTitle") as RadTextBox).Text;
                    img.PageID = SecurityContextManager.Current.CurrentPage.ID;
                    img.URL = (insertItem["URL"].FindControl("tbURL") as RadTextBox).Text;
                    new PageLinkServices().Save(img);
                    LoadLinks(true);

                    break;
                case RadGrid.DeleteCommandName:
                    img = new PageLinkServices().GetByID(Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString()));
                    new PageLinkServices().Delete(img);
                    LoadLinks(true);
                    break;
            }
        }

        private void LoadPageContent()
        {
            ddlPayType.SelectedValue = ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).PageTypeID.ToString();
            tbExternalURL.Text = ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).ExternalURL;
            tbName.Text = ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).DisplayName;
            tbSeoDescription.Text = ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).SEODescription;
            tbSeoKeywords.Text = ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).SEOKeywords;
            tbSeoTitle.Text = ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).SEOTitle;
            RadBinaryImage1.ImageUrl = ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).HeaderImagePath;
            var content = new PageContentServices().GetByPageID(SecurityContextManager.Current.CurrentPage.ID);
            if (content != null)
            {
                tbSubTitle.Text = content.SubTitle;
                tbTitle.Text = content.Title;
                reContent.Content = content.PageData;
            }
            cbIsExternal.Checked = ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).IsExternal;
            cbOnline.Checked = SecurityContextManager.Current.CurrentPage.IsActive;
        }

        private void SavePage()
        {
            if (SecurityContextManager.Current.CurrentURL.Contains("/edit"))
            {
                ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).IsExternal = cbIsExternal.Checked;
                SecurityContextManager.Current.CurrentPage.IsActive = cbOnline.Checked;
                SecurityContextManager.Current.CurrentPage.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).DisplayName = tbName.Text;
                ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).ExternalURL = tbExternalURL.Text;
                SecurityContextManager.Current.CurrentPage.LastUpdated = DateTime.Now;
                SecurityContextManager.Current.CurrentPage.Name = tbName.Text.Replace("&", "").Replace("'", "").Replace("?", "").Replace("@", "").Replace("$", "").Replace("#", "");
                ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).SEODescription = tbSeoDescription.Text;
                ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).SEOKeywords = tbSeoKeywords.Text;
                ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).SEOTitle = tbSeoTitle.Text;

                if (radAsyncUpload.UploadedFiles.Count > 0)
                {
                    UploadedFile file = radAsyncUpload.UploadedFiles[0];
                    string filePath = DateTime.Now.Ticks.ToString() + "_" +
                        file.FileName;
                    //string filePath = file.FileName;
                    file.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["IMAGEURL"]) + filePath, false);
                    ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).HeaderImagePath = ConfigurationManager.AppSettings["IMAGEURL"] + filePath;
                }

                var content = new PageContentServices().GetByPageID(SecurityContextManager.Current.CurrentPage.ID);
                content.PageData = reContent.Content;
                content.Title = tbTitle.Text;
                content.SubTitle = tbSubTitle.Text;
                content.LastUpdated = DateTime.Now;
                content.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;

                new PageServices().Save(((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage));
                new PageContentServices().Save(content);
                Response.Redirect(SecurityContextManager.Current.CurrentURL);
            }
            else 
            {
                var p = new IdeaSeedCMS.Core.Domain.Page();
                p.IsActive = cbOnline.Checked;
                p.AccessLevel = 0;
                p.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                p.DateCreated = DateTime.Now;
                p.DisplayName = tbName.Text;
                p.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                p.ExternalURL = tbExternalURL.Text;
                if (radAsyncUpload.UploadedFiles.Count > 0)
                {
                    UploadedFile file = radAsyncUpload.UploadedFiles[0];
                    string filePath = DateTime.Now.Ticks.ToString() + "_" +
                        file.FileName;
                    //string filePath = file.FileName;
                    file.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["IMAGEURL"]) + filePath, false);
                    p.HeaderImagePath = ConfigurationManager.AppSettings["IMAGEURL"] + filePath;
                }
                p.IsExternal = cbIsExternal.Checked;
                p.LastUpdated = DateTime.Now;
                p.MarkedForDeletion = false;
                p.Name = tbName.Text.Replace("&", "").Replace("'", "").Replace("?", "").Replace("@", "").Replace("$", "").Replace("#", "");
                p.NavigationTypeID = (int)NavigationType.NONE;
                p.PageTypeID = Convert.ToInt16(ddlPayType.SelectedValue);
                if (SecurityContextManager.Current.CurrentURL.Contains("/add"))
                    p.ParentID = ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).ID;
                p.SEODescription = tbSeoDescription.Text;
                p.SEOKeywords = tbSeoKeywords.Text;
                p.SEOTitle = tbSeoTitle.Text;
                p.URLRoute = "/Default.aspx";
                p.ApplicationID = Convert.ToInt16(SecurityContextManager.Current.CurrentManagedApplication.ID);
                new PageServices().Save(p);

                var content = new PageContent();
                content.PageData = reContent.Content;
                content.Title = tbTitle.Text;
                content.SubTitle = tbSubTitle.Text;
                content.LastUpdated = DateTime.Now;
                content.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                content.DateCreated = DateTime.Now;
                content.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                content.PageID = p.ID;
                new PageContentServices().Save(content);

                switch (ddlPayType.SelectedValue)
                { 
                    case "5":
                        var apv = new PageApplicationView();
                        apv.ApplicationViewID = Convert.ToInt16(ConfigurationManager.AppSettings["PROFILE_APPLICATION_VIEW_ID"]);
                        apv.PageID = p.ID;
                        apv.ViewLayout = ApplicationViewLayout.MAIN;
                        apv.SortOrder = 0;
                        new PageViewServices().Save(apv);
                        break;
                    case "6":

                        break;
                }
                Response.Redirect("/Pages/" + p.ID.ToString() + "/edit");
            }
            HttpContext.Current.Cache.Remove(ResourceStrings.Cache_PrimaryPublicNavData);
            Context.Cache.Insert(ResourceStrings.Cache_PrimaryPublicNavData, new PageServices().GetByNavigationTypeID(1, Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"])));
        }
    }
}