<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ImportCouponCodes.aspx.cs" Inherits="IdeaSeedCMSAdmin.Website.Modules.CampaignManager.ImportCouponCodes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="maincontainerfull">
        <div class="maincontent">
                <h3>Import Coupon Codes</h3>
                <hr />
            <div style="float: left;">
                <span>Upload a comma separated list (.csv) of coupon codes</span><br />
                <telerik:RadAsyncUpload
                runat="server"
                ID="ruImport"
                AllowedFileExtensions=".txt,.csv"
                InitialFileInputsCount="1"
                InputSize="1"
                ControlObjectsVisibility="None"
                MaxFileInputsCount="1"
                MaxFileSize="1002400">
                </telerik:RadAsyncUpload>
                <div>
                    <asp:Button
                    runat="server"
                    ID="btnImport"
                    CssClass="button small round blue"
                    Text="Import Codes"
                    Height="30px"
                    OnClick="ImportClicked" /><br /><br />
                    <%--<telerik:RadProgressManager  
                    id="Radprogressmanager1" 
                    runat="server" />
                    <telerik:RadProgressArea 
                    id="RadProgressArea1" 
                    Skin="Windows7"
                    runat="server" />--%>
                </div>
                <div style="margin-top: 100px; margin-bottom: 20px;">
                    <idea:LinkButton
                    runat="server"
                    CssClass="button small round blue"
                    ID="lbCancel"
                    OnClick="CancelClicked">
                        <b>Return To Previous Page</b>
                    </idea:LinkButton>&nbsp;&nbsp;&nbsp;
                </div>
            </div>
            <div runat="server" id="divImportLabels" style="float: left; ">
                <div>
                    <span>
                        # Codes Ready For Import:
                    </span>
                    <span>
                        <idea:Label
                        runat="server"
                        ForeColor="Green"
                        ID="lblReadyForImport">
                        </idea:Label>
                    </span>
                </div>
                <div>
                    <span>
                        # Codes Imported:
                    </span>
                    <span>
                        <idea:Label
                        runat="server"
                        ForeColor="#0067B8"
                        ID="lblEmailsImported">
                        </idea:Label>
                    </span>
                </div>
                <div>
                    <span>
                        # Codes Skipped (Invalid or Duplicate):
                    </span>
                    <span>
                        <idea:Label
                        ForeColor="Red"
                        runat="server"
                        ID="lblEmailsSkipped">
                        </idea:Label>
                    </span>
                </div>
            </div>
            <div>
                <br />
                <idea:Label
                runat="server"
                ID="lblMessage">
                </idea:Label>
            </div>
            <div class="clear"></div>
        </div>
    </div>
            <div class="clear"></div>
</asp:Content>
