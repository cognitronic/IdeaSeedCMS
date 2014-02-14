<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StaffProfileView.ascx.cs" Inherits="IdeaSeed.Website.Views.StaffProfileView" %>
    <div class="one">
	    <div class="inner-content">
            <h5>
                <idea:Label
                runat="server"
                ID="lblTitle" />
            </h5>
            <div
            runat="server"
            ID="divContent" />
        </div>
        <div class="one-fourth last">
			<p><strong class="colored">Links</strong></p>
            <div
            runat="server"
            ID="divLinks" />
        </div>
    </div>