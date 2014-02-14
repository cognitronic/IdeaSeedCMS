<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div  style="width: 300px; margin: 0 auto;">
        <div runat="server" id="divMessage">
            <idea:Label
            runat="server"
            ForeColor="Red"
            ID="lblMessage" />
        </div>
        <div runat="server" id="divEmail">
            <div>
                <div>Username:</div>
                <idea:TextBox
                runat="server"
                Width="175px"
                ID="tbUsername" />
            </div>
            <div>
                <idea:LinkButton
                runat="server"
                ID="lbVerifyEmail"
                OnClick="VerifyEmailClicked">
                    Verify Username
                </idea:LinkButton>
            </div>
        </div>
        <div runat="server" id="divPasswordAnswer">
            <div>
                <div>Question:</div>
                <idea:Label
                runat="server"
                ID="lblQuestion" />
            </div>
            <div>
                <div>Answer:</div>
                <idea:TextBox
                runat="server"
                ID="tbAnswer"
                Width="175px" />
            </div>
            <div>
                <idea:LinkButton
                runat="server"
                ID="lbVerifyAnswer"
                OnClick="VerifyAnswerClicked">
                    Verify Answer
                </idea:LinkButton>
            </div>
        </div>
        <div runat="server" id="divPassword">
            <div>
                <div>Password:</div>
                <idea:TextBox
                runat="server"
                ID="tbPassword"
                Width="175px" />
            </div>
            <div>
                <div>Confirm Password:</div>
                <idea:TextBox
                runat="server"
                ID="tbConfirmPassword"
                Width="175px" />
            </div>
            <div>
                <idea:LinkButton
                runat="server"
                ID="lbVerifyPasswords"
                OnClick="VerifyPasswordsClicked">
                    Update Password
                </idea:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
