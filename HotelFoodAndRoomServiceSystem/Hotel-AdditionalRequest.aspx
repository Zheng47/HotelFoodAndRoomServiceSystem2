<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hotel-AdditionalRequest.aspx.cs" Inherits="HotelFoodAndRoomServiceSystem.Hotel_RoomService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel - Additional Request</title>
    <link rel="stylesheet" type="text/css" href="CssFiles/AdditionalService.css" />
</head>
<body>
    <form id="form1" runat="server">

        <header id="roomServiceHeader">
            <asp:Button ID="dashBoardBtn" Cssclass="textFont" runat="server" Text="<<Return to Stay Information" Onclick="dashBoardBtn_Click" Visible="true"/>
            <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/nobg.png"  id="hotelLogo"/>
            <asp:Label ID="hotelName" runat="server" CssClass="textFont" Text="H+ HOTEL" />
        </header> 

        <%-- FOR ADDITIONAL REQUEST --%>
        <asp:Panel id="additionalServicesPanel" runat="server" CssClass="mainContainer" Visible="true">
            <div class="additionalContent textFont textColor">
                <asp:Label ID="pillowLbl" CssClass="additionalContentTitle" runat="server" Text="PILLOW" />
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/ROOM%20SERVICES/Additional%20Pillow.jpg" class="additionalContentImgLayout" />
                <asp:Label ID="dryCleaningDescription" CssClass="additionalContentDescription" runat="server" Text="Additional pillow for your better stay. Charge fee will be settled before you check out." />
                <asp:Button ID="additionalPillowBtn" CssClass="additionalContentBtn" runat="server" Text="Request" OnClick="additionalPillowBtn_Click" />
            </div>
            <div class="additionalContent textFont textColor">
                <asp:Label ID="bathTowelLbl" CssClass="additionalContentTitle" runat="server" Text="BATH TOWEL" />
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/ROOM%20SERVICES/Additional%20BathTowel.jpg" class="additionalContentImgLayout" />
                <asp:Label ID="washDescripton" CssClass="additionalContentDescription" runat="server" Text="Additional bath towel for your better stay. Charge fee will be settled before you check out." />
                <asp:Button ID="additionalBathTowelBtn" CssClass="additionalContentBtn" runat="server" Text="Request" OnClick="additionalBathTowelBtn_Click" />
            </div>
            <div class="additionalContent textFont textColor">
                <asp:Label ID="comforterLbl" CssClass="additionalContentTitle" runat="server" Text="COMFORTER" />
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/ROOM%20SERVICES/Additional%20Comforter.jpg" class="additionalContentImgLayout" />
                <asp:Label ID="steamIronDescription" CssClass="additionalContentDescription" runat="server" Text="Additional comforter for your better stay. Charge fee will be settled before you check out." />
                <asp:Button ID="additionalComforterBtn" CssClass="additionalContentBtn" runat="server" Text="Request" OnClick="additionalComforterBtn_Click" />
            </div>
        </asp:Panel>

        <%-- IF INQUIRE BUTTON IS CLICKED --%>
        <asp:Panel ID="overlay" CssClass="overlay" runat="server" Visible="false" />

        <asp:Panel ID="inquireForm" CssClass="inquireForm textFont" runat="server" Visible="false">
            <div id="inquireFormHeader">
                <asp:Label ID="roomServiceFormLbl" runat="server" Text="Room Service Fill Up Form" />
                <asp:Button ID="closeFormBtn" runat="server" Text="X" OnClick="closeFormBtn_Click" />
            </div>
            <div id="inquireFormContent">
                <div class="inquireFormContent2">
                    <asp:Label ID="roomNumberLbl" CssClass="formContentText" runat="server" Text="Room Number*" />
                    <asp:TextBox ID="roomNumberTxtBox" CssClass="formContentTxtBox" runat="server" ReadOnly="true" TextMode="Number" Placeholder="Enter Room Number" />
                    <asp:Label ID="roomServiceTypeLbl" CssClass="formContentText" runat="server" Text="Additional Item Request*" />
                    <asp:TextBox ID="roomServiceTypeTxtBox" CssClass="formContentTxtBox" ReadOnly="true" runat="server" />                    
                </div>
                <div class="inquireFormContent2">
                    <asp:Label ID="guestNameLbl" CssClass="formContentText" runat="server" Text="Guest Name*" />
                    <asp:TextBox ID="guestNameTxtBox" CssClass="formContentTxtBox" runat="server" ReadOnly="true" />
                    <asp:Label ID="amountLbl" CssClass="formContentText" runat="server" Text="Quantity" />
                    <asp:TextBox ID="amountTxtBox" CssClass="formContentTxtBox" runat="server" TextMode="Number" Placeholder="Enter Amount of Item" />   
                </div>
            </div>
            <asp:Label ID="serviceDescriptionLbl" runat="server" Text="Item Request Description*" />
            <asp:TextBox ID="serviceDescriptionTxtBox" runat="server" TextMode="MultiLine"  Placeholder="Enter your Item Request Description (Not Required)" />
            <div id="requestBtnLayout">
                <asp:Label ID="servicePriceCurrencyLbl" runat="server" Text="Item Price: ₱" />
                <asp:Label ID="roomServicePrice" runat="server" Text="0" />
               <asp:Button ID="requestBtn" runat="server" Text="REQUEST" OnClick="requestBtn_Click" />
            </div>
        </asp:Panel>

        <footer id="footer" class="textFont">
            <asp:Label ID="hotelNameFooter" runat="server" Text="H+ HOTEL" />
        </footer>
    </form>
</body>
</html>
