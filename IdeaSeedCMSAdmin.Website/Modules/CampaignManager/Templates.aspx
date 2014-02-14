<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Templates.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Modules.CampaignManager.Templates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="maincontainerfull">
        <div class="maincontent" id="divMain" runat="server">
            <h3>Templates</h3>
            <hr />
            <div>
                <telerik:RadGrid 
                ID="rgTemplates" 
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
                    NoMasterRecordsText="No templates were found."
                    AllowMultiColumnSorting="true">
                        <Columns>
                            <telerik:GridTemplateColumn 
                            DataField="TemplateName" 
                            HeaderText="Name" 
                            SortExpression="TemplateName"
                            UniqueName="TemplateName">
                                <ItemTemplate>
                                    <%# Eval("TemplateName")%>
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
                            DataField="EmailSubject" 
                            HeaderText="Subject" 
                            SortExpression="EmailSubject"
                            UniqueName="EmailSubject">
                                <ItemTemplate>
                                    <%# Eval("EmailSubject")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="EnteredBy" 
                            HeaderText="Entered By" 
                            SortExpression="EnteredBy"
                            UniqueName="EnteredBy">
                                <ItemTemplate>
                                    <%# GetUserFullNameByUserID((int)Eval("EnteredBy"))%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="DateCreated" 
                            HeaderText="Date Created" 
                            SortExpression="DateCreated"
                            UniqueName="DateCreated">
                                <ItemTemplate>
                                    <%# DateTime.Parse(Eval("DateCreated").ToString()).ToShortDateString()%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="LastUpdated" 
                            HeaderText="Last Updated" 
                            SortExpression="LastUpdated"
                            UniqueName="LastUpdated">
                                <ItemTemplate>
                                    <%# DateTime.Parse(Eval("LastUpdated").ToString()).ToShortDateString()%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn
                            HeaderStyle-Width="20px">
                                <ItemTemplate>
                                    <idea:LinkButton
                                    runat="server"
                                    ID="lbNewCampaign"
                                    CommandName="NewCampaign"
                                    templateid='<%# Eval("ID").ToString() %>'>
                                        <asp:Image
                                        runat="server"
                                        ID="imgNewCampaign"
                                        ToolTip="Create A New Campaign"
                                        ImageUrl="~/images/newspaper_add.png"
                                        Style="border: none;" />
                                    </idea:LinkButton>
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
                                        ToolTip="View Template"
                                        ImageUrl="~/images/smallzoom.png"
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
                                        ToolTip="Delete Template"
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
