<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div id="content">
        <div class="one">
            <div runat="server" id="divContent">
                <h3>Users</h3>
                <hr />
                <div>
                    <div>Is Active:</div>
                    <idea:CheckBox
                    runat="server"
                    ID="cbIsActive" />
                </div>
                <div>
                    <div>First Name:</div>
                    <idea:TextBox
                    runat="server"
                    Width="450px"
                    ID="tbFirstName" />
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator3"
                    Display="Dynamic"
                    ErrorMessage="<br />Please enter first name"
                    InitialValue=""
                    ControlToValidate="tbFirstName" />
                </div>
                <div>
                    <div>Last Name:</div>
                    <idea:TextBox
                    runat="server"
                    Width="450px"
                    ID="tbLastName" />
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator1"
                    Display="Dynamic"
                    ErrorMessage="<br />Please enter last name"
                    InitialValue=""
                    ControlToValidate="tbLastName" />
                </div>
                <div>
                    <div>Email:</div>
                    <idea:TextBox
                    runat="server"
                    Width="450px"
                    ID="tbEmail" />
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator2"
                    Display="Dynamic"
                    ErrorMessage="<br />Please enter email"
                    InitialValue=""
                    ControlToValidate="tbEmail" />
                    <asp:RegularExpressionValidator 
                    ID="valEmailAddress"
                    ControlToValidate="tbEmail"
                    CssClass="error"
                    ValidationExpression="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" 
                    ErrorMessage="<br />Email address is invalid." 
                    Display="Dynamic" 
                    EnableClientScript="true"
                    Runat="server"/>
                </div>
                <div>
                    <div>Security Question:</div>
                    <idea:TextBox
                    runat="server"
                    Width="450px"
                    ID="tbQuestion" />
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator4"
                    Display="Dynamic"
                    ErrorMessage="<br />Please enter a security question"
                    InitialValue=""
                    ControlToValidate="tbQuestion" />
                </div>
                <div>
                    <div>Security Answer:</div>
                    <idea:TextBox
                    runat="server"
                    Width="450px"
                    ID="tbAnswer" />
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator5"
                    Display="Dynamic"
                    ErrorMessage="<br />Please enter an answer to your security question"
                    InitialValue=""
                    ControlToValidate="tbAnswer" />
                </div>
                <div>
                    <div>Password:</div>
                    <idea:TextBox
                    runat="server"
                    Width="450px"
                    ID="tbPassword" />
                </div>
                <div>
                    <div>Role:</div>
                    <idea:AccessLevelDDL
                    runat="server"
                    ID="ddlRole" />
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator6"
                    Display="Dynamic"
                    ErrorMessage="<br />Please select a security role"
                    InitialValue=""
                    ControlToValidate="ddlRole" />
                </div>
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
            <br />
        </div>
    </div>
</asp:Content>
