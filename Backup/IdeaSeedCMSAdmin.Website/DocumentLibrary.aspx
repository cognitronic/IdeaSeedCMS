<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="DocumentLibrary.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.DocumentLibrary" %>
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
            <h3>Document Library</h3>
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
                                ImageUrl='<%#(string)Eval("IsFolder")=="True"?"/images/folder.png":"/images/page.png" %>' />
                                <asp:Label 
                                ID="Label1" 
                                runat="server" 
                                Text='<%#Eval("DisplayName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </telerik:TreeListTemplateColumn>
                        <telerik:TreeListTemplateColumn >
                            <ItemTemplate>
                                <idea:LinkButton
                                runat="server"
                                ID="lbEdit"
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
                        <telerik:TreeListTemplateColumn >
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
                        <telerik:TreeListTemplateColumn >
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
