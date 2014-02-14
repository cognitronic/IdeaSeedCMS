<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScheduleView.ascx.cs" Inherits="IdeaSeedCMSAdmin.Website.Views.ScheduleView" %>
<telerik:RadAjaxManagerProxy ID="ramp" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbSave">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divContent" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rgSchedule">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgSchedule" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />
<div id="content">
    <div class="one">
        <div runat="server" id="divContent">
            <h3>Class Details</h3>
            <hr />
            <div>
                <span>Is Active: </span>
                <idea:CheckBox
                runat="server"
                Skin="Metro"
                ID="cbIsActive" />
            </div>
            <div>
                <div>Name:</div>
                <idea:TextBox
                runat="server"
                ID="tbName"
                Skin="Metro"
                Width="600px">
                </idea:TextBox>
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator1"
                Display="Dynamic"
                CssClass="alert"
                ErrorMessage="<br />Enter a name."
                InitialValue=""
                ControlToValidate="tbName" />
            </div>
            <div>
                <div>Description:</div>
                <idea:TextBox
                runat="server"
                ID="tbDescription"
                Skin="Metro"
                Width="600px"
                Height="50px"
                TextMode="MultiLine">
                </idea:TextBox>
            </div>
            <div>
                <div>Instructor:</div>
                <idea:StaffDDL
                runat="server"
                ID="ddlStaff"
                Skin="Metro">
                </idea:StaffDDL>
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator2"
                Display="Dynamic"
                CssClass="alert"
                ErrorMessage="<br />Select an instructor."
                InitialValue=""
                ControlToValidate="ddlStaff" />
            </div>
            <div>
                <div>Class Type:</div>
                <idea:EventTypeDDL
                runat="server"
                ID="ddlEventType"
                Skin="Metro">
                </idea:EventTypeDDL>
                <asp:RequiredFieldValidator
                runat="server"
                ID="RequiredFieldValidator3"
                Display="Dynamic"
                CssClass="alert"
                ErrorMessage="<br />Select class type."
                InitialValue=""
                ControlToValidate="ddlEventType" />
            </div>
            <br />
            <div>
                <idea:LinkButton
                runat="server"
                CssClass="button small round red-cherry"
                ID="lbSave"
                OnClick="SaveClicked">
                    <b>Save</b>
                </idea:LinkButton>&nbsp;&nbsp;&nbsp;
                <idea:LinkButton
                runat="server"
                CausesValidation="false"
                CssClass="button small round red-cherry"
                ID="lbCancel"
                OnClick="CancelClicked">
                    <b>Cancel</b>
                </idea:LinkButton>&nbsp;&nbsp;&nbsp;
            </div><br />
            <div>
                <h3>Class Schedule</h3>
            </div>
            <hr />
            <div>
                <telerik:RadGrid
                runat="server"
                ID="rgSchedule"
                AllowPaging="True"
                AutoGenerateColumns="false"
                AllowSorting="True" 
                GridLines="None" 
                ShowStatusBar="true"
                OnItemCommand="ItemCommand"
                OnNeedDataSource="NeedDataSource"
                ShowFooter="true"
                Skin="Windows7">
                    <ClientSettings EnableRowHoverStyle="true">
                    </ClientSettings>
                    <MasterTableView 
                    DataKeyNames="ID"
                    CommandItemDisplay="Top"
                    EnableNoRecordsTemplate="true"
                    NoMasterRecordsText="Class Not Scheduled.">
                        <Columns>
                            <telerik:GridTemplateColumn 
                            DataField="Name" 
                            HeaderText="Day Of Week" 
                            SortExpression="Name"
                            UniqueName="Name">
                                <ItemTemplate>
                                    <%# Eval("Name")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <idea:DayOfWeekDDL
                                    runat="server"
                                    id="ddlDayOfWeek"
                                    SelectedValue='<%#Eval("Name") %>'>
                                    </idea:DayOfWeekDDL>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="StartTime" 
                            HeaderText="Start Time" 
                            SortExpression="StartTime"
                            UniqueName="StartTime">
                                <ItemTemplate>
                                    <%# DateTime.Parse(Eval("StartTime").ToString()).ToShortTimeString()%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <telerik:RadTimePicker
                                    runat="server"
                                    MinDate="1/1/0001"
                                    DbSelectedDate='<%#Bind("StartTime") %>'
                                    ID="rtpStartTime">
                                    </telerik:RadTimePicker>
                                     <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="RequiredFieldValidator1"
                                    Display="Dynamic"
                                    CssClass="alert"
                                    ErrorMessage="<br />Select a time."
                                    InitialValue=""
                                    ControlToValidate="rtpStartTime" />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn 
                            DataField="EndTime" 
                            HeaderText="End Time" 
                            SortExpression="EndTime"
                            UniqueName="EndTime">
                                <ItemTemplate>
                                    <%# DateTime.Parse(Eval("EndTime").ToString()).ToShortTimeString()%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <telerik:RadTimePicker
                                    runat="server"
                                    MinDate="1/1/0001"
                                    DbSelectedDate='<%#Bind("EndTime") %>'
                                    ID="rtpEndtime">
                                    </telerik:RadTimePicker>
                                     <asp:RequiredFieldValidator
                                    runat="server"
                                    ID="RequiredFieldValidator4"
                                    Display="Dynamic"
                                    CssClass="alert"
                                    ErrorMessage="<br />Select a time."
                                    InitialValue=""
                                    ControlToValidate="rtpEndTime" />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn
                            HeaderStyle-Width="20px">
                                <ItemTemplate>
                                    <idea:LinkButton
                                    runat="server"
                                    ID="lbEdit"
                                    CommandName="Edit"
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
</div>