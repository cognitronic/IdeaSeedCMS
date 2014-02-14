<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Banners.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Banners" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
<telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgList">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgList" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />
<div id="content">
    <div class="one">
        <h3>Banner List</h3>
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
            Skin="Metro">
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
                        DataField="Path" 
                        HeaderText="Image" 
                        UniqueName="Upload">
                            <ItemTemplate>
                                <telerik:RadBinaryImage 
                                runat="server" 
                                ID="RadBinaryImage1" 
                                ImageUrl='<%#Eval("Path") %>'
                                AutoAdjustImageControlSize="false" 
                                Height="80px" 
                                Width="80px" 
                                ToolTip='<%#Eval("Title", "Photo of {0}") %>'
                                AlternateText='<%#Eval("Title", "Photo of {0}") %>' />
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
                        DataField="ToolTip" 
                        HeaderText="Tool Tip" 
                        SortExpression="ToolTip"
                        UniqueName="ToolTip">
                            <ItemTemplate>
                                <%# Eval("ToolTip")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn
                        HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <idea:LinkButton
                                runat="server"
                                ID="lbEdit"
                                OnClick="EditBannerClicked"
                                itemid='<%# Eval("ID").ToString() %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgEdit"
                                    ToolTip="View Banner"
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
                                OnClick="DeleteClicked"
                                OnClientClick="return confirm('Are you sure you want to delete this record?')"
                                itemid='<%# Eval("ID").ToString() %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgDelete"
                                    ToolTip="Delete Banner"
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
