<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Banner.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Banner" %>
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
            <h3>Banner Details</h3>
            <hr />
            <div>
                <div>Title:</div>
                <idea:TextBox
                runat="server"
                ID="tbTitle"
                Width="400px">
                </idea:TextBox>
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator2"
                Display="Dynamic"
                CssClass="alert"
                ErrorMessage="<br />Enter title."
                InitialValue=""
                ControlToValidate="tbTitle" />
            </div>
            <div>
                <div>Tool Tip:</div>
                <idea:Textbox
                runat="server"
                Width="400px"
                ID="tbToolTip" />
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator1"
                Display="Dynamic"
                CssClass="alert"
                ErrorMessage="<br />Enter tooltip."
                InitialValue=""
                ControlToValidate="tbToolTip" />
            </div>
            <div>
                <div>URL To Photo:</div>
                <telerik:RadBinaryImage 
                runat="server" 
                ID="RadBinaryImage1" 
                AutoAdjustImageControlSize="false" 
                Height="338px" 
                Width="940px" 
                ToolTip='<%#Eval("Title", "Photo of {0}") %>'
                AlternateText='<%#Eval("Title", "Photo of {0}") %>' />
                <br /><br />
                <telerik:RadAsyncUpload 
                runat="server" 
                ID="radAsyncUpload" 
                AllowedFileExtensions="jpg,jpeg,png,gif"
                MaxFileSize="1048576"
                OverwriteExistingFiles="false" 
                OnValidatingFile="RadAsyncUpload1_ValidatingFile">
                </telerik:RadAsyncUpload>
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
                OnClick="CancelClicked">
                    <b>Cancel</b>
                </idea:LinkButton>&nbsp;&nbsp;&nbsp;
            </div>
        </div>
    </div>
</div>
</asp:Content>
