<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentLibraryView.ascx.cs" Inherits="IdeaSeedCMSAdmin.Website.Views.DocumentLibraryView" %>

    <telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rtlPages">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtlPages" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Metro" />
    <div id="content">
        <div class="one">
            <h3>Document Library</h3>
            <hr />
            <div>
                <idea:LinkButton
                runat="server"
                ID="lbAddRootFolder"
                OnClick="AddRootFolderClicked">
                    <asp:Image
                    runat="server"
                    ID="imgRootDoc"
                    ImageUrl="~/Images/add.png" /> Add Root Folder
                </idea:LinkButton>
            </div>
            <div>
                <telerik:RadTreeList 
                ID="rtlPages" 
                runat="server"
                ParentDataKeyNames="ParentID" 
                DataKeyNames="ID" 
                AutoGenerateColumns="false"
                OnItemDataBound="ItemCreated"
                GridLines="None" 
                Skin="Metro"
                OnNeedDataSource="NeedDataSource">
                    <ClientSettings>
                        <Selecting 
                        AllowItemSelection="true" />
                    </ClientSettings>
                    <Columns>
                        <telerik:TreeListTemplateColumn 
                        UniqueName="Name" 
                        DataField="Name"
                        HeaderText="Library">
                            <HeaderStyle Width="400px" />
                            <ItemTemplate>
                                <asp:Image 
                                ID="FileType" 
                                runat="server" 
                                AlternateText="Web Page" 
                                ImageUrl='<%#(bool)Eval("IsFolder")==true?"/images/folder.png":"/images/page.png" %>' />
                                <asp:HyperLink 
                                ID="lbName"
                                NavigateUrl='<%#Eval("Path") %>' 
                                Target="_blank"
                                runat="server" 
                                Text='<%#Eval("Name") %>'>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </telerik:TreeListTemplateColumn>
                        <telerik:TreeListTemplateColumn
                        UniqueName="EnteredBy" 
                        DataField="EnteredBy"
                        HeaderText="Created By">
                            <ItemTemplate>
                                <%# Eval("EnteredByRef.FirstName").ToString() + " " + Eval("EnteredByRef.LastName").ToString()%>
                            </ItemTemplate>
                        </telerik:TreeListTemplateColumn>
                        <telerik:TreeListTemplateColumn
                        UniqueName="DateCreated" 
                        DataField="DateCreated"
                        HeaderText="Date Created">
                            <ItemTemplate>
                                <%# DateTime.Parse(Eval("DateCreated").ToString()).ToShortDateString() %>
                            </ItemTemplate>
                        </telerik:TreeListTemplateColumn>
                        <telerik:TreeListTemplateColumn
                        UniqueName="LastUpdated" 
                        DataField="LastUpdated"
                        HeaderText="Last Updated">
                            <ItemTemplate>
                                <%# DateTime.Parse(Eval("LastUpdated").ToString()).ToShortDateString()%>
                            </ItemTemplate>
                        </telerik:TreeListTemplateColumn>
                        <telerik:TreeListTemplateColumn
                        HeaderStyle-Width="55px" 
                        UniqueName="AddSub" >
                            <ItemTemplate>
                                <idea:LinkButton
                                runat="server"
                                ID="lbAdd"
                                isfolder='<%#Eval("IsFolder") %>'
                                onclick="AddSubPageClicked"
                                itemID='<%# Eval("ID") %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgAdd"
                                    ToolTip="Add Sub Page"
                                    ImageUrl="~/Images/folder_add.png" />
                                    Add
                                </idea:LinkButton>
                            </ItemTemplate>
                        </telerik:TreeListTemplateColumn>
                        <telerik:TreeListTemplateColumn
                        HeaderText="Actions"
                        HeaderStyle-Width="55px" >
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
                        <telerik:TreeListTemplateColumn 
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
                    </Columns>
                </telerik:RadTreeList>
            </div>
        </div>
    </div>