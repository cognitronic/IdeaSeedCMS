using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMSAdmin.Web.Utils;
using IdeaSeedCMS.Core;
using IdeaSeedCMS.Services;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Security;
using Telerik.Web.UI;

namespace IdeaSeedCMSAdmin.Website.Views
{
    public partial class NewsDetailView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadNews();
            HttpPageHelper.SetImagesPath(reContent);
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            var b = new Blog();
            if (((Blog)SecurityContextManager.Current.CurrentItem.ItemReference) != null && ((Blog)SecurityContextManager.Current.CurrentItem.ItemReference).ID > 0)
            {
                b = ((Blog)SecurityContextManager.Current.CurrentItem.ItemReference);
            }
            b.BlogContent = reContent.Content;
            b.EndDate = (DateTime)tbEndDate.SelectedDate;
            b.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            b.PostType = Convert.ToInt16(ddlPostType.SelectedValue);
            b.SEODescription = tbSeoDescription.Text;
            b.SEOKeywords = tbSeoKeywords.Text;
            b.StartDate = (DateTime)tbStartDate.SelectedDate;
            b.Title = tbTitle.Text;
            new BlogServices().Save(b);
            Response.Redirect("/News");
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect("/News");
        }

        private void LoadNews()
        {
            if (((Blog)SecurityContextManager.Current.CurrentItem.ItemReference) != null && ((Blog)SecurityContextManager.Current.CurrentItem.ItemReference).ID > 0)
            {
                var b = ((Blog)SecurityContextManager.Current.CurrentItem.ItemReference);
                tbEndDate.SelectedDate = b.EndDate;
                tbStartDate.SelectedDate = b.StartDate;
                reContent.Content = b.BlogContent;
                tbSeoDescription.Text = b.SEODescription;
                tbSeoKeywords.Text = b.SEOKeywords;
                tbTitle.Text = b.Title;
                ddlPostType.SelectedValue = b.PostType.ToString();
            }
        }
    }
}