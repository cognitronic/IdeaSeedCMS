<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="CampaignDashboard.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Modules.CampaignManager.CampaignDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgCampaignHistory">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="mpCampaignDetails" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="tsCampaignDetails"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="mpCampaignDetails">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="mpCampaignDetails" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="tsCampaignDetails">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="mpCampaignDetails" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Metro" />
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ShowEditForm(id, rowIndex)
            {
                var grid = $find("<%= rgCampaignHistory.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("/Campaign-Manager/Campaign-Viewer?cid=" + id, "rwViewCampaign");
                return false;
            }
        </script>
    </telerik:RadCodeBlock>
    <div class="maincontainerfull">
        <div class="maincontent" id="divMain" runat="server">
            <h3>Dashboard</h3>
            <hr />
            <div>
                <telerik:RadGrid 
                ID="rgCampaignHistory" 
                runat="server" 
                AllowPaging="True"
                AutoGenerateColumns="false"
                AllowSorting="True" 
                GridLines="None" 
                ShowStatusBar="true"
                OnItemCommand="UserItemCommand"
                OnNeedDataSource="UserNeedDataSource"
                OnItemCreated="ItemCreated"
                ShowGroupPanel="false" 
                PageSize="5"
                ShowFooter="true"
                Skin="Metro">
                    <ClientSettings 
                    EnablePostBackOnRowClick="true" 
                    AllowColumnsReorder="True"
                    Selecting-AllowRowSelect="true" 
                    ReorderColumnsOnClient="True">
                    </ClientSettings>
                    <MasterTableView 
                    DataKeyNames="ID"
                    CommandItemDisplay="None"
                    EnableNoRecordsTemplate="true"
                    NoMasterRecordsText="No campaigns have been entered."
                    AllowMultiColumnSorting="true">
                        <Columns>
                            <telerik:GridTemplateColumn 
                            DataField="campaignname" 
                            HeaderText="Campaign" 
                            SortExpression="campaignname"
                            UniqueName="campaignname">
                                <ItemTemplate>
                                    <%# Eval("campaignname") %>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="description" 
                            HeaderText="Description" 
                            SortExpression="description" 
                            UniqueName="description">
                                <ItemTemplate>
                                    <%# Eval("description")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="emailsubject" 
                            HeaderText="Subject" 
                            SortExpression="emailsubject" 
                            UniqueName="emailsubject">
                                <ItemTemplate>
                                    <%# Eval("emailsubject")%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="datetimesent" 
                            HeaderText="Date Sent" 
                            SortExpression="datetimesent" 
                            UniqueName="datetimesent">
                                <ItemTemplate>
                                    <%# DateTime.Parse(Eval("datetimesent").ToString()).ToString()%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="sentby" 
                            HeaderText="Sent By" 
                            SortExpression="sentby" 
                            UniqueName="sentby">
                                <ItemTemplate>
                                    <%#  FormatSentBy(Eval("sentby").ToString())%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <asp:HyperLink
                                    runat="server"
                                    ID="lbViewCampaign"
                                    campaignid='<%# Eval("id").ToString() %>'>
                                        <asp:Image
                                        runat="server"
                                        ID="imgViewCampaign"
                                        ToolTip="View Campaign"
                                        ImageUrl="~/images/smallzoom.png"
                                        Style="border: none;" />
                                    </asp:HyperLink>
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
                    <PagerStyle Mode="NextPrevNumericAndAdvanced" />
                </telerik:RadGrid>
                <%--<asp:SqlDataSource 
                ID="sdsCampaignHistory" 
                runat="server"
                ConnectionString="<%$ ConnectionStrings:DataPathConnectionString%>"
                SelectCommand="select * from campaignhistory order by datetimesent desc" 
                SelectCommandType="Text">
                </asp:SqlDataSource>--%>
            </div>
        </div>
    </div><br />
    <div class="maincontainerfull">
        <telerik:RadTabStrip
        ID="tsCampaignDetails"
        MultiPageID="mpCampaignDetails"
        Skin="Metro"
        Align="Left"
        BorderStyle="None"
        AutoPostBack="true"
        OnTabClick="TabClicked" 
        runat="server">
            <Tabs>
                <telerik:RadTab 
                ID="tabOverview" 
                runat="server" 
                PageViewID="pvOverview" 
                Text="Overview" 
                ToolTip="Campaign Overview"
                Value="0">
                </telerik:RadTab>
                <telerik:RadTab 
                ID="tabForwards" 
                runat="server" 
                PageViewID="pvForwards" 
                Text="Forwards" 
                ToolTip="# of forwards this campaign"
                Value="1">
                </telerik:RadTab>
                <telerik:RadTab 
                ID="tabOptOut" 
                runat="server" 
                PageViewID="pvOptOut" 
                Text="Opt Outs" 
                Value="3">
                </telerik:RadTab>
                <telerik:RadTab 
                ID="tabError" 
                runat="server" 
                PageViewID="pvError" 
                Text="Errors" 
                Value="4">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage 
        ID="mpCampaignDetails" 
        runat="server"
        style="border-left: 1px solid #cccccc; border-bottom: 1px solid #cccccc; border-right: 1px solid #cccccc;">
            <telerik:RadPageView 
            ID="pvOverview" 
            runat="server">
                <div style="padding: 10px;">
                    <div style='float: left; width: 200px; padding: 10px;'>
                         <div>
                            <span>
                                Total Messages Sent:
                            </span>
                            <span style="float: right; color: #0067B8;">
                                <idea:Label
                                runat="server"
                                ID="lblTotalMessagesSent">
                                </idea:Label>
                            </span>
                        </div><br />
                         <div>
                            <span>
                                Total Errors:
                            </span>
                            <span style="float: right; color: #0067B8;">
                                <idea:Label
                                runat="server"
                                ID="lblTotalErrors">
                                </idea:Label>
                            </span>
                        </div><br />
                        <div>
                            <span>
                                Total Recipients:
                            </span>
                            <span style="float: right; color: #0067B8;">
                                <idea:Label
                                runat="server"
                                ID="lblTotalRecipients">
                                </idea:Label>
                            </span>
                        </div><br />
                        <div>
                            <span>
                                Unique Email Reads:
                            </span>
                            <span style="float: right; color: #0067B8;">
                                <idea:Label
                                runat="server"
                                ID="lblUniqueEmailReads">
                                </idea:Label>
                            </span>
                        </div><br />
                        <div>
                            <span>
                                Total Email Reads:
                            </span>
                            <span style="float: right; color: #0067B8;">
                                <idea:Label
                                runat="server"
                                ID="lblTotalEmailReads">
                                </idea:Label>
                            </span>
                        </div><br />
                        <div>
                            <span>
                                Unique Link Clicks:
                            </span>
                            <span style="float: right; color: #0067B8;">
                                <idea:Label
                                runat="server"
                                ID="lblUniqueLinkClicks">
                                </idea:Label>
                            </span>
                        </div><br />
                        <div>
                            <span>
                                Total Link Clicks:
                            </span>
                            <span style="float: right; color: #0067B8;">
                                <idea:Label
                                runat="server"
                                ID="lblTotalLinkClicks">
                                </idea:Label>
                            </span>
                        </div>
                    </div>
                    <div style='float: left; width: 555px; padding: 10px; margin-left: 70px;'>
                        <div>
                            <span>
                                <telerik:RadChart 
                                ID="rcLinksResult" 
                                ChartTitle-TextBlock-Text="Link Results"
                                runat="server" 
                                DefaultType="Bar" 
                                Width="600px" 
                                PlotArea-YAxis-Appearance-MinorGridLines-Visible="false"
                                OnItemDataBound="OverviewItemDataBound"
                                AutoTextWrap="true"
                                Skin="LightBlue">
                                <Appearance Dimensions-Width="600px">
                                </Appearance>
                                <Series>
                                </Series>
                            </telerik:RadChart>
                            </span>
                        </div>
                    </div>
                </div>
                <div style="clear: left;"></div>
            </telerik:RadPageView>
            <telerik:RadPageView 
            ID="pvForwards" 
            runat="server">
                <div><br />
                    <telerik:RadGrid 
                    ID="rgForwards" 
                    runat="server" 
                    AllowPaging="True"
                    AutoGenerateColumns="false"
                    AllowSorting="True" 
                    GridLines="None" 
                    ShowStatusBar="true"
                    OnNeedDataSource="ForwardsNeedDataSource"
                    PageSize="50"
                    ShowFooter="true"
                    Skin="Metro">
                        <MasterTableView 
                        DataKeyNames="ID"
                        CommandItemDisplay="None"
                        EnableNoRecordsTemplate="true"
                        NoMasterRecordsText="This campaign has not been forwarded to a friend">
                            <Columns>
                                <telerik:GridTemplateColumn 
                                DataField="SubscriberRef.Email" 
                                HeaderText="Email" 
                                SortExpression="SubscriberRef.Email"
                                UniqueName="SubscriberRef.Email">
                                    <ItemTemplate>
                                        <%# Eval("SubscriberRef.Email")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                DataField="DateForwarded" 
                                HeaderText="Date Forwarded" 
                                SortExpression="DateForwarded" 
                                UniqueName="DateForwarded">
                                    <ItemTemplate>
                                        <%# Eval("DateForwarded")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                DataField="emails" 
                                HeaderText="Addresses Forwarded To" 
                                SortExpression="emails" 
                                UniqueName="emails">
                                    <ItemTemplate>
                                        <%# Eval("emails")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <PagerStyle Mode="NextPrevNumericAndAdvanced" />
                    </telerik:RadGrid>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView 
            ID="pvOptOut" 
            runat="server">
               <div><br />
                    <telerik:RadGrid 
                    ID="rgOptOut" 
                    runat="server" 
                    AllowPaging="True"
                    AutoGenerateColumns="false"
                    AllowSorting="True" 
                    GridLines="None" 
                    ShowStatusBar="true"
                    OnNeedDataSource="OptOutNeedDataSource"
                    PageSize="50"
                    ShowFooter="true"
                    Skin="Metro">
                        <MasterTableView 
                        DataKeyNames="ID"
                        CommandItemDisplay="None"
                        EnableNoRecordsTemplate="true"
                        NoMasterRecordsText="No one opted out this campaign.....yah!">
                            <Columns>
                                <telerik:GridTemplateColumn 
                                DataField="Subscriber.Email" 
                                HeaderText="Email" 
                                SortExpression="Subscriber.Email"
                                UniqueName="Subscriber.Email">
                                    <ItemTemplate>
                                        <%# Eval("Subscriber.Email")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                DataField="dateunsubscribed" 
                                HeaderText="Date Unsubscribed" 
                                SortExpression="dateunsubscribed" 
                                UniqueName="dateunsubscribed">
                                    <ItemTemplate>
                                        <%# Eval("dateunsubscribed")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <PagerStyle Mode="NextPrevNumericAndAdvanced" />
                    </telerik:RadGrid>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView 
            ID="pvError" 
            runat="server">
               <div><br />
                    <telerik:RadGrid 
                    ID="rgErrors" 
                    runat="server" 
                    AllowPaging="True"
                    AutoGenerateColumns="false"
                    AllowSorting="True" 
                    GridLines="None" 
                    ShowStatusBar="true"
                    OnItemCommand="ErrorItemCommand"
                    OnNeedDataSource="ErrorNeedDataSource"
                    PageSize="50"
                    ShowFooter="true"
                    Skin="Metro">
                        <MasterTableView 
                        DataKeyNames="ID"
                        CommandItemDisplay="None"
                        EnableNoRecordsTemplate="true"
                        NoMasterRecordsText="No errors found">
                            <Columns>
                            <telerik:GridTemplateColumn 
                            UniqueName="CheckBoxTemplateColumn">
                                <HeaderTemplate>
                                 <idea:CheckBox 
                                 ID="cbSelectAllRows" 
                                 style="cursor: default;"
                                 OnCheckedChanged="ToggleSelectedState" 
                                 AutoPostBack="True" 
                                 runat="server">
                                 </idea:CheckBox>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <idea:CheckBox 
                                    ID="cbSelectRow" 
                                    itemid='<%# Eval("ID")%>'
                                    email='<%# Eval("Email")%>'
                                    runat="server">
                                    </idea:CheckBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                DataField="Email" 
                                HeaderText="Email" 
                                SortExpression="Email"
                                UniqueName="Email">
                                    <ItemTemplate>
                                        <idea:Label
                                        runat="server"
                                        ID="lblEmail"
                                        Text='<%# Eval("Email")%>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                DataField="Message" 
                                HeaderText="Message" 
                                SortExpression="Message" 
                                UniqueName="Message">
                                    <ItemTemplate>
                                        <%# Eval("Message")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn 
                                DataField="Removed" 
                                HeaderText="Removed?" 
                                SortExpression="Removed"
                                UniqueName="Removed">
                                    <ItemTemplate>
                                        <idea:Label
                                        runat="server"
                                        ID="lblRemoved"
                                        Text='<%# (bool)Eval("Removed") ? "Yes" : "No" %>' />
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
                                        itemid='<%# Eval("ID").ToString() %>'>
                                            <asp:Image
                                            runat="server"
                                            ID="imgDelete"
                                            ToolTip="Delete Subscriber"
                                            ImageUrl="~/images/delete.png"
                                            Style="border: none;" />
                                        </idea:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <PagerStyle Mode="NextPrevNumericAndAdvanced" />
                    </telerik:RadGrid>
                </div>
                <div style="margin-top: 5px; margin-bottom: 25px;">
                    <idea:LinkButton
                    runat="server"
                    ID="lbDeleteSelected"
                    CssClass="button small round blue"
                    OnClick="ApplyClicked">
                        Delete Selected
                    </idea:LinkButton>
                </div>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div><br /><br />
    <div class="clear"></div>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow 
            ID="rwViewCampaign" 
            Title="View Campaign"
            Height="400px"
            Width="950px"
            ReloadOnShow="true"
            ShowContentDuringLoad="false"
            Modal="true"
            runat="server" 
            Skin="Windows7">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

</asp:Content>
