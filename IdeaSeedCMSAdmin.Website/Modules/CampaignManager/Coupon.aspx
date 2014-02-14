<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Coupon.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Modules.CampaignManager.Coupon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
<telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnSend">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divBody" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="lblSentMessage"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="divSubscribers">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divSubscribers" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />
    <h3>Coupon Detail</h3>
    <hr />
    <div class="maincontainerfull" style="border-bottom: solid 1px #dddddd;">
        <div class="maincontent">
            <div>
                <idea:LinkButton
                runat="server"
                ID="lbImportCodes"
                OnClick="ImportCodesClicked">
                    <asp:Image
                    runat="server"
                    ID="imgImportCodes"
                    ToolTip="Import a comma separated list of coupon codes."
                    ImageUrl="~/images/database_add.png"
                    Style="border: none;" /> Import Coupon Codes
                </idea:LinkButton>
            </div>
            <div>
                <div>Is Active:</div>
                <idea:CheckBox
                runat="server"
                ID="cbIsActive"/>
            </div>
            <div>
                <div>Name:</div>
                <idea:TextBox
                runat="server"
                ID="tbName"
                Width="500px" />
            </div>
            <div>
                <div>Description:</div>
                <idea:TextBox
                runat="server"
                ID="tbDescription"
                TextMode="MultiLine"
                Height="50px"
                Width="500px" />
            </div>
            <div>
                <div>Start Date:</div>
                <telerik:RadDatePicker 
                ID="tbStartDate"
                Skin="Windows7"
                AutoPostBack="true"
                MinDate="1/1/2006"
                runat="server">
                    <DateInput ID="diStartDate" runat="server"
                        DateFormat="MM/dd/yyyy"></DateInput>
                </telerik:RadDatePicker>
            </div>
            <div>
                <div>End Date:</div>
                <telerik:RadDatePicker 
                ID="tbEndDate"
                Skin="Windows7"
                AutoPostBack="true"
                MinDate="1/1/2006"
                runat="server">
                    <DateInput ID="diEndDate" runat="server"
                        DateFormat="MM/dd/yyyy"></DateInput>
                </telerik:RadDatePicker>
            </div>
            <br />
            <div>
                <idea:LinkButton
                runat="server"
                CssClass="button small round blue"
                ID="lbSave"
                OnClick="SaveClicked">
                    <b>Save</b>
                </idea:LinkButton>&nbsp;&nbsp;&nbsp;
                <idea:LinkButton
                runat="server"
                CssClass="button small round blue"
                ID="lbCancel"
                OnClick="CancelClicked">
                    <b>Return To Previous Page</b>
                </idea:LinkButton>&nbsp;&nbsp;&nbsp;
            </div>
            <br />
        </div>
    </div>
</asp:Content>
