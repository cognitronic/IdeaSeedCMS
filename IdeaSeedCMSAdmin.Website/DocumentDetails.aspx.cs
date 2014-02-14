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
    public partial class DocumentDetails : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadDocument();
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            SaveDocument();
        }

        protected void CancelClicked(object o, EventArgs e)
        { 
            
        }

        private void LoadDocument()
        {
            if (SecurityContextManager.Current.CurrentURL.Contains("Edit"))
            {
                if (((IdeaSeedCMS.Core.Domain.DocumentLibrary)SecurityContextManager.Current.CurrentItem.ItemReference) != null && ((IdeaSeedCMS.Core.Domain.DocumentLibrary)SecurityContextManager.Current.CurrentItem.ItemReference).ID > 0)
                {
                    var d = ((IdeaSeedCMS.Core.Domain.DocumentLibrary)SecurityContextManager.Current.CurrentItem.ItemReference);
                    cbIsFolder.Checked = d.IsFolder;
                    tbName.Text = d.Name;
                }
            }
            //else
            //{
            //    var d = new IdeaSeedCMS.Core.Domain.DocumentLibrary();
            //    d.Name = tbName.Text;
            //    d.IsFolder = cbIsFolder.Checked;
            //    d.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            //    d.DateCreated = DateTime.Now;
            //    d.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            //    d.LastUpdated = DateTime.Now;
            //    if (radAsyncUpload.UploadedFiles.Count > 0)
            //    {
            //        UploadedFile file = radAsyncUpload.UploadedFiles[0];
            //        string filePath = DateTime.Now.Ticks.ToString() + "_" +
            //            file.FileName;
            //        //string filePath = file.FileName;
            //        file.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["DOCUMENTURL"]) + filePath, false);
            //        d.Path = ConfigurationManager.AppSettings["DOCUMENTURL"] + filePath;
            //    }
            //    if (((IdeaSeedCMS.Core.Domain.DocumentLibrary)SecurityContextManager.Current.CurrentItem.ItemReference) != null && ((IdeaSeedCMS.Core.Domain.DocumentLibrary)SecurityContextManager.Current.CurrentItem.ItemReference).ID > 0)
            //    {
            //        d.ParentID = ((IdeaSeedCMS.Core.Domain.DocumentLibrary)SecurityContextManager.Current.CurrentItem.ItemReference).ID;
            //    }
            //    new DocumentLibraryServices().Save(d);
            //}
        }

        private void SaveDocument()
        {
            if (SecurityContextManager.Current.CurrentURL.Contains("Edit"))
            {
                if (((IdeaSeedCMS.Core.Domain.DocumentLibrary)SecurityContextManager.Current.CurrentItem.ItemReference) != null && ((IdeaSeedCMS.Core.Domain.DocumentLibrary)SecurityContextManager.Current.CurrentItem.ItemReference).ID > 0)
                {
                    var d = ((IdeaSeedCMS.Core.Domain.DocumentLibrary)SecurityContextManager.Current.CurrentItem.ItemReference);
                    d.IsFolder = cbIsFolder.Checked;
                    d.Name = tbName.Text;
                    d.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                    d.LastUpdated = DateTime.Now;
                    if (radAsyncUpload.UploadedFiles.Count > 0)
                    {
                        UploadedFile file = radAsyncUpload.UploadedFiles[0];
                        string filePath = DateTime.Now.Ticks.ToString() + "_" +
                            file.FileName;
                        //string filePath = file.FileName;
                        file.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["DOCUMENTURL"]) + filePath, false);
                        d.Path = ConfigurationManager.AppSettings["DOCUMENTURL"] + filePath;
                    }
                    new DocumentLibraryServices().Save(d);
                    Response.Redirect("/Document-Library");
                }
            }
            else
            {
                var d = new IdeaSeedCMS.Core.Domain.DocumentLibrary();
                d.Name = tbName.Text;
                d.IsFolder = cbIsFolder.Checked;
                d.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                d.DateCreated = DateTime.Now;
                d.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                d.LastUpdated = DateTime.Now;
                d.ApplicationID = Convert.ToInt16(Master.MasterApplicationDDL.SelectedValue);
                if (radAsyncUpload.UploadedFiles.Count > 0)
                {
                    UploadedFile file = radAsyncUpload.UploadedFiles[0];
                    string filePath = DateTime.Now.Ticks.ToString() + "_" +
                        file.FileName;
                    //string filePath = file.FileName;
                    file.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["DOCUMENTURL"]) + filePath, false);
                    d.Path = ConfigurationManager.AppSettings["DOCUMENTURL"] + filePath;
                }
                if (((IdeaSeedCMS.Core.Domain.DocumentLibrary)SecurityContextManager.Current.CurrentItem.ItemReference) != null && ((IdeaSeedCMS.Core.Domain.DocumentLibrary)SecurityContextManager.Current.CurrentItem.ItemReference).ID > 0)
                {
                    d.ParentID = ((IdeaSeedCMS.Core.Domain.DocumentLibrary)SecurityContextManager.Current.CurrentItem.ItemReference).ID;
                }
                new DocumentLibraryServices().Save(d);
                Response.Redirect("/Document-Library");
            }
        }
    }
}