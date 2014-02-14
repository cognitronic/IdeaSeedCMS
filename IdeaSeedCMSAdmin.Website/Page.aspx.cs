using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMS.Core;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Services;
using IdeaSeed.Core;
using Telerik.Web.UI;
using IdeaSeedCMS.Core.Security;
using System.Configuration;

namespace IdeaSeedCMSAdmin.Website
{
    public partial class Page : AdminBasePage
    {
        private IdeaSeedCMS.Core.Domain.Page CurrentPage
        {
            get
            {
                if (Request.QueryString["id"] != null)
                {
                    var p = new PageServices().GetByID(Convert.ToInt32(Request.QueryString["id"]));
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
            Master.Page.Title = SecurityContextManager.Current.CurrentItem.SEOTitle;
            if (!IsPostBack)
            {
                LoadPageContent();
                LoadLinks(true);
            }
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            SavePage();
            Response.Redirect("/Pages");
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
            if (!SecurityContextManager.Current.CurrentURL.Contains("New"))
            {
                rgPageLinks.DataSource = new PageLinkServices().GetByPageID(this.CurrentPage.ID);
                if (bindData)
                    rgPageLinks.DataBind();
            }
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
                    img.PageID = this.CurrentPage.ID;
                    img.URL = (insertItem["URL"].FindControl("tbURL") as RadTextBox).Text;
                    new PageLinkServices().Save(img);
                    LoadLinks(true);
                    break;
                case RadGrid.PerformInsertCommandName:
                    insertItem = e.Item as GridEditFormInsertItem;
                    img = new PageLink();
                    img.Title = (insertItem["Title"].FindControl("tbTitle") as RadTextBox).Text;
                    img.PageID = this.CurrentPage.ID;
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
            if (!SecurityContextManager.Current.CurrentURL.Contains("New"))
            {
                tbExternalURL.Text = this.CurrentPage.ExternalURL;
                tbName.Text = this.CurrentPage.DisplayName;
                tbSeoDescription.Text = this.CurrentPage.SEODescription;
                tbSeoKeywords.Text = this.CurrentPage.SEOKeywords;
                tbSeoTitle.Text = this.CurrentPage.SEOTitle;
                RadBinaryImage1.ImageUrl = this.CurrentPage.HeaderImagePath;
                var content = new PageContentServices().GetByPageID(this.CurrentPage.ID);
                if (content != null)
                {
                    tbSubTitle.Text = content.SubTitle;
                    tbTitle.Text = content.Title;
                    reContent.Content = content.PageData;
                }
                cbIsExternal.Checked = this.CurrentPage.IsExternal;
                cbOnline.Checked = this.CurrentPage.IsActive;
            }
        }

        private void SavePage()
        {
            if (SecurityContextManager.Current.CurrentURL.Contains("/edit"))
            {
                this.CurrentPage.IsExternal = cbIsExternal.Checked;
                this.CurrentPage.IsActive = cbOnline.Checked;
                this.CurrentPage.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                this.CurrentPage.DisplayName = tbName.Text;
                this.CurrentPage.ExternalURL = tbExternalURL.Text;
                this.CurrentPage.LastUpdated = DateTime.Now;
                this.CurrentPage.Name = tbName.Text.Replace("&", "").Replace("'", "").Replace("?", "").Replace("@", "").Replace("$", "").Replace("#", "");
                this.CurrentPage.SEODescription = tbSeoDescription.Text;
                this.CurrentPage.SEOKeywords = tbSeoKeywords.Text;
                this.CurrentPage.SEOTitle = tbSeoTitle.Text;

                if (radAsyncUpload.UploadedFiles.Count > 0)
                {
                    UploadedFile file = radAsyncUpload.UploadedFiles[0];
                    string filePath = DateTime.Now.Ticks.ToString() + "_" +
                        file.FileName;
                    //string filePath = file.FileName;
                    file.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["IMAGEURL"]) + filePath, false);
                    this.CurrentPage.HeaderImagePath = ConfigurationManager.AppSettings["IMAGEURL"] + filePath;
                }

                var content = new PageContentServices().GetByPageID(this.CurrentPage.ID);
                content.PageData = reContent.Content;
                content.Title = tbTitle.Text;
                content.SubTitle = tbSubTitle.Text;
                content.LastUpdated = DateTime.Now;
                content.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;

                new PageServices().Save(this.CurrentPage);
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
                p.PageTypeID = (int)PageType.PROFILE;
                if (SecurityContextManager.Current.CurrentURL.Contains("/add"))
                {
                    p.ParentID = ((IdeaSeedCMS.Core.Domain.Page)SecurityContextManager.Current.CurrentPage).ID;
                    p.NavigationTypeID = (int)NavigationType.NONE;
                }
                else
                {
                    p.NavigationTypeID = (int)NavigationType.MAIN;
                }
                p.SEODescription = tbSeoDescription.Text;
                p.SEOKeywords = tbSeoKeywords.Text;
                p.SEOTitle = tbSeoTitle.Text;
                p.URLRoute = "/Default.aspx";
                p.ApplicationID = Convert.ToInt16(SecurityContextManager.Current.CurrentManagedApplication.ID);
                new PageServices().Save(p);

                var pav = new PageApplicationView();
                pav.ApplicationViewID = Convert.ToInt16(ConfigurationManager.AppSettings["DEFAULTAPPLICATIONVIEWID"]);
                pav.PageID = p.ID;
                pav.ViewLayout = ApplicationViewLayout.MAIN;
                pav.SortOrder = 0;
                new PageViewServices().Save(pav);

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

                Response.Redirect(SecurityContextManager.Current.CurrentURL.Replace("New", p.ID.ToString() + "/edit"));
            }
            //HttpContext.Current.Cache.Remove(ResourceStrings.Cache_PrimaryPublicNavData);
            //Context.Cache.Insert(ResourceStrings.Cache_PrimaryPublicNavData, new PageServices().GetByNavigationTypeID(1, Convert.ToInt16(ConfigurationManager.AppSettings["APPLICATIONID"])));
        }
    }
}