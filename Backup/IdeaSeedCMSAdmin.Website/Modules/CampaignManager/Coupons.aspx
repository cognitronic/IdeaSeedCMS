<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Coupons.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Modules.CampaignManager.Coupons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="maincontainerfull">
        <div class="maincontent" id="divMain" runat="server">
            <h3>Coupons</h3>
            <hr />
            <div>
                <telerik:RadGrid 
                ID="rgCoupons" 
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
                    CommandItemDisplay="Top"
                    EnableNoRecordsTemplate="true"
                    NoMasterRecordsText="No coupons were found."
                    AllowMultiColumnSorting="true">
                        <Columns>
                            <telerik:GridTemplateColumn 
                            DataField="Name" 
                            HeaderText="Name" 
                            SortExpression="Name"
                            UniqueName="Name">
                                <ItemTemplate>
                                    <%# Eval("Name")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="Description" 
                            HeaderText="Description" 
                            SortExpression="Description"
                            UniqueName="Description">
                                <ItemTemplate>
                                    <%# Eval("Description")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="StartDate" 
                            HeaderText="Start Date" 
                            SortExpression="StartDate"
                            UniqueName="StartDate">
                                <ItemTemplate>
                                    <%# DateTime.Parse(Eval("StartDate").ToString()).ToShortDateString()%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="EndDate" 
                            HeaderText="End Date" 
                            SortExpression="EndDate"
                            UniqueName="EndDate">
                                <ItemTemplate>
                                    <%# DateTime.Parse(Eval("EndDate").ToString()).ToShortDateString()%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="IsActive" 
                            HeaderText="Status" 
                            SortExpression="IsActive"
                            UniqueName="IsActive">
                                <ItemTemplate>
                                    <%# Eval("IsActive").ToString() == "True" ? "Active" : "Inactive"%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn
                            HeaderStyle-Width="20px">
                                <ItemTemplate>
                                    <idea:LinkButton
                                    runat="server"
                                    ID="lbView"
                                    CommandName="View"
                                    templateid='<%# Eval("ID").ToString() %>'>
                                        <asp:Image
                                        runat="server"
                                        ID="imgView"
                                        ToolTip="Edit Coupon"
                                        ImageUrl="~/images/edit.gif"
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
                                    OnClientClick="return confirm('Are you sure you want to delete this item?');"
                                    templateid='<%# Eval("ID").ToString() %>'>
                                        <asp:Image
                                        runat="server"
                                        ID="imgDelete"
                                        ToolTip="Delete Coupon"
                                        ImageUrl="~/images/delete.png"
                                        Style="border: none;" />
                                    </idea:LinkButton>
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
