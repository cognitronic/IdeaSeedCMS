<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsView.ascx.cs" Inherits="IdeaSeedCMSAdmin.Website.Views.NewsView" %>
<telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgNews">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgNews" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Metro" />
<div id="content">
    <div class="one">
        <h3>News</h3>
        <hr />
        <div>
            <telerik:RadGrid
            runat="server"
            ID="rgNews"
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
                NoMasterRecordsText="No Posts Found.">
                    <Columns>
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
                        DataField="PostType" 
                        HeaderText="Post Type" 
                        SortExpression="PostType"
                        UniqueName="PostType">
                            <ItemTemplate>
                                <%# Enum.GetName(typeof(IdeaSeedCMS.Core.Domain.BlogPostType), Convert.ToInt16(Eval("PostType")))%>
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
                        HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <idea:LinkButton
                                runat="server"
                                ID="lbEdit"
                                OnClick="EditEventClicked"
                                CommandName="Edit"
                                eventid='<%# Eval("ID").ToString() %>'>
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
                                linkid='<%# Eval("ID").ToString() %>'>
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

