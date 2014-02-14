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
using CampaignManager.Core;
using CampaignManager.Core.Domain;
using CampaignManager.Data.Repositories;
using CampaignManager.Presentation;
using IdeaSeed.Core;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMS.Core.Security;
using IdeaSeedCMSAdmin.Web.Utils;
using System.Drawing;
using NHibernate.Exceptions;
using Iesi.Collections.Generic;

namespace IdeaSeedCMSAdmin.Website.Modules.CampaignManager
{
    public partial class Template : AdminBasePage
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            RadAjaxManager ram = (RadAjaxManager)this.Master.FindControl("RadAjaxManager1");
            RadAjaxLoadingPanel alp = (RadAjaxLoadingPanel)this.Master.FindControl("AjaxLoadingPanel1");
            ram.AjaxSettings.AddAjaxSetting(btnSave, divContent, alp);
            ram.AjaxSettings.AddAjaxSetting(btnSaveAs, divContent, alp);
            if (!IsPostBack)
            {
                SetImagesPath(reCampaignContent);
                LoadTemplate();
                if (CampaignHelper.SelectedTemplateID < 1)
                {
                    btnCreateCampaign.Enabled = false;
                    btnSaveAs.Enabled = false;
                }
            }
        }

        protected void NewCampaignClicked(object o, EventArgs e)
        {
            Response.Redirect("New-Campaign");
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            SaveTemplate(false);
        }

        protected void SaveAsClicked(object o, EventArgs e)
        {
            SaveTemplate(true);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
        }

        #endregion

        #region Methods

        private void LoadTemplate()
        {
            if (CampaignHelper.SelectedTemplateID > 0)
            {
                var template = new CampaignTemplateRepository().GetByID(CampaignHelper.SelectedTemplateID, false);
                if (template != null)
                {
                    tbDescription.Text = template.Description;
                    tbSubject.Text = template.EmailSubject;
                    tbTemplateName.Text = template.TemplateName;
                    reCampaignContent.Content = template.EmailBody;
                    lblCreatedBy.Text = GetUserFullNameByUserID(template.EnteredBy);
                    lblLastUpdated.Text = template.LastUpdated.ToString();
                    lblUpdatedBy.Text = GetUserFullNameByUserID(template.ChangedBy);
                }
            }
        }

        private void SaveTemplate(bool isSaveAs)
        {
            if (isSaveAs)
            {
                var template = new CampaignTemplate();
                template.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                template.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                template.Description = tbDescription.Text;
                template.EmailBody = reCampaignContent.Content;
                template.EmailSubject = tbSubject.Text;
                template.LastUpdated = DateTime.Now;
                template.DateCreated = DateTime.Now;
                template.TemplateName = tbTemplateName.Text;
                new CampaignTemplateRepository().Save(template);
                CampaignHelper.SelectedTemplateID = template.ID;
                LoadTemplate();
            }
            else
            {
                if (CampaignHelper.SelectedTemplateID > 0)
                {
                    var template = new CampaignTemplateRepository().GetByID(CampaignHelper.SelectedTemplateID, false);
                    template.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                    template.Description = tbDescription.Text;
                    template.EmailBody = reCampaignContent.Content;
                    template.EmailSubject = tbSubject.Text;
                    template.LastUpdated = DateTime.Now;
                    template.TemplateName = tbTemplateName.Text;
                    new CampaignTemplateRepository().SaveOrUpdate(template);
                    LoadTemplate();
                }
                else
                {
                    var template = new CampaignTemplate();
                    template.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
                    template.Description = tbDescription.Text;
                    template.EmailBody = reCampaignContent.Content;
                    template.EmailSubject = tbSubject.Text;
                    template.LastUpdated = DateTime.Now;
                    template.TemplateName = tbTemplateName.Text;
                    template.DateCreated = DateTime.Now;
                    template.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                    new CampaignTemplateRepository().SaveOrUpdate(template);
                    CampaignHelper.SelectedTemplateID = template.ID;
                    LoadTemplate();
                }
            }
        }

        
        #endregion
    }
}