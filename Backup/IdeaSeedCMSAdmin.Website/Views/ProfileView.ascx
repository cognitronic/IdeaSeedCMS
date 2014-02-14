<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileView.ascx.cs" Inherits="IdeaSeedCMSAdmin.Website.Views.ProfileView" %>
<telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbSave">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divContent" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rgPageLinks">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgPageLinks" LoadingPanelID="RadAjaxLoadingPanel1" />
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
            <div runat="server" id="divContent">
            <h3>Page Details</h3>
            <hr />
                <div>
                    <span>Online?</span>
                    <idea:CheckBox
                    runat="server"
                    ID="cbOnline"
                    Skin="Metro"/>&nbsp;&nbsp;&nbsp;&nbsp;
                    <span>Is External Page?</span>
                    <idea:CheckBox
                    runat="server"
                    ID="cbIsExternal"
                    Skin="Metro" />
                </div>
                <div>
                    <div>Page Type:</div>
                    <idea:PageTypeDDL
                    runat="server"
                    id="ddlPayType">
                    </idea:PageTypeDDL>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator1"
                    Display="Dynamic"
                    CssClass="alert"
                    ErrorMessage="<br />Select a page type."
                    InitialValue=""
                    ControlToValidate="ddlPayType" />
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
                    ID="RequiredFieldValidator2"
                    Display="Dynamic"
                    CssClass="alert"
                    ErrorMessage="<br />Enter a name."
                    InitialValue=""
                    ControlToValidate="tbName" />
                </div>
                <div>
                    <div>SEO Title:</div>
                    <idea:TextBox
                    runat="server"
                    ID="tbSeoTitle"
                    Skin="Metro"
                    Width="600px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator3"
                    Display="Dynamic"
                    CssClass="alert"
                    ErrorMessage="<br />Enter SEO title."
                    InitialValue=""
                    ControlToValidate="tbSeoTitle" />
                </div>
                <div>
                    <div>SEO Keywords:</div>
                    <idea:TextBox
                    runat="server"
                    ID="tbSeoKeywords"
                    Skin="Metro"
                    Height="30px"
                    TextMode="MultiLine"
                    Width="600px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator4"
                    Display="Dynamic"
                    CssClass="alert"
                    ErrorMessage="<br />Enter SEO keywords."
                    InitialValue=""
                    ControlToValidate="tbSeoKeywords" />
                </div>
                <div>
                    <div>SEO Descriptions:</div>
                    <idea:TextBox
                    runat="server"
                    ID="tbSeoDescription"
                    Skin="Metro"
                    Height="70px"
                    TextMode="MultiLine"
                    Width="600px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator5"
                    Display="Dynamic"
                    CssClass="alert"
                    ErrorMessage="<br />Enter SEO description."
                    InitialValue=""
                    ControlToValidate="tbSeoDescription" />
                </div>
                <div>
                    <div>External URL:</div>
                    <idea:TextBox
                    runat="server"
                    ID="tbExternalURL"
                    Skin="Metro"
                    Width="600px">
                    </idea:TextBox>
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
                    ErrorMessage="<br />Enter page title."
                    InitialValue=""
                    ControlToValidate="tbTitle" />
                </div>
                <div>
                    <div>Sub Title:</div>
                    <idea:TextBox
                    runat="server"
                    ID="tbSubTitle"
                    Skin="Metro"
                    Width="600px">
                    </idea:TextBox>
                </div>
                <div>
                    <div>URL To Photo:</div>
                    <telerik:RadBinaryImage 
                    runat="server" 
                    ID="RadBinaryImage1" 
                    AutoAdjustImageControlSize="false" 
                    Height="210px" 
                    Width="690px" 
                    ToolTip='<%#Eval("Title", "Photo of {0}") %>'
                    AlternateText='<%#Eval("Title", "Photo of {0}") %>' />
                    <br />
                    <telerik:RadAsyncUpload 
                    runat="server" 
                    ID="radAsyncUpload" 
                    AllowedFileExtensions="jpg,jpeg,png,gif"
                    MaxFileSize="1048576"
                    OverwriteExistingFiles="false" 
                    OnValidatingFile="RadAsyncUpload1_ValidatingFile">
                    </telerik:RadAsyncUpload>
                </div>
                <div>
                    <div>Content:</div>
                    <telerik:RadEditor 
                    ID="reContent"
                    AllowScripts="True"
                    OnClientLoad="OnClientLoad"
                    EditModes="Design,HTML"
                    Height="600px"
                    Width="100%"
                    ContentAreaMode="Div"
                    ToolsFile="/ToolsFile.xml"
                    ContentFilters="MakeUrlsAbsolute" 
                    runat="server">
                    </telerik:RadEditor>
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
                    <%--<idea:LinkButton
                    runat="server"
                    target="_blank"
                    CssClass="button small round red-cherry"
                    ID="lbPreview"
                    OnClick="PreviewClicked">
                        <b>Preview</b>
                    </idea:LinkButton>&nbsp;&nbsp;&nbsp;--%>
                    <idea:LinkButton
                    runat="server"
                    CssClass="button small round red-cherry"
                    ID="lbCancel"
                    OnClick="CancelClicked">
                        <b>Cancel</b>
                    </idea:LinkButton>&nbsp;&nbsp;&nbsp;
                </div>
                <br /><hr /><br />
                <div>
                    <div><h3>Links</h3></div>
                    <telerik:RadGrid
                    runat="server"
                    ID="rgPageLinks"
                    AllowPaging="True"
                    AutoGenerateColumns="false"
                    AllowSorting="True" 
                    GridLines="None" 
                    ShowStatusBar="true"
                    OnNeedDataSource="NeedDataSource"
                    OnItemCommand="ItemCommand"
                    ShowFooter="true"
                    Skin="Windows7">
                        <ClientSettings EnableRowHoverStyle="true">
                        </ClientSettings>
                        <MasterTableView 
                        DataKeyNames="ID"
                        CommandItemDisplay="Top"
                        CommandItemSettings-AddNewRecordText="Add New Page Link"
                        ItemStyle-VerticalAlign="Top"
                        AlternatingItemStyle-VerticalAlign="Top"
                        EnableNoRecordsTemplate="true"
                        NoMasterRecordsText="No Pages Found.">
                            <Columns>
                                <telerik:GridTemplateColumn 
                                DataField="Title" 
                                HeaderText="Title" 
                                SortExpression="Title"
                                UniqueName="Title">
                                    <ItemTemplate>
                                        <%# Eval("Title")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <idea:TextBox
                                        runat="server"
                                        Text='<%# Eval("Title") %>'
                                        ID="tbTitle">
                                        </idea:TextBox>
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator1"
                                        Display="Dynamic"
                                        CssClass="alert"
                                        ErrorMessage="<br />Enter link title."
                                        InitialValue=""
                                        ControlToValidate="tbTitle" />
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                DataField="URL" 
                                HeaderText="URL" 
                                SortExpression="URL"
                                UniqueName="URL">
                                    <ItemTemplate>
                                        <%# Eval("URL")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <idea:TextBox
                                        runat="server"
                                        Text='<%# Eval("URL") %>'
                                        ID="tbURL">
                                        </idea:TextBox>
                                        <asp:RequiredFieldValidator
                                        runat="server"
                                        ID="RequiredFieldValidator1"
                                        Display="Dynamic"
                                        CssClass="alert"
                                        ErrorMessage="<br />Enter link URL."
                                        InitialValue=""
                                        ControlToValidate="tbURL" />
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn
                                HeaderStyle-Width="20px">
                                    <ItemTemplate>
                                        <idea:LinkButton
                                        runat="server"
                                        ID="lbEdit"
                                        CommandName="Edit"
                                        linkid='<%# Eval("ID").ToString() %>'>
                                            <asp:Image
                                            runat="server"
                                            ID="imgEdit"
                                            ToolTip="Edit Link"
                                            ImageUrl="~/images/edit.gif"
                                            Style="border: none;" />
                                        </idea:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn
                                HeaderStyle-Width="20px">
                                    <ItemTemplate>
                                        <idea:LinkButton
                                        runat="server"
                                        ID="lbDelete"
                                        CommandName="Delete"
                                        OnClientClick="return confirm('Are you sure you want to delete this link?')"
                                        linkid='<%# Eval("ID").ToString() %>'>
                                            <asp:Image
                                            runat="server"
                                            ID="imgDelete"
                                            ToolTip="Delete Link"
                                            ImageUrl="~/images/delete.png"
                                            Style="border: none;" />
                                        </idea:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <PagerStyle Mode="NextPrevAndNumeric"  AlwaysVisible="false" Position="Bottom" />
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </div>
        </div>
    </div>
