<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="CampaignViewer.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Modules.CampaignManager.CampaignViewer" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="maincontainerfull">
        <h2><span><idea:Label runat="server" ID="lblCampaign"></idea:Label></span></h2>
        <div class="maincontent">
            <div>
                <div>Subject:</div>
                <idea:TextBox
                runat="server"
                ID="tbSubject"
                Width="887px">
                </idea:TextBox>
            </div>
            <div>
                <div>Body:</div>
                <asp:Panel
                runat="server"
                ID="pnlBody"
                CssClass="emailBody">
                    <idea:Label
                    runat="server"
                    ID="lblBody">
                    </idea:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
