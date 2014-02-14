<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Modules.CampaignManager.Tags" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ShowSubscriberModal(control, isAdd)
            {
                var oWnd = $find('<%= rwTagModal.ClientID %>');
                oWnd.setUrl("/Modules/CampaignManager/AddSubscribersTag.aspx?id=" + $(control).attr("tagid") + "&isAdd=" + isAdd);
                oWnd.show();
            }
        </script>
    </telerik:RadCodeBlock>
    <div class="maincontainerfull">
        <div class="maincontent" id="divMain" runat="server">
            <h3>Tags</h3>
            <hr />
            <div>
                <telerik:RadGrid 
                ID="rgTags" 
                runat="server" 
                AllowPaging="True"
                AutoGenerateColumns="false"
                AllowSorting="True" 
                GridLines="None" 
                ShowStatusBar="true"
                OnItemCommand="TagItemCommand"
                OnNeedDataSource="TagNeedDataSource"
                PageSize="5"
                ShowFooter="true"
                Skin="Metro">
                    <MasterTableView 
                    DataKeyNames="ID"
                    CommandItemDisplay="Top"
                    EnableNoRecordsTemplate="true"
                    NoMasterRecordsText="No tags have been entered."
                    AllowMultiColumnSorting="true">
                        <Columns>
                            <telerik:GridTemplateColumn 
                            DataField="Tag" 
                            HeaderText="Tag" 
                            SortExpression="Tag"
                            UniqueName="Tag">
                                <ItemTemplate>
                                    <%# Eval("Tag")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <idea:TextBox
                                    runat="server"
                                    ID="tbTag"
                                    Text='<%# Eval("Tag").ToString() %>'
                                    width="400px">
                                    </idea:TextBox>
                                    <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="rfvTAg"
                                    InitialValue=""
                                    Display="Dynamic"
                                    ErrorMessage="Please enter a tag"
                                    ControlToValidate="tbTag">
                                    </asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="IsPublic" 
                            HeaderText="Is Public" 
                            SortExpression="IsPublic"
                            UniqueName="IsPublic">
                                <ItemTemplate>
                                    <%# Eval("IsPublic")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <idea:CheckBox
                                    runat="server"
                                    ID="cbIsPublic"
                                    Checked='<%# Eval("IsPublic") %>'/>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="ID" 
                            HeaderText="Total Subscribers" 
                            SortExpression="ID"
                            UniqueName="ID">
                                <ItemTemplate>
                                    <%# TotalSubscribers((int)Eval("ID")) %>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn
                            HeaderStyle-Width="20px">
                                <ItemTemplate>
                                    <idea:LinkButton
                                    runat="server"
                                    ID="lbAddUsers"
                                    CommandName="AddUser"
                                    OnClick="AddUserClicked"
                                    OnClientClick="ShowSubscriberModal(this, 'true')"
                                    tagid='<%# Eval("id").ToString() %>'>
                                        <asp:Image
                                        runat="server"
                                        ID="imgAddUser"
                                        ToolTip="Add this tag to one or more subscribers."
                                        ImageUrl="~/images/user_add.png"
                                        Style="border: none;" />
                                    </idea:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn
                            HeaderStyle-Width="20px">
                                <ItemTemplate>
                                    <idea:LinkButton
                                    runat="server"
                                    ID="lbRemoveUsers"
                                    CommandName="RemoveUser"
                                    OnClick="RemoveUserClicked"
                                    OnClientClick="ShowSubscriberModal(this, 'false')"
                                    tagid='<%# Eval("id").ToString() %>'>
                                        <asp:Image
                                        runat="server"
                                        ID="imgRemoveUser"
                                        ToolTip="Remove one or more subscribers from this tag."
                                        ImageUrl="~/images/user_delete.png"
                                        Style="border: none;" />
                                    </idea:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn
                            HeaderStyle-Width="20px">
                                <ItemTemplate>
                                    <idea:LinkButton
                                    runat="server"
                                    ID="lbEdit"
                                    CommandName="Edit"
                                    tagid='<%# Eval("id").ToString() %>'>
                                        <asp:Image
                                        runat="server"
                                        ID="imgEdit"
                                        ToolTip="Edit Tag"
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
                                    tagid='<%# Eval("id").ToString() %>'>
                                        <asp:Image
                                        runat="server"
                                        ID="imgDelete"
                                        ToolTip="Delete Tag"
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
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow 
            ID="rwTagModal" 
            Title="Manage Subscribers"
            Height="600px"
            Width="710px"
            VisibleStatusbar="false"
            ReloadOnShow="true"
            ShowContentDuringLoad="false"
            style="overflow-x: hidden;"
            Modal="true"
            runat="server" 
            Skin="Windows7">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

</asp:Content>
