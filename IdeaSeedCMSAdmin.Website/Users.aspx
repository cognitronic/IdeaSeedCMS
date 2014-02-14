<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Users" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div id="content">
        <div class="one">
            <div runat="server" id="divContent">
                <h3>Users</h3>
                <hr />
                <div>
                   <telerik:RadGrid
                    runat="server"
                    ID="rgUsers"
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
                        NoMasterRecordsText="No Users Found.">
                            <Columns>
                                <telerik:GridTemplateColumn 
                                DataField="LastName" 
                                HeaderText="Name" 
                                SortExpression="LastName"
                                UniqueName="LastName">
                                    <ItemTemplate>
                                        <%# Eval("FirstName").ToString() + " " + Eval("LastName").ToString()%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                DataField="Email" 
                                HeaderText="Email" 
                                SortExpression="Email"
                                UniqueName="Email">
                                    <ItemTemplate>
                                        <%# Eval("Email")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                DataField="AccessLevel" 
                                HeaderText="Role" 
                                SortExpression="AccessLevel"
                                UniqueName="AccessLevel">
                                    <ItemTemplate>
                                        <%# Enum.GetName(typeof(IdeaSeedCMS.Core.Domain.AccessLevel), Convert.ToInt16(Eval("AccessLevel")))%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn
                                HeaderStyle-Width="20px">
                                    <ItemTemplate>
                                        <idea:LinkButton
                                        runat="server"
                                        ID="lbEdit"
                                        CommandName="Edit"
                                        itemid='<%# Eval("ID").ToString() %>'>
                                            <asp:Image
                                            runat="server"
                                            ID="imgEdit"
                                            ToolTip="Edit Blog"
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
                                        OnClientClick="return confirm('Are you sure you want to delete this record?')"
                                        itemid='<%# Eval("ID").ToString() %>'>
                                            <asp:Image
                                            runat="server"
                                            ID="imgDelete"
                                            ToolTip="Delete Blog"
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
    </div>
</asp:Content>
