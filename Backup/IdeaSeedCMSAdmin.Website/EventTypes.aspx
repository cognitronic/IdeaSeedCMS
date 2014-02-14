<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="EventTypes.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.EventTypes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
<div id="content">
    <div class="one">
        <h3>Event Types</h3>
        <hr />
        <div>
            <telerik:RadGrid
            runat="server"
            ID="rgList"
            AllowPaging="True"
            AutoGenerateColumns="false"
            AllowSorting="True" 
            OnItemCommand="ItemCommand"
            GridLines="None" 
            ShowStatusBar="true"
            OnNeedDataSource="NeedDataSource"
            ShowFooter="true"
            Skin="Windows7">
                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
                <MasterTableView 
                DataKeyNames="ID"
                ItemStyle-VerticalAlign="Top"
                AlternatingItemStyle-VerticalAlign="Top"
                CommandItemDisplay="Top"
                EnableNoRecordsTemplate="true"
                NoMasterRecordsText="No Banners Found.">
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
                        HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <idea:LinkButton
                                runat="server"
                                ID="lbEdit"
                                OnClick="EditItemClicked"
                                itemid='<%# Eval("ID").ToString() %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgEdit"
                                    ToolTip="View Event Type"
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
                                itemid='<%# Eval("ID").ToString() %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgDelete"
                                    ToolTip="Delete Event Type"
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
