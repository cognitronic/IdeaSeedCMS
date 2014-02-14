<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrimaryNavView.ascx.cs" Inherits="IdeaSeed.Website.Views.PrimaryNavView" %>
 <div style="float: right;">
    <telerik:RadSocialShare 
    ID="rsShare" 
    runat="server">
        <MainButtons>
            <telerik:RadFacebookButton ReferralsLabel="fbShare" ButtonType="FacebookShare" ButtonLayout="ButtonCount" />
            <telerik:RadFacebookButton ReferralsLabel="fbRecommend" ButtonType="FacebookRecommend" ButtonLayout="ButtonCount" />
            <telerik:RadTwitterButton CounterMode="Horizontal" />
            <telerik:RadGoogleButton AnnotationType="Bubble" ButtonSize="Medium" />
        </MainButtons>
    </telerik:RadSocialShare>
    <span >
        <idea:LinkButton
        runat="server"
        CssClass="button small round red-cherry"
        ID="lbNewsletter"
        ForeColor="#ffffff"
        OnClick="NewsletterClicked">
            <b>Get Coupons & Discounts!</b>
        </idea:LinkButton>
    </span>
<div class="clear" />
</div>
<div runat="server" id="navContainer"/>