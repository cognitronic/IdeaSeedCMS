<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsDetailView.ascx.cs" Inherits="IdeaSeedCMSAdmin.Website.Views.NewsDetailView" %>
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
            <h3>News Details</h3>
            <hr />
            <div>
                <div>Post Type:</div>
                <idea:BlogPostTypeDDL
                runat="server"
                ID="ddlPostType" />
                <asp:RequiredFieldValidator
                runat="server"
                ID="rfvPostType"
                Display="Dynamic"
                ErrorMessage="<br />Please select type"
                InitialValue=""
                ControlToValidate="ddlPostType" />
            </div>
            <div>
                <div>Title:</div>
                <idea:TextBox
                runat="server"
                Width="450px"
                ID="tbTitle" />
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator1"
                Display="Dynamic"
                ErrorMessage="<br />Please enter a title"
                InitialValue=""
                ControlToValidate="tbTitle" />
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
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator2"
                Display="Dynamic"
                ErrorMessage="<br />Please enter start date"
                InitialValue=""
                ControlToValidate="tbStartDate" />
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
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator3"
                Display="Dynamic"
                ErrorMessage="<br />Please enter end date"
                InitialValue=""
                ControlToValidate="tbEndDate" />
            </div>
            <div>
                <div>SEO Keywords:</div>
                <idea:TextBox
                runat="server"
                TextMode="MultiLine"
                Height="150px"
                Width="450px"
                ID="tbSeoKeywords" />
            </div>
            <div>
                <div>SEO Description:</div>
                <idea:TextBox
                runat="server"
                TextMode="MultiLine"
                Height="195px"
                Width="450px"
                ID="tbSeoDescription" />
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