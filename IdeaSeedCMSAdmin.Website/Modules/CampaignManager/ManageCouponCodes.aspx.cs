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
using CampaignManager.Data.Repositories;
using CampaignManager.Presentation;
using IdeaSeed.Core;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMS.Core.Security;
using IdeaSeed.Web;
using IdeaSeedCMSAdmin.Web.Utils;
using System.Drawing;
using NHibernate.Exceptions;
using Iesi.Collections.Generic;

namespace IdeaSeedCMSAdmin.Website.Modules.CampaignManager
{
    public partial class ManageCouponCodes : AdminBasePage
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadCoupons(true);
            }
        }

        protected void RedeemedClicked(object o, EventArgs e)
        {
            var cc = new CouponCodeRepository().GetByID(Convert.ToInt16(((IdeaSeed.Web.UI.LinkButton)o).Attributes["itemid"]), false);
            cc.IsRedeemed = true;
            cc.RedeemedDate = DateTime.Now;
            new CouponCodeRepository().Save(cc);
            LoadCoupons(true);
        }

        protected void SearchClicked(object o, EventArgs e)
        {
            LoadCoupons(true);
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                Response.Redirect("Coupons/" + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
            }

            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                Response.Redirect("New-Coupon");
            }

            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var template = new CampaignTemplateRepository().GetByID((int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"], false);
                new CampaignTemplateRepository().Delete(template);
            }
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadCoupons(false);
        }

        #endregion

        #region Methods

        private void LoadCoupons(bool dataBind)
        {
            int? coupon = null;
            bool? isredeemed = null;
            bool? isassigned = null;
            if (!string.IsNullOrEmpty(ddlCouponFilter.SelectedValue))
                coupon = Convert.ToInt16(ddlCouponFilter.SelectedValue);
            if (!string.IsNullOrEmpty(ddlIsAssignedFilter.SelectedValue))
                isassigned = Convert.ToBoolean(ddlIsAssignedFilter.SelectedValue);
            if (!string.IsNullOrEmpty(ddlRedeemedFilter.SelectedValue))
                isredeemed = Convert.ToBoolean(ddlRedeemedFilter.SelectedValue);
            rgCodes.DataSource = new CouponCodeRepository().GetByFilters(tbCodeFilter.Text, coupon, isredeemed, isassigned).OrderBy(t => t.Code);
            if (dataBind)
            {
                rgCodes.DataBind();
            }
        }
        #endregion
    }
}