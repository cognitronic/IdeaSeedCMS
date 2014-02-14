<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Template.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Modules.CampaignManager.Template" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <telerik:RadScriptBlock runat="server" ID="rsbTemplate">
        <script type="text/javascript">
            function openRadWindow(id)
            {

                var oWnd = radopen("CampaignViewer.aspx?cid=" + id, "rwViewCampaign");
                oWnd.center();
            }

            function OnClientLoad(editor, args)
            {
                var style = editor.get_contentArea().style;
                style.backgroundImage = "none";
                style.backgroundColor = "white";
                style.color = "black";
            }

        </script>
    </telerik:RadScriptBlock>
    <div class="maincontainerfull" runat="server" id="divContent">
        <div class="maincontent" id="divMain" style="padding-bottom: 5px;" runat="server">
                <h3>Template Details</h3>
                <hr />
            <div style="float: right; width: 250px; height: 200px; padding-bottom: 10px;">
                <div>
                    <div><b>Created By:</b></div>
                    <idea:Label
                    id="lblCreatedBy"
                    runat="server">
                    </idea:Label>
                </div><br />
                <div>
                    <div><b>Updated By:</b></div>
                    <idea:Label
                    id="lblUpdatedBy"
                    runat="server">
                    </idea:Label>
                </div><br />
                <div>
                    <div><b>Last Updated:</b></div>
                    <idea:Label
                    id="lblLastUpdated"
                    runat="server">
                    </idea:Label>
                </div>
            </div>
            <div>
                <div><b>Template Name:</b></div>
                <idea:TextBox
                runat="server"
                ID="tbTemplateName"
                Width="600px">
                </idea:TextBox>
                <asp:RequiredFieldValidator
                runat="server"
                ID="rfvTemplateName"
                InitialValue=""
                Display="Dynamic"
                ErrorMessage="<br />Please name this template."
                ControlToValidate="tbTemplateName">
                </asp:RequiredFieldValidator>
            </div>
            <div style="margin-top: 10px;">
                <div><b>Description:</b></div>
                <idea:TextBox
                runat="server"
                ID="tbDescription"
                TextMode="MultiLine"
                Height="40px"
                Width="600px">
                </idea:TextBox>
            </div>
            <div style="margin-top: 10px;">
                <div><b>Subject of Message:</b></div>
                <idea:TextBox
                runat="server"
                ID="tbSubject"
                Width="600px">
                </idea:TextBox>
                <asp:RequiredFieldValidator
                runat="server"
                ID="rfvSubject"
                InitialValue=""
                Display="Dynamic"
                ErrorMessage="<br />Please enter the subject of the message to be sent."
                ControlToValidate="tbSubject">
                </asp:RequiredFieldValidator>
            </div>
            <div style="margin-top: 10px;">
                <div><b>HTML Body of Message:</b></div>
                <telerik:RadEditor
                ID="reCampaignContent"
                Width="950px"
                Height="600px"
                OnClientLoad="OnClientLoad"
                ContentFilters="None"
                Skin="Metro" 
                runat="server" AllowScripts="True">
                    <Content>
                    </Content>
                </telerik:RadEditor>
            </div>
        </div>
    </div>
    <br />
    <div>
        <span>
            <asp:Button
            runat="server"
            Height="30px"
            ID="btnSave"
            CssClass="button small round blue"
            ToolTip="Save or update template."
            Text="Save"
            OnClick="SaveClicked" />
        </span>
        <span>
            <asp:Button
            runat="server"
            Height="30px"
            ID="btnSaveAs"
            CssClass="button small round blue"
            ToolTip="Creates a new template based on the currently selected one."
            Text="Save As"
            OnClick="SaveAsClicked" />
        </span>
        <span>
            <asp:Button
            runat="server"
            Height="30px"
            CssClass="button small round blue"
            ID="btnCreateCampaign"
            ToolTip="Creates a new template based on the currently selected one."
            Text="Create Campaign"
            OnClick="NewCampaignClicked" />
        </span>
    </div>
    <br /><br />

</asp:Content>
