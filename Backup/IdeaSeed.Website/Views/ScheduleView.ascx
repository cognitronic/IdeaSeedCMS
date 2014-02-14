<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScheduleView.ascx.cs" Inherits="IdeaSeed.Website.Views.ScheduleView" %>
<telerik:RadAjaxManagerProxy ID="rampSchedule" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divContent" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />
    <div class="one" style="margin-top: 30px;">
        <div>
            You can use the filters below to view the schedule by instructor or class.  Check back often as we're constantly improving our schedule and adding classes!
        </div><br />
        <span>Class: </span>
        <span>
            <idea:EventTypeDDL
            runat="server"
            ID="ddlEventType"
            >
            </idea:EventTypeDDL>
        </span>&nbsp;&nbsp;&nbsp;&nbsp;
        <span>Instructor: </span>
        <span>
            <idea:StaffDDL
            runat="server"
            ID="ddlStaff"
            >
            </idea:StaffDDL>
        </span>&nbsp;&nbsp;
        <idea:LinkButton
        runat="server"
        CssClass="button small round red-cherry"
        ID="lbSearch"
        OnClick="SearchClicked">
            <b>Search</b>
        </idea:LinkButton>
    </div>
<div runat="server" id="divContent">
    <div class="one">
	    <div class="horizontal-line">
	    </div>
	    <div class="one-third">
	        <h3 style="color: #346699;">Monday</h3>
            <telerik:RadListView
            runat="server"
            ID="dlMonday"
            OnNeedDataSource="NeedDataSource"
            Width="100%"
            RepeatColumns="0">
                <EmptyDataTemplate>
                    <span style="color: #ff0000;">
                        No Classes Found
                    </span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div>
                        <span style="font-weight: bold; color: #000;"><%# Eval("ScheduledEventRef.Name")%>: </span>
                        <span>
                            <b><%# DateTime.Parse(Eval("StartTime").ToString()).ToShortTimeString() %>  - <%# DateTime.Parse(Eval("EndTime").ToString()).ToShortTimeString()%></b>
                        </span>
                        <br />
                        (<%# Eval("ScheduledEventRef.StaffRef.FirstName")%> <%# Eval("ScheduledEventRef.StaffRef.LastName")%>)
                    </div>
                </ItemTemplate>
            </telerik:RadListView>
        </div>
        <div class="one-third">
	        <h3 style="color: #346699;">Tuesday</h3>
            <telerik:RadListView
            runat="server"
            ID="dlTuesday"
            OnNeedDataSource="NeedDataSource"
            Width="100%"
            RepeatColumns="0">
                <EmptyDataTemplate>
                    <span style="color: #ff0000;">
                        No Classes Found
                    </span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div>
                        <span style="font-weight: bold; color: #000;"><%# Eval("ScheduledEventRef.Name")%>: </span>
                        <span>
                            <b><%# DateTime.Parse(Eval("StartTime").ToString()).ToShortTimeString() %>  - <%# DateTime.Parse(Eval("EndTime").ToString()).ToShortTimeString()%></b>
                        </span>
                        <br />
                        (<%# Eval("ScheduledEventRef.StaffRef.FirstName")%> <%# Eval("ScheduledEventRef.StaffRef.LastName")%>)
                    </div>
                </ItemTemplate>
            </telerik:RadListView>
        </div>
        <div class="one-third last">
	        <h3 style="color: #346699;">Wednesday</h3>
            <telerik:RadListView
            runat="server"
            ID="dlWednesday"
            OnNeedDataSource="NeedDataSource"
            Width="100%"
            RepeatColumns="0">
                <EmptyDataTemplate>
                    <span style="color: #ff0000;">
                        No Classes Found
                    </span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div>
                        <span style="font-weight: bold; color: #000;"><%# Eval("ScheduledEventRef.Name")%>: </span>
                        <span>
                            <b><%# DateTime.Parse(Eval("StartTime").ToString()).ToShortTimeString() %>  - <%# DateTime.Parse(Eval("EndTime").ToString()).ToShortTimeString()%></b>
                        </span>
                        <br />
                        (<%# Eval("ScheduledEventRef.StaffRef.FirstName")%> <%# Eval("ScheduledEventRef.StaffRef.LastName")%>)
                    </div>
                </ItemTemplate>
            </telerik:RadListView>
        </div>
    </div>
    <div class="one">
    <br /><br />
	    <div class="one-third">
	        <h3 style="color: #346699;">Thursday</h3>
            <telerik:RadListView
            runat="server"
            ID="dlThursday"
            OnNeedDataSource="NeedDataSource"
            Width="100%"
            RepeatColumns="0">
                <EmptyDataTemplate>
                    <span style="color: #ff0000;">
                        No Classes Found
                    </span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div>
                        <span style="font-weight: bold; color: #000;"><%# Eval("ScheduledEventRef.Name")%>: </span>
                        <span>
                            <b><%# DateTime.Parse(Eval("StartTime").ToString()).ToShortTimeString() %>  - <%# DateTime.Parse(Eval("EndTime").ToString()).ToShortTimeString()%></b>
                        </span>
                        <br />
                        (<%# Eval("ScheduledEventRef.StaffRef.FirstName")%> <%# Eval("ScheduledEventRef.StaffRef.LastName")%>)
                    </div>
                </ItemTemplate>
            </telerik:RadListView>
        </div>
        <div class="one-third">
	        <h3 style="color: #346699;">Friday</h3>
            <telerik:RadListView
            runat="server"
            ID="dlFriday"
            OnNeedDataSource="NeedDataSource"
            Width="100%"
            RepeatColumns="0">
                <EmptyDataTemplate>
                    <span style="color: #ff0000;">
                        No Classes Found
                    </span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div>
                        <span style="font-weight: bold; color: #000;"><%# Eval("ScheduledEventRef.Name")%>: </span>
                        <span>
                            <b><%# DateTime.Parse(Eval("StartTime").ToString()).ToShortTimeString() %>  - <%# DateTime.Parse(Eval("EndTime").ToString()).ToShortTimeString()%></b>
                        </span>
                        <br />
                        (<%# Eval("ScheduledEventRef.StaffRef.FirstName")%> <%# Eval("ScheduledEventRef.StaffRef.LastName")%>)
                    </div>
                </ItemTemplate>
            </telerik:RadListView>
        </div>
        <div class="one-third last">
	        <h3 style="color: #346699;">Saturday</h3>
            <telerik:RadListView
            runat="server"
            ID="dlSaturday"
            OnNeedDataSource="NeedDataSource"
            Width="100%"
            RepeatColumns="0">
                <EmptyDataTemplate>
                    <span style="color: #ff0000;">
                        No Classes Found
                    </span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div>
                        <span style="font-weight: bold; color: #000;"><%# Eval("ScheduledEventRef.Name")%>: </span>
                        <span>
                            <b><%# DateTime.Parse(Eval("StartTime").ToString()).ToShortTimeString() %>  - <%# DateTime.Parse(Eval("EndTime").ToString()).ToShortTimeString()%></b>
                        </span>
                        <br />
                        (<%# Eval("ScheduledEventRef.StaffRef.FirstName")%> <%# Eval("ScheduledEventRef.StaffRef.LastName")%>)
                    </div>
                </ItemTemplate>
            </telerik:RadListView>
        </div>
    </div>

</div>