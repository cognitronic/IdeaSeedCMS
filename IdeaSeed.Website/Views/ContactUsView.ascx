<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactUsView.ascx.cs" Inherits="IdeaSeed.Website.Views.ContactUsView" %>
<telerik:RadAjaxManagerProxy ID="rampEmployeeList" runat="server" >
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbSubmit">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="divContent" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" />
<div class="one">
	<iframe width="960" height="350" src="http://maps.google.com/maps?hl=en&amp;g=3500+Coffee+Rd+%23+19,+Modesto,+CA+95355-1315&amp;q=Modesto+Power,+3500+Coffee+Rd+%23+19,+Modesto,+CA+95355-1315&amp;ie=UTF8&amp;hq=Modesto+Power,+3500&amp;hnear=Coffee+Rd,+Modesto,+California&amp;t=h&amp;vpsrc=0&amp;cid=3236670583200058338&amp;z=19&amp;iwloc=A&amp;output=embed">
	</iframe>
</div>
<!-- COLUMNS CONTAINER ENDS-->
<div class="one">
	<div class="horizontal-line">
	</div>
	<div class="one-fourth">
	<div>
		<strong>Contact Info</strong>
        <hr />
	</div>
	<p style="margin-bottom:0;">
			T: 209-526-1314 <br/> F: 209-526-7235 <br/> E: <a href="mailto:info@teammodestopower.com">info@teammodestopower.com</a>
	</p>
</div>
					
	<div class="inner-content last" runat="server" id="divContent">
        <h3>
            Sign up for coupons, discounts, and upcoming event notifications!
        </h3>
        <div>
            <div>Name:</div>
            <idea:TextBox
            runat="server"
            Width="450px"
            ID="tbName" />
            <asp:RequiredFieldValidator
            runat="server"
            ID="rfvName"
            CssClass="error"
            Display="Dynamic"
            ControlToValidate="tbName"
            ErrorMessage="<br />Please enter your name" />
        </div>
        <div>
            <div>Email:</div>
            <idea:TextBox
            runat="server"
            Width="450px"
            ID="tbEmail" />
            <asp:RequiredFieldValidator
            runat="server"
            ID="RequiredFieldValidator1"
            CssClass="error"
            Display="Dynamic"
            ControlToValidate="tbEmail"
            ErrorMessage="<br />Please enter an email address." />
            <asp:RegularExpressionValidator 
            ID="valEmailAddress"
            ControlToValidate="tbEmail"
            CssClass="error"
            ValidationExpression="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" 
            ErrorMessage="<br />Email address is invalid." 
            Display="Dynamic" 
            EnableClientScript="true"
            Runat="server"/>
        </div>
        <div>
            <div>Phone:</div>
            <idea:TextBox
            Width="450px"
            runat="server"
            ID="tbPhone" />
        </div>
        <div>
            <div>Message:</div>
            <idea:TextBox
            runat="server"
            Width="450px"
            TextMode="MultiLine"
            Height="75px"
            ID="tbMessage" />
            <asp:RequiredFieldValidator
            runat="server"
            ID="RequiredFieldValidator2"
            CssClass="error"
            Display="Dynamic"
            ControlToValidate="tbMessage"
            ErrorMessage="<br />Please enter a message." />
        </div>
        <div>
            <h5>What are you interested in?</h5>
            <asp:DataList ID="dlTags" 
            runat="server" 
            RepeatColumns="4">
                <ItemTemplate>
                    <div 
                    style="float: left; 
                    padding-right: 5px; 
                    margin-right: 20px;
                    padding-top: 5px; 
                    padding-bottom: 5px;">
                        <idea:CheckBox
                        runat="server"
                        AutoPostBack="true"
                        TextAlign="Left"
                        ID="cbTag"
                        tagid='<%# Eval("ID") %>'
                        Text='<%# Eval("Tag") %>' />
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div style="margin-top: 5px;">
            <idea:LinkButton
            runat="server"
            OnClick="SendClicked"
            CssClass="button big round deep-red"
            ID="lbSubmit">
                Send Message
            </idea:LinkButton>
        </div><br /><br />
        <div>
            <idea:Label
            runat="server"
            ID="lblMessage" />
        </div>
        <br />	
	</div>
</div>