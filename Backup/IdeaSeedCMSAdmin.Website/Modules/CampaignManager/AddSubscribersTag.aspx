<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AddSubscribersTag.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Modules.CampaignManager.AddSubscribersTag" %>
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
    <div runat="server" id="divFilters">
        <h3>
            <idea:Label
            runat="server"
            ID="lblTag">
            </idea:Label>
        </h3>
        <hr />
        
        <span>
            &nbsp;Search Column:&nbsp;
            <idea:DropDownList
            runat="server"
            EmptyMessage="Select"
            Width="75px"
            style="padding: 0 !important;"
            Skin="Metro"
            ID="ddlSearchColumn">
                <Items>
                    <telerik:RadComboBoxItem
                    runat="server"
                    Text=""
                    Value="" />
                    <telerik:RadComboBoxItem
                    runat="server"
                    Text="Email"
                    Value="Email" />
                    <telerik:RadComboBoxItem
                    runat="server"
                    Text="First Name"
                    Value="FirstName" />
                    <telerik:RadComboBoxItem
                    runat="server"
                    Text="Last Name"
                    Value="LastName" />
                </Items>
            </idea:DropDownList>
        </span>
        <span>
            <idea:TextBox
            Width="250px"
            Height="22px"
            style="padding: 0 !important;"
            runat="server"
            Skin="Metro"
            ID="tbSearch">
            </idea:TextBox>
        </span>
        <span>
            &nbsp;Date Registered:&nbsp;
            <telerik:RadDatePicker 
            ID="tbStartDate"
            Skin="Windows7"
            Width="125px"
            runat="server">
                <DateInput ID="diStartDate" runat="server"
                    DateFormat="MM/dd/yyyy"></DateInput>
            </telerik:RadDatePicker>
            &nbsp;to&nbsp;
            <telerik:RadDatePicker 
            ID="tbEndDate"
            Skin="Windows7"
            Width="125px"
            runat="server">
                <DateInput ID="diEndDate" runat="server"
                    DateFormat="MM/dd/yyyy"></DateInput>
            </telerik:RadDatePicker>
        </span>
        <span>
            <idea:LinkButton
            runat="server"
            ID="lbSearchSubscribers"
            CssClass="button small round blue"
            OnClick="SearchSubscribersClicked">
                Search
            </idea:LinkButton>
        </span>
    </div>
    <div class="clear"></div>
    <div>
        <telerik:RadGrid 
        ID="rgSubscribers" 
        runat="server" 
        AllowPaging="True"
        AutoGenerateColumns="false"
        AllowSorting="True"
        GridLines="None" 
        Width="100%"
        ShowStatusBar="true"
        OnNeedDataSource="NeedDataSource"
        PageSize="20"
        ShowFooter="true"
        Skin="Metro">
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
    <div style="margin-bottom: 20px;">
        <br />
        <span>
            <asp:Button
            runat="server"
            ID="btnSave"
            CssClass="button small round blue"
            OnClick="ApplyClicked"
            Text="Apply" />
        </span>
        <span>
            <idea:LinkButton
            runat="server"
            CssClass="button small round blue"
            ID="lbCancel"
            OnClick="CancelClicked">
                Return To Previous Page
            </idea:LinkButton>
        </span>
    </div>
</asp:Content>
