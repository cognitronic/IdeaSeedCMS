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
using CMDomain = CampaignManager.Core.Domain;
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
    public partial class CampaignDashboard : AdminBasePage
    {
        #region Properties

        public int CurrentCampaignID
        {
            get
            {
                return (int)ViewState["CurrentCampaign"];
            }
            set
            {
                ViewState["CurrentCampaign"] = value;
            }
        }

        public int CurrentTab
        {
            get
            {
                return (int)ViewState["CurrentTab"];
            }
            set
            {
                ViewState["CurrentTab"] = value;
            }
        }

        public OverViewReport CurrentOverView
        {
            get
            {
                return (OverViewReport)Session["CurrentOverView"];
            }
            set
            {
                Session["CurrentOverView"] = value;
            }
        }

        public CMDomain.CampaignTotals CurrentTotals
        {
            get
            {
                return (CMDomain.CampaignTotals)Session["CurrentTotals"];
            }
            set
            {
                Session["CurrentTotals"] = value;
            }
        }

        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = TITLE_TEXT + "Campaign Dashboard";
            //RadAjaxManager ram = (RadAjaxManager)this.Master.FindControl("RadAjaxManager1");
            //RadAjaxLoadingPanel alp = (RadAjaxLoadingPanel)this.Master.FindControl("AjaxLoadingPanel1");
            //ram.AjaxSettings.AddAjaxSetting(rgCampaignHistory, rgCampaignHistory, alp);
            //ram.AjaxSettings.AddAjaxSetting(rgCampaignHistory, rgCampaignHistory);
            //ram.AjaxSettings.AddAjaxSetting(rgCampaignHistory, tsCampaignDetails);
            //ram.AjaxSettings.AddAjaxSetting(rgCampaignHistory, mpCampaignDetails);
            //ram.AjaxSettings.AddAjaxSetting(tsCampaignDetails, tsCampaignDetails);
            //ram.AjaxSettings.AddAjaxSetting(tsCampaignDetails, mpCampaignDetails);
            if (!IsPostBack)
            {
                CurrentCampaignID = -1;
                CurrentTab = 0;
                CurrentOverView = null;
                CurrentTotals = null;
                LoadCampaigns(true);
                tsCampaignDetails.SelectedIndex = CurrentTab;
                mpCampaignDetails.PageViews[0].Selected = true;
                LoadDetailsByTab(CurrentTab.ToString(), true);
            }
        }

        protected void ViewCampaignClicked(object o, EventArgs e)
        {
            Response.Redirect("Campaign-Manager/Campaign-Viewer?cid=" + ((IdeaSeed.Web.UI.LinkButton)o).Attributes["campaignid"]);
        }

        protected void ItemCreated(object o, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                HyperLink editLink = (HyperLink)e.Item.FindControl("lbViewCampaign");
                editLink.Attributes["href"] = "Campaign-Manager/Campaign-Viewer?cid=" + editLink.Attributes["campaignid"];
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"], e.Item.ItemIndex);
            }

        }

        protected void TabClicked(object o, RadTabStripEventArgs e)
        {
            //LoadDetailsByTab(tsCampaignDetails.SelectedTab.Value, CurrentCampaignID, true);
            CurrentTab = tsCampaignDetails.SelectedIndex;
        }

        protected void UserItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.EditCommandName || e.CommandName == "RowClick" && e.Item is GridDataItem)
            {
                e.Item.Selected = true;
                CurrentCampaignID = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"];
                CurrentOverView = new OverViewReport(CurrentCampaignID);
                CurrentTotals = new CMData.CampaignTotalsRepository().GetByCampaignID(CurrentCampaignID);

                tsCampaignDetails.SelectedIndex = CurrentTab;
                LoadDetailsByTab(tsCampaignDetails.SelectedTab.Value, true);
            }
        }

        protected void UserNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadCampaigns(false);
        }

        protected void OptOutNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadOptOuts(false);
        }

        protected void ForwardsNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadForwards(false);
        }
        
        protected void ErrorNeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            LoadErrors(false);
        }

        protected void ErrorItemCommand(object o, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.DeleteCommandName)
            {
                var template = new CMData.SubscriberRepository().GetByEmail((e.Item.FindControl("lblEmail") as IdeaSeed.Web.UI.Label).Text);
                template.IsActive = false;
                new CMData.SubscriberRepository().Save(template);
                var err = new CMData.CampaignEmailErrorRepository().GetByID(Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]), false);
                err.Removed = true;
                new CMData.CampaignEmailErrorRepository().Save(err);
                tsCampaignDetails.SelectedIndex = CurrentTab;
                LoadDetailsByTab(tsCampaignDetails.SelectedTab.Value, true);
            }
        }

        protected void OverviewItemDataBound(object o, Telerik.Charting.ChartItemDataBoundEventArgs e)
        {
            e.SeriesItem.Name = ((DataRowView)e.DataItem)["LinkText"].ToString();
        }


        protected void ToggleSelectedState(object o, EventArgs e)
        {
            if ((o as IdeaSeed.Web.UI.CheckBox).Checked)
            {
                foreach (GridDataItem dataItem in rgErrors.MasterTableView.Items)
                {
                    (dataItem.FindControl("cbSelectRow") as IdeaSeed.Web.UI.CheckBox).Checked = true;
                    //dataItem.Selected = true;
                }
            }
            else
            {
                foreach (GridDataItem dataItem in rgErrors.MasterTableView.Items)
                {
                    (dataItem.FindControl("cbSelectRow") as IdeaSeed.Web.UI.CheckBox).Checked = false;
                    dataItem.Selected = false;
                }
            }
            rgErrors.PagerStyle.Position = GridPagerPosition.Bottom;
        }

        protected void ApplyClicked(object o, EventArgs e)
        {
            foreach (GridDataItem row in rgErrors.MasterTableView.Items)
            {
                var cb = row.FindControl("cbSelectRow") as IdeaSeed.Web.UI.CheckBox;
                if (cb.Checked)
                {
                    var subscriber = new CMData.SubscriberRepository().GetByEmail(cb.Attributes["email"]);
                    subscriber.IsActive = false;
                    new CMData.SubscriberRepository().Save(subscriber);
                    var err = new CMData.CampaignEmailErrorRepository().GetByID(Convert.ToInt32(cb.Attributes["itemid"]), false);
                    err.Removed = true;
                    new CMData.CampaignEmailErrorRepository().Save(err);
                }
            }
            tsCampaignDetails.SelectedIndex = CurrentTab;
            LoadDetailsByTab(tsCampaignDetails.SelectedTab.Value, true);
        }

        #endregion

        #region Methods


        protected void LoadLinksChart()
        {
            var list = new List<CampaignLinksReportHelper>();
            foreach (var link in CurrentOverView.CampaignLinksResult)
            {
                try
                {
                    if (list.Find(o => o.LinkText.Equals(link.LinkText)) == null)
                    {
                        list.Add(link);
                    }
                }
                catch (Exception exc)
                { }
            }
            rcLinksResult.DataSource = list;// CurrentOverView.CampaignLinksResult;
            rcLinksResult.PlotArea.XAxis.DataLabelsColumn = "LinkText";
            rcLinksResult.PlotArea.XAxis.Appearance.LabelAppearance.RotationAngle = 90;
            rcLinksResult.PlotArea.Appearance.Dimensions.Margins.Bottom = Telerik.Charting.Styles.Unit.Pixel(125);
            rcLinksResult.PlotArea.XAxis.Appearance.LabelAppearance.Position.AlignedPosition = Telerik.Charting.Styles.AlignedPositions.Top;
            rcLinksResult.PlotArea.XAxis.Appearance.TextAppearance.AutoTextWrap = Telerik.Charting.Styles.AutoTextWrap.False;
            rcLinksResult.PlotArea.YAxis.AxisMode = Telerik.Charting.ChartYAxisMode.Extended;
            rcLinksResult.DataBind();
            Color[] barColors = new Color[60]{
        Color.Pink,
        Color.SteelBlue,
        Color.Aqua,
        Color.Yellow,
        Color.Navy,
        Color.Green,
        Color.Blue,
        Color.Red,
        Color.Purple,
        Color.PowderBlue,
        Color.PaleGreen,
        Color.Orange,
        Color.LightPink,
        Color.DarkOliveGreen,
        Color.Olive,
        Color.Pink,
        Color.SteelBlue,
        Color.Aqua,
        Color.Yellow,
        Color.Navy,
        Color.Green,
        Color.Blue,
        Color.Red,
        Color.Purple,
        Color.PowderBlue,
        Color.PaleGreen,
        Color.Orange,
        Color.LightPink,
        Color.DarkOliveGreen,
        Color.Olive,
        Color.Pink,
        Color.SteelBlue,
        Color.Aqua,
        Color.Yellow,
        Color.Navy,
        Color.Green,
        Color.Blue,
        Color.Red,
        Color.Purple,
        Color.PowderBlue,
        Color.PaleGreen,
        Color.Orange,
        Color.LightPink,
        Color.DarkOliveGreen,
        Color.Olive,
        Color.Pink,
        Color.SteelBlue,
        Color.Aqua,
        Color.Yellow,
        Color.Navy,
        Color.Green,
        Color.Blue,
        Color.Red,
        Color.Purple,
        Color.PowderBlue,
        Color.PaleGreen,
        Color.Orange,
        Color.LightPink,
        Color.DarkOliveGreen,
        Color.Olive
        };
            int i = 0;
            if (rcLinksResult.Series.Count > 0)
            {
                foreach (var item in rcLinksResult.Series[0].Items)
                {
                    item.Appearance.Border.Color = Color.LightBlue;
                    item.Appearance.FillStyle.MainColor = barColors[i++];
                    item.Appearance.FillStyle.FillType = Telerik.Charting.Styles.FillType.Solid;
                }
            }
        }

        protected string FormatSentBy(string userid)
        {
            var s = new UserServices().GetByID(Convert.ToInt32(userid));
            if (s != null)
            {
                return s.FirstName + " " + s.LastName;
            }
            return "Unknown User ID: " + userid;
        }

        protected void LoadCampaigns(bool binddata)
        {
            rgCampaignHistory.DataSource = new CMData.CampaignRepository().GetAll().OrderByDescending(c => c.DateTimeSent);
            if (binddata)
            {
                rgCampaignHistory.DataBind();
            }
        }

        protected void LoadOptOuts(bool binddata)
        {
            if (CurrentCampaignID > 0)
            {
                rgOptOut.DataSource = new CMData.CampaignOptedOutRepository().GetByCampaignID(CurrentCampaignID);
                if (binddata)
                {
                    rgOptOut.DataBind();
                }
            }
        }

        protected void LoadForwards(bool binddata)
        {
            if (CurrentCampaignID > 0)
            {
                rgForwards.DataSource = new CMData.CampaignForwardToAFriendRepository().GetByCampaignID(CurrentCampaignID);
                if (binddata)
                {
                    rgForwards.DataBind();
                }
            }
        }

        protected void LoadErrors(bool binddata)
        {
            if (CurrentCampaignID > 0)
            {
                rgErrors.DataSource = new CMData.CampaignEmailErrorRepository().GetByCampaignID(CurrentCampaignID);
                if (binddata)
                {
                    rgErrors.DataBind();
                }
            }
        }

        protected void LoadOverview()
        {
            if (CurrentTotals != null)
            {
                lblTotalMessagesSent.Text = CurrentTotals.TotalRecipients.ToString();
                lblTotalErrors.Text = CurrentTotals.TotalErrors.ToString();
                lblTotalRecipients.Text = (CurrentTotals.TotalRecipients - CurrentTotals.TotalErrors).ToString();
                lblUniqueEmailReads.Text = CurrentTotals.UniqueEmailReads.ToString();
                lblTotalEmailReads.Text = CurrentTotals.TotalEmailReads.ToString();
                lblUniqueLinkClicks.Text = CurrentTotals.UniqueLinkClicks.ToString();
                lblTotalLinkClicks.Text = CurrentTotals.TotalLinkClicks.ToString();
                LoadLinksChart();
            }
        }

        protected void LoadDetailsByTab(string selectedtab, bool databind)
        {
            switch (selectedtab)
            {
                case "0":
                    LoadOverview();
                    break;
                case "1":
                    LoadForwards(true);
                    break;
                case "2":
                    //LoadUserGroups(userid, databind);
                    break;
                case "3":
                    LoadOptOuts(true);
                    break;
                case "4":
                    LoadErrors(true);
                    break;
            }
        }
        #endregion
    }
}