<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="CampaignManagerSettings.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Modules.CampaignManager.CampaignManagerSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
<telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgSettings">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgSettings" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />
    <h3>Campaign Manager Settings</h3>
    <hr />
    <div class="maincontainerfull">
        <div class="maincontent" id="divMain" runat="server">
            <div>
                <telerik:RadGrid 
                ID="rgSettings" 
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
                    CommandItemDisplay="None"
                    EnableNoRecordsTemplate="true"
                    NoMasterRecordsText="No settings were found."
                    AllowMultiColumnSorting="true">
                        <Columns>
                            <telerik:GridTemplateColumn 
                            DataField="Setting" 
                            HeaderText="Setting" 
                            SortExpression="Setting"
                            UniqueName="Setting">
                                <ItemTemplate>
                                    <%# Eval("Setting")%>
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
                            DataField="Value" 
                            HeaderText="Value" 
                            SortExpression="Value"
                            UniqueName="Value">
                                <ItemTemplate>
                                    <%# Eval("Value")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <idea:TextBox
                                    runat="server"
                                    ID="tbValue"
                                    itemid='<%# Eval("ID") %>'
                                    TextMode="MultiLine"
                                    Height="60px"
                                    Width="400px"
                                    Text='<%# Eval("Value") %>' />
                                </EditItemTemplate>
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
                                        ID="imgView"
                                        ToolTip="Edit Setting"
                                        ImageUrl="~/images/edit.gif"
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
