<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Login" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">

            <h3>Login</h3>
            <hr />
    <div  style="width: 300px; margin: 50px auto;">
        <div>
            <div style="margin-bottom: 3px;">Username</div>
            <idea:TextBox
            runat="server"
            Width="279px"
            Skin="Windows7"
            ID="tbUsername">
            </idea:TextBox>
        </div><br />
        <div>
            <div style="margin-bottom: 3px;">Password</div>
            <idea:TextBox
            runat="server"
            Width="279px"
            Skin="Windows7"
            ID="tbPassword"
            TextMode="Password">
            </idea:TextBox>
        </div><br />
        <div style="margin-bottom: 5px;">
            <idea:Label
            runat="server"
            ForeColor="#ff0000"
            ID="lblLoginMessage"
            Visible="false">
            </idea:Label>
        </div>
        <div>
            <span>
                <asp:Button
                    style="color: #000000 !important; width: 100px !important; height: 50px !important;"
                    runat="server"
                    ID="lbLogin"
                    Text="Login"
                    OnClick="LoginClicked" />
            </span>
            <span>
                <asp:Button
                    style="color: #000000 !important; width: 175px !important; height: 50px !important;"
                    runat="server"
                    ID="lbForgotPassword"
                    Text="Forgot Password?"
                    OnClick="ForgotPasswordClicked" />
            </span>
        </div>
        </div>
</asp:Content>
