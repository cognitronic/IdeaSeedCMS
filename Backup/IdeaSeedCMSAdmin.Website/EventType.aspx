<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="EventType.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.EventType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
<telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbSave">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divContent" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />

<div id="content">
    <div class="one">
        <div runat="server" id="divContent">
            <h3>Event Type Details</h3>
            <hr />
            <div>
                <div>Name:</div>
                <idea:TextBox
                runat="server"
                ID="tbName"
                Width="400px">
                </idea:TextBox>
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator1"
                Display="Dynamic"
                CssClass="alert"
                ErrorMessage="<br />Enter Name."
                InitialValue=""
                ControlToValidate="tbName" />
            </div>
            <div>
                <div>Description:</div>
                <idea:Textbox
                runat="server"
                Width="400px"
                ID="tbDescription" />
            </div>
            <br />
            <div>
                <idea:LinkButton
                runat="server"
                CssClass="button small round red-cherry"
                ID="lbSave"
                OnClick="SaveClicked">
                    <b>Save</b>
                </idea:LinkButton>&nbsp;&nbsp;&nbsp;
                <idea:LinkButton
                runat="server"
                CssClass="button small round red-cherry"
                ID="lbCancel"
                CausesValidation="false"
                OnClick="CancelClicked">
                    <b>Cancel</b>
                </idea:LinkButton>&nbsp;&nbsp;&nbsp;
            </div>
        </div>
    </div>
</div>
</asp:Content>
