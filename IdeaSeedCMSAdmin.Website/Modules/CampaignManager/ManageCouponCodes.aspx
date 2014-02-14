<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ManageCouponCodes.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Modules.CampaignManager.ManageCouponCodes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgCodes">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgCodes" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lbSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgCodes" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />
    <h3>Manage Coupon Codes</h3>
    <hr />
    <div>
        <span>
            Code:&nbsp;&nbsp;
            <idea:TextBox
            runat="server"
            Width="100px"
            ID="tbCodeFilter" />
        </span>
        <span>
            &nbsp;&nbsp;Coupon:&nbsp:&nbsp;
            <idea:CouponsDDL
            runat="server"
            ID="ddlCouponFilter" />
        </span>
        <span>
            &nbsp;&nbsp;Is Assigned:&nbsp;&nbsp;
            <idea:DropDownList
            runat="server"
            ID="ddlIsAssignedFilter"
            Skin="Metro">
                <Items>
                    <telerik:RadComboBoxItem
                    runat="server"
                    Text="-- Select --"
                    Value="" />
                    <telerik:RadComboBoxItem
                    runat="server"
                    Text="Yes"
                    Value="True" />
                    <telerik:RadComboBoxItem
                    runat="server"
                    Text="No"
                    Value="False" />
                </Items>
            </idea:DropDownList>
        </span>
        <span>
            &nbsp;&nbsp;Is Redeemed:&nbsp;&nbsp;
            <idea:DropDownList
            runat="server"
            ID="ddlRedeemedFilter"
            Skin="Metro">
                <Items>
                    <telerik:RadComboBoxItem
                    runat="server"
                    Text="-- Select --"
                    Value="" />
                    <telerik:RadComboBoxItem
                    runat="server"
                    Text="Yes"
                    Value="True" />
                    <telerik:RadComboBoxItem
                    runat="server"
                    Text="No"
                    Value="False" />
                </Items>
            </idea:DropDownList>
        </span>&nbsp;
        <span>
            <idea:LinkButton
            runat="server"
            CssClass="button small round blue"
            ID="lbSearch"
            OnClick="SearchClicked">
                <b>Search</b>
            </idea:LinkButton>
        </span>
    </div>
    <br />
    <div class="maincontainerfull">
        <div class="maincontent" id="divMain" runat="server">
            <div>
                <telerik:RadGrid 
                ID="rgCodes" 
                runat="server" 
                AllowPaging="True"
                AutoGenerateColumns="false"
                AllowSorting="True" 
                GridLines="None" 
                ShowStatusBar="true"
                OnItemCommand="ItemCommand"
                OnNeedDataSource="NeedDataSource"
                PageSize="5"
                ShowFooter="true"
                Skin="Metro">
                    <MasterTableView 
                    DataKeyNames="ID"
                    CommandItemDisplay="None"
                    EnableNoRecordsTemplate="true"
                    NoMasterRecordsText="No codes were found."
                    AllowMultiColumnSorting="true">
                        <Columns>
                            <telerik:GridTemplateColumn 
                            DataField="Code" 
                            HeaderText="Code" 
                            SortExpression="Code"
                            UniqueName="Code">
                                <ItemTemplate>
                                    <%# Eval("Code")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="CodeText" 
                            HeaderText="CodeText" 
                            SortExpression="CodeText"
                            UniqueName="CodeText">
                                <ItemTemplate>
                                    <%# Eval("CodeText")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="Coupon.Name" 
                            HeaderText="Coupon" 
                            SortExpression="Coupon.Name"
                            UniqueName="Coupon.Name">
                                <ItemTemplate>
                                    <%# Eval("Coupon.Name")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="IsAssigned" 
                            HeaderText="Is Assigned" 
                            SortExpression="IsAssigned"
                            UniqueName="IsAssigned">
                                <ItemTemplate>
                                    <%# Eval("IsAssigned")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="AssignedDate" 
                            HeaderText="Assigned Redeemed" 
                            SortExpression="AssignedDate"
                            UniqueName="AssignedDate">
                                <ItemTemplate>
                                    <%# Eval("AssignedDate") == null ? "--" : DateTime.Parse(Eval("AssignedDate").ToString()).ToShortDateString()%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="IsRedeemed" 
                            HeaderText="Is Redeemed" 
                            SortExpression="IsRedeemed"
                            UniqueName="IsRedeemed">
                                <ItemTemplate>
                                    <%# Eval("IsRedeemed").ToString() == "False" ? "" : "<font color='green'><b>Yes</b></font>" %>
                                    <idea:LinkButton
                                    runat="server"
                                    ID="lbIsRedeemed"
                                    OnClick="RedeemedClicked"
                                    itemid='<%# Eval("ID") %>'
                                    Visible='<%# Eval("IsRedeemed").ToString() == "False" ? true : false %>'>
                                        Redeem Now
                                    </idea:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="RedeemedDate" 
                            HeaderText="Date Redeemed" 
                            SortExpression="RedeemedDate"
                            UniqueName="RedeemedDate">
                                <ItemTemplate>
                                    <%# Eval("RedeemedDate") == null ? "--" : DateTime.Parse(Eval("RedeemedDate").ToString()).ToString()%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <ExpandCollapseColumn 
                        Resizable="False" 
                        Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn 
                        Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                    <PagerStyle Position="Bottom" Mode="NextPrevNumericAndAdvanced"/>
                </telerik:RadGrid>
            </div>
        </div>
    </div><br />
</asp:Content>
