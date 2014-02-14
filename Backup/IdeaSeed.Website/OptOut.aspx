<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="OptOut.aspx.cs" Inherits="IdeaSeed.Website.OptOut" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="maincontainernoactions" style="margin-top: 50px;">
        <h2><span>Newsletter Opt Out</span></h2>
        <div class="maincontent">
            <div>
                <idea:Label
                runat="server"
                ID="lblBody" />
                <br />
                <idea:LinkButton
                runat="server"
                ID="lbOptOut"
                OnClick="OptOutClicked">
                    Opt Out
                </idea:LinkButton><br /><br />
            </div>
            <div>
                <idea:Label
                runat="server"
                ForeColor="Red"
                ID="lblMessage">
                </idea:Label>
            </div>
        </div>
    </div>
</asp:Content>
