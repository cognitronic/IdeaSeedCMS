<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SchedulesView.ascx.cs" Inherits="IdeaSeedCMSAdmin.Website.Views.SchedulesView" %>
<telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgSchedules">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgSchedules" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />
<div id="content">
    <div class="one">
        <h3>Schedules</h3>
        <hr />
        <div>
            <telerik:RadGrid
            runat="server"
            ID="rgSchedules"
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
                NoMasterRecordsText="No Schedules Found.">
                    <Columns>
                        <telerik:GridTemplateColumn 
                        DataField="Name" 
                        HeaderText="Class" 
                        SortExpression="Name"
                        UniqueName="Name">
                            <ItemTemplate>
                                <%# Eval("Name")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn 
                        DataField="EventTypeRef.Name" 
                        HeaderText="Class Type" 
                        SortExpression="EventTypeRef.Name"
                        UniqueName="EventTypeRef.Name">
                            <ItemTemplate>
                                <%# Eval("EventTypeRef.Name")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn 
                        DataField="StaffRef.LastName" 
                        HeaderText="Instructor" 
                        SortExpression="StaffRef.LastName"
                        UniqueName="StaffRef.LastName">
                            <ItemTemplate>
                                <%# Eval("StaffRef.FirstName").ToString() + " " + Eval("StaffRef.LastName").ToString()%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn 
                        DataField="IsActive" 
                        HeaderText="IsActive" 
                        SortExpression="IsActive"
                        UniqueName="IsActive">
                            <ItemTemplate>
                                <%# (bool)Eval("IsActive") == true ? "Active" : "In Active" %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn
                        HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <idea:LinkButton
                                runat="server"
                                ID="lbEdit"
                                OnClick="EditEventClicked"
                                eventid='<%# Eval("ID").ToString() %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgEdit"
                                    ToolTip="View Event"
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
                                linkid='<%# Eval("ID").ToString() %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgDelete"
                                    ToolTip="Delete Event"
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

