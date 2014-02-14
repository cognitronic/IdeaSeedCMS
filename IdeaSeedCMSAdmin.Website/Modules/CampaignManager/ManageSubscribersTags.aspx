<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ManageSubscribersTags.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Modules.CampaignManager.ManageSubscribersTags" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div>
        <h3>
            <idea:Label
            runat="server"
            ID="lblSubscribers">
            </idea:Label>
        </h3>
        <hr />
    </div>
    <div class="smallResultMessage">
        <idea:Label
        runat="server"
        ID="lblMessage">
        </idea:Label>
    </div>
    <div>
        <telerik:RadGrid 
        ID="rgTags" 
        runat="server" 
        AllowPaging="True"
        AutoGenerateColumns="false"
        AllowSorting="True"
        GridLines="None" 
        ShowStatusBar="true"
        OnNeedDataSource="NeedDataSource"
        PageSize="20"
        ShowFooter="true"
        Skin="Metro">
            <MasterTableView 
            EnableNoRecordsTemplate="true"
            NoMasterRecordsText="All subscribers have this tag."
            ItemStyle-VerticalAlign="Top"
            AlternatingItemStyle-VerticalAlign="Top"
            DataKeyNames="ID">
                <Columns>
                    <telerik:GridTemplateColumn 
                    HeaderStyle-Width="25px"
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
                            campaignTagID='<%# Eval("ID")%>'
                            runat="server">
                            </idea:CheckBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn
                    HeaderText="Tag"
                    SortExpression="Tag"
                    DataField="Tag">
                        <ItemTemplate>
                            <%# Eval("Tag") %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <PagerStyle Mode="NextPrevNumericAndAdvanced" Position="Bottom"/>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
    <div>
        <br />
        <span>
            <asp:Button
            runat="server"
            ID="btnSave"
            OnClick="ApplyClicked"
            Text="Apply" />
        </span>
    </div>

</asp:Content>
