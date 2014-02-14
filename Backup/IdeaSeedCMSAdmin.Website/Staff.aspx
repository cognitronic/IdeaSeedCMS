<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Staff" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.master" %>
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
        <telerik:AjaxSetting AjaxControlID="rgSchedule">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgSchedule" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Metro" />
<div id="content">
    <div class="one">
        <div runat="server" id="divContent">
            <h3>Staff Details</h3>
            <hr />
            <div>
                <span>Is Active: </span>
                <idea:CheckBox
                runat="server"
                Skin="Metro"
                ID="cbIsActive" />
            </div>
            <div>
                <div>First Name:</div>
                <idea:TextBox
                runat="server"
                ID="tbFirstName"
                Skin="Metro"
                Width="600px">
                </idea:TextBox>
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator1"
                Display="Dynamic"
                CssClass="alert"
                ErrorMessage="<br />Enter first name."
                InitialValue=""
                ControlToValidate="tbFirstName" />
            </div>
            <div>
                <div>Last Name:</div>
                <idea:TextBox
                runat="server"
                ID="tbLastName"
                Skin="Metro"
                Width="600px">
                </idea:TextBox>
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator5"
                Display="Dynamic"
                CssClass="alert"
                ErrorMessage="<br />Enter last name."
                InitialValue=""
                ControlToValidate="tbLastName" />
            </div>
            <div>
                <div>Title:</div>
                <idea:TextBox
                runat="server"
                ID="tbTitle"
                Skin="Metro"
                Width="600px">
                </idea:TextBox>
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator6"
                Display="Dynamic"
                CssClass="alert"
                ErrorMessage="<br />Enter title."
                InitialValue=""
                ControlToValidate="tbTitle" />
            </div>
            <div>
                <div>Email:</div>
                <idea:TextBox
                runat="server"
                ID="tbEmail"
                Skin="Metro"
                Width="600px">
                </idea:TextBox>
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator2"
                Display="Dynamic"
                CssClass="alert"
                ErrorMessage="<br />Enter email."
                InitialValue=""
                ControlToValidate="tbEmail" />
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
                CausesValidation="false"
                CssClass="button small round red-cherry"
                ID="lbCancel"
                OnClick="CancelClicked">
                    <b>Cancel</b>
                </idea:LinkButton>&nbsp;&nbsp;&nbsp;
            </div><br />
        </div>
    </div>
</div>
</asp:Content>
