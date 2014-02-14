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
using CMCore = CampaignManager.Core.Domain;
using CMData = CampaignManager.Data.Repositories;
using CMPresentation = CampaignManager.Presentation;
using IdeaSeed.Core;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMS.Core.Security;
using IdeaSeedCMSAdmin.Web.Utils;
using System.Drawing;

namespace IdeaSeedCMSAdmin.Website.Modules.CampaignManager
{
    public partial class Coupon : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = "Coupon Management";
            if (!IsPostBack)
            {
                LoadCoupon();
            }
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            var c = new CMCore.Coupon();
            if (!SecurityContextManager.Current.CurrentURL.Contains("New"))
            {
                c = new CMData.CouponRepository().GetByID(Convert.ToInt16(Request.Url.Segments[3]), false);
            }
            c.Description = tbDescription.Text;
            c.EndDate = (DateTime)tbEndDate.SelectedDate;
            c.IsActive = cbIsActive.Checked;
            c.Name = tbName.Text;
            c.StartDate = (DateTime)tbStartDate.SelectedDate;
            new CMData.CouponRepository().Save(c);
            Response.Redirect("/Campaign-Manager/Coupons");

        }

        protected void ImportCodesClicked(object o, EventArgs e)
        {
            if (Request.Url.Segments.Length == 4)
            {
                Response.Redirect("/Campaign-Manager/Import-Coupon-Codes/" + Request.Url.Segments[3]);
            }
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect("/Campaign-Manager/Coupons");
        }

        private void LoadCoupon()
        {
            if (Request.Url.Segments.Length == 4)
            {
                var c = new CMData.CouponRepository().GetByID(Convert.ToInt16(Request.Url.Segments[3]), false);
                tbDescription.Text = c.Description;
                tbEndDate.SelectedDate = c.EndDate;
                tbName.Text = c.Name;
                tbStartDate.SelectedDate = c.StartDate;
                cbIsActive.Checked = c.IsActive;
            }

        }
    }
}