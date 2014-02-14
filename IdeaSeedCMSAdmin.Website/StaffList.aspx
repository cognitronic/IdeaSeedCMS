<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="StaffList.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.StaffList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgStaff">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgStaff" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Metro" />
    <div id="content">
        <div class="one">
            <h3>Staff List</h3>
            <hr />
            <div>
               <telerik:RadGrid
                runat="server"
                ID="rgStaff"
                AllowPaging="True"
                AutoGenerateColumns="false"
                AllowSorting="True" 
                GridLines="None" 
                OnItemCommand="ItemCommand"
                ShowStatusBar="true"
                OnNeedDataSource="NeedDataSource"
                ShowFooter="true"
                Skin="Metro">
                    <ClientSettings EnableRowHoverStyle="true">
                    </ClientSettings>
                    <MasterTableView 
                    DataKeyNames="ID"
                    CommandItemDisplay="Top"
                    EnableNoRecordsTemplate="true"
                    NoMasterRecordsText="No Schedules Found.">
                        <Columns>
                            <telerik:GridTemplateColumn 
                            DataField="FirstName" 
                            HeaderText="First Name" 
                            SortExpression="FirstName"
                            UniqueName="FirstName">
                                <ItemTemplate>
                                    <%# Eval("FirstName")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="LastName" 
                            HeaderText="Last Name" 
                            SortExpression="LastName"
                            UniqueName="LastName">
                                <ItemTemplate>
                                    <%# Eval("LastName")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="Title" 
                            HeaderText="Title" 
                            SortExpression="Title"
                            UniqueName="Title">
                                <ItemTemplate>
                                    <%# Eval("Title")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="IsActive" 
                            HeaderText="IsActive" 
                            SortExpression="IsActive"
                            UniqueName="IsActive">
                                <ItemTemplate>
                                    <%# (bool)Eval("IsActive") == true ? "Active" : "In Active" %>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn
                            HeaderStyle-Width="20px">
                                <ItemTemplate>
                                    <idea:LinkButton
                                    runat="server"
                                    ID="lbEdit"
                                    OnClick="EditStaffClicked"
                                    itemid='<%# Eval("ID").ToString() %>'>
                                        <asp:Image
                                        runat="server"
                                        ID="imgEdit"
                                        ToolTip="View Staff"
                                        ImageUrl="~/Images/edit.gif"
                                        Style="border: none;" />
                                    </idea:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn
                            HeaderStyle-Width="20px">
                                <ItemTemplate>
                                    <idea:LinkButton
                                    runat="server"
                                    ID="lbDelete"
                                    CommandName="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete this record?')"
                                    linkid='<%# Eval("ID").ToString() %>'>
                                        <asp:Image
                                        runat="server"
                                        ID="imgDelete"
                                        ToolTip="Delete Staff"
                                        ImageUrl="~/images/delete.png"
                                        Style="border: none;" />
                                    </idea:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <PagerStyle Mode="NextPrevAndNumeric"  AlwaysVisible="true" Position="Bottom" />
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
        </div>
    </div>
</asp:Content>
