<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Pages.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Pages" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rtlPages">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtlPages" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />
    <div id="content">
        <div class="one">
            <h3>Pages</h3>
            <hr />
            <div>
                <idea:LinkButton
                runat="server"
                ID="lbAddRootPage"
                OnClick="AddRootPageClicked">
                    <asp:Image
                    runat="server"
                    ID="imgRootPage"
                    ImageUrl="~/Images/add.png" /> Add Root Page
                </idea:LinkButton>
            </div>
            <div>
                <telerik:RadTreeList 
                ID="rtlPages" 
                runat="server"
                ParentDataKeyNames="ParentID" 
                DataKeyNames="ID" 
                AutoGenerateColumns="false"
                GridLines="None" 
                Skin="Metro"
                OnNeedDataSource="NeedDataSource">
                    <ClientSettings>
                        <Selecting 
                        AllowItemSelection="true" />
                    </ClientSettings>
                    <Columns>
                        <telerik:TreeListTemplateColumn 
                        UniqueName="DisplayName" 
                        DataField="DisplayName"
                        HeaderText="Name">
                            <HeaderStyle Width="400px" />
                            <ItemTemplate>
                                <asp:Image 
                                ID="FileType" 
                                runat="server" 
                                AlternateText="Web Page" 
                                ImageUrl="~/Images/page.png" />
                                <asp:Label 
                                ID="Label1" 
                                runat="server" 
                                Text='<%#Eval("DisplayName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </telerik:TreeListTemplateColumn>
                        <telerik:TreeListTemplateColumn 
                        UniqueName="IsActive" 
                        DataField="IsActive"
                        HeaderText="Status">
                            <ItemTemplate>
                                <%# (bool)Eval("IsActive") == true ? "<span style='color: #009900;'>Online</span>" : "<span style='color: #ff0000;'>Offline</span>"%>
                            </ItemTemplate>
                        </telerik:TreeListTemplateColumn>
                        <telerik:TreeListTemplateColumn 
                        HeaderStyle-Width="55px" >
                            <ItemTemplate>
                                <idea:LinkButton
                                runat="server"
                                ID="lbEdit"
                                externalURL='<%# Eval("ExternalURL") %>'
                                onclick="EditClicked"
                                itemID='<%# Eval("ID") %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgEdit"
                                    ToolTip="Edit Page"
                                    ImageUrl="~/Images/edit.gif" />
                                    Edit
                                </idea:LinkButton>
                            </ItemTemplate>
                        </telerik:TreeListTemplateColumn>
                        <telerik:TreeListTemplateColumn 
                        HeaderText="Actions"
                        HeaderStyle-Width="75px" >
                            <ItemTemplate>
                                <idea:LinkButton
                                runat="server"
                                ID="lbDelete"
                                onclick="DeleteClicked"
                                OnClientClick="return confirm('Are you sure you want to delete this page??')"
                                itemID='<%# Eval("ID") %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgDelete"
                                    ToolTip="Delete Page"
                                    ImageUrl="~/Images/delete.png" />
                                    Delete
                                </idea:LinkButton>
                            </ItemTemplate>
                        </telerik:TreeListTemplateColumn>
                        <telerik:TreeListTemplateColumn 
                        HeaderStyle-Width="115px" >
                            <ItemTemplate>
                                <idea:LinkButton
                                runat="server"
                                ID="lbAdd"
                                onclick="AddSubPageClicked"
                                itemID='<%# Eval("ID") %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgAdd"
                                    ToolTip="Add Sub Page"
                                    ImageUrl="~/Images/add.png" />
                                    Add Sub Page
                                </idea:LinkButton>
                            </ItemTemplate>
                        </telerik:TreeListTemplateColumn>
                    </Columns>
                </telerik:RadTreeList>
            </div>
        </div>
    </div>
</asp:Content>
