<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="DocumentDetails.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.DocumentDetails" %>
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
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

    <script type="text/javascript">
        var uploadedFilesCount = 0;
        var isEditMode;
        function validateRadUpload(source, e)
        {
            // When the RadGrid is in Edit mode the user is not obliged to upload file.

            if (isEditMode == null || isEditMode == undefined)
            {
                e.IsValid = false;

                if (uploadedFilesCount > 0)
                {
                    e.IsValid = true;
                }
            }
            isEditMode = null;
        }

        function OnClientFileUploaded(sender, eventArgs)
        {
            uploadedFilesCount++;
        }

        function OnClientLoad(editor, args)
        {
            var style = editor.get_contentArea().style;
            style.backgroundImage = "none";
            style.backgroundColor = "white";
            style.color = "black";
        }
            
    </script>

</telerik:RadCodeBlock>
    <div id="content">
        <div class="one">
            <h3>Document Details</h3>
            <div runat="server" id="divContent">
            <hr />
                <div>
                    <span>IsFolder?</span>
                    <idea:CheckBox
                    runat="server"
                    ID="cbIsFolder"
                    Skin="Metro"/>
                </div>
                <div>
                    <div>Display Name:</div>
                    <idea:TextBox
                    runat="server"
                    ID="tbName"
                    Skin="Metro"
                    Width="600px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator1"
                    Display="Dynamic"
                    CssClass="alert"
                    ErrorMessage="<br />Enter display name."
                    InitialValue=""
                    ControlToValidate="tbName" />
                </div>
                <div>
                    <div>Upload Document:</div>
                    <telerik:RadAsyncUpload 
                    runat="server" 
                    ID="radAsyncUpload" 
                    AllowedFileExtensions="pdf,doc,docx,xls,xlsx.ppt"
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
