<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="TagsModal.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Modules.CampaignManager.Modals.TagsModal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function GetRadWindow()
            {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                return oWindow;
            }

            function CloseWnd()
            {
                GetRadWindow().close();
            }
        </script>
    </telerik:RadCodeBlock>
    <div>
        <h2>
            <idea:Label
            runat="server"
            ID="lblTag">
            </idea:Label>
        </h2>
    </div>
    <div>
        <telerik:RadGrid 
        ID="rgSubscribers" 
        runat="server" 
        AllowPaging="True"
        AutoGenerateColumns="false"
        AllowSorting="True"
        GridLines="None" 
        Width="650px"
        ShowStatusBar="true"
        OnNeedDataSource="NeedDataSource"
        PageSize="20"
        ShowFooter="true"
        Skin="Windows7">
            <MasterTableView 
            EnableNoRecordsTemplate="true"
            NoMasterRecordsText="All subscribers have this tag."
            ItemStyle-VerticalAlign="Top"
            AlternatingItemStyle-VerticalAlign="Top"
            DataKeyNames="ID">
                <Columns>
                    <telerik:GridTemplateColumn 
                    UniqueName="CheckBoxTemplateColumn">
                        <HeaderTemplate>
                         <idea:CheckBox 
                         ID="cbSelectAllRows" 
                         style="cursor: default;"
                         OnCheckedChanged="ToggleSelectedState" 
                         AutoPostBack="True" 
                         runat="server">
                         </idea:CheckBox>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <idea:CheckBox 
                            ID="cbSelectRow" 
                            subscriberID='<%# Eval("ID")%>'
                            runat="server">
                            </idea:CheckBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn
                    HeaderText="Email"
                    SortExpression="Email"
                    DataField="Email">
                        <ItemTemplate>
                            <%# Eval("Email") %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn
                    HeaderText="First Name"
                    SortExpression="FirstName"
                    DataField="FirstName">
                        <ItemTemplate>
                            <%# Eval("FirstName") %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn
                    HeaderText="Last Name"
                    SortExpression="LastName"
                    DataField="LastName">
                        <ItemTemplate>
                            <%# Eval("LastName") %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <PagerStyle Mode="NextPrevNumericAndAdvanced"  Position="Bottom"/>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
    <div>
        <br />
        <span>
            <asp:Button
            runat="server"
            ID="btnSave"
            OnClick="ApplyClicked"
            Text="Apply" />
        </span>
        <span>
            <asp:Button
            runat="server"
            ID="btnClose"
            OnClientClick="CloseWnd(); return false;"
            Text="Close" />
        </span>
    </div>

</asp:Content>
