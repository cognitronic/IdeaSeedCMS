<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ForwardToAFriend.aspx.cs" Inherits="IdeaSeed.Website.ForwardToAFriend" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <%--<telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbSendEmails">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="lblMessage" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />--%>
    <div class="maincontainernoactions">
        <h2><span>Recommend to a Friend</span></h2>
        <hr />
        <div class="maincontent">
            <div>
                <idea:Label
                runat="server"
                ID="lblBody" />
                <br /><br /><br />
                <div>
                    <div>Your Email:</div>
                    <idea:TextBox
                    runat="server"
                    Width="250px"
                    ID="tbSenderEmail">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvSender"
                    Display="Dynamic"
                    ControlToValidate="tbSenderEmail"
                    ErrorMessage="Please enter your email address!!">
                    </asp:RequiredFieldValidator>
                </div>
                <br />
                <div>Enter in a comma seperated list of email addresses</div>
                <idea:TextBox
                runat="server"
                ID="tbEmails"
                TextMode="MultiLine"
                Width="400px"
                Height="150px">
                </idea:TextBox>
                <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator1"
                    Display="Dynamic"
                    InitialValue=""
                    ControlToValidate="tbEmails"
                    ErrorMessage="Please enter at least one valid email address!!">
                    </asp:RequiredFieldValidator><br /><br />
                <idea:LinkButton
                runat="server"
                ID="lbSendEmails"
                OnClick="SendEmailsClicked">
                    Send
                </idea:LinkButton><br /><br />
            </div>
            <div>
                <idea:Label
                runat="server"
                ID="lblMessage">
                </idea:Label>
            </div>
        </div>
    </div>
</asp:Content>
