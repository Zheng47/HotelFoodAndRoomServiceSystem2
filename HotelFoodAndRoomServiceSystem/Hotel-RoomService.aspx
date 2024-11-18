<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hotel-RoomService.aspx.cs" Inherits="HotelFoodAndRoomServiceSystem.Hotel_RoomService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel - Room Service</title>
    <link rel="stylesheet" type="text/css" href="CssFiles/RoomService.css" />
</head>
<body>
    <form id="form1" runat="server">

        <header id="roomServiceHeader">
            <asp:Button ID="dashBoardBtn" Cssclass="textFont" runat="server" Text="<<Return to Stay Information" Onclick="dashBoardBtn_Click" Visible="true"/>
            <asp:Button ID="roomServiceBtn" Cssclass="textFont" runat="server" Text="<<Return to Room Services" Onclick="roomServiceBtn_Click" Visible="false"/>
            <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/nobg.png"  id="hotelLogo"/>
            <asp:Label ID="hotelName" runat="server" CssClass="textFont" Text="H+ HOTEL" />
            <asp:Button ID="shoppingCartBtn" runat="server" />
        </header> 

        <asp:Panel ID="roomServiceSelection" runat="server" CssClass="mainContainer" Visible="true">
            <%-- FOR LAUNDRY AND DRY CLEANING SERVICE --%>
            <div class="roomServiceContainer">
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/ROOM%20SERVICES/DRY%20CLEANING.jpg" class="roomServiceImgLayout" />
                <div class="roomServiceInfoContainer textFont textColor">
                    <asp:Label ID="laundryDryCleaningLbl" CssClass="roomServiceTitle" runat="server" Text="Laundry and Dry Cleaning Services" />
                    <div class="descriptionAndBtnLayout">
                        <asp:Label ID="laundryDryCleaningDescription" CssClass="roomServiceDescription" runat="server" Text="Request laundry and room cleaning services for a spotless stay." />
                        <asp:Button ID="laundryDryCleaningServiceBtn" CssClass="roomServiceBtn" runat="server" OnClick="laundryDryCleaningServiceBtn_Click" />
                    </div>
                </div>
            </div>

            <%-- FOR SPA SERVICE --%>
            <div class="roomServiceContainer">
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/ROOM%20SERVICES/pexels-isabella-mendes-107313-12151232.jpg" class="roomServiceImgLayout" />
                <div class="roomServiceInfoContainer textFont textColor">
                    <asp:Label ID="spaServiceLbl" CssClass="roomServiceTitle" runat="server" Text="Spa Service" />
                    <div class="descriptionAndBtnLayout">
                        <asp:Label ID="spaServiceDesciption" CssClass="roomServiceDescription" runat="server" Text="Indulge in our relaxing spa treatments for a rejuvenating experience" />
                        <asp:Button ID="spaServiceBtn" CssClass="roomServiceBtn" runat="server" OnClick="spaServiceBtn_Click" />
                    </div>
                </div>
            </div>

            <%-- FOR HOUSEKEEPING SERVICE --%>
            <div class="roomServiceContainer">
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/ROOM%20SERVICES/pexels-liliana-drew-9462759.jpg" class="roomServiceImgLayout" />
                <div class="roomServiceInfoContainer textFont textColor">
                    <asp:Label ID="houseKeepinLbl" CssClass="roomServiceTitle" runat="server" Text="Housekeeping Services" />
                    <div class="descriptionAndBtnLayout">
                        <asp:Label ID="houseKeepingDescription" CssClass="roomServiceDescription" runat="server" Text="Request room cleaning and fresh linens for a comfortable stay" />
                        <asp:Button ID="houseeKeepingServiceBtn" CssClass="roomServiceBtn" runat="server" OnClick="houseeKeepingServiceBtn_Click" />
                    </div>
                </div>
            </div>
        </asp:Panel>

        <%-- LAUNDRY AND DRY CLEANING CONTENT --%>
        <asp:Panel id="laundryAndDryCleaningServicesPanel" runat="server" CssClass="mainContainer" Visible="false">
            <div class="laundryContent textFont textColor">
                <asp:Label ID="dryCleaningLbl" CssClass="laundryContentTitle" runat="server" Text="DRY CLEANING" />
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/ROOM%20SERVICES/DRY%20CLEANING.jpg" class="laundryContentImgLayout"/>
                <asp:Label ID="dryCleaningDescription" CssClass="laundryContentDescription" runat="server" Text="We provide expert dry cleaning services for your clothing at incredibly low costs." />
                <asp:Button ID="dryCleaningBtn" CssClass="laundryContentBtn" runat="server" Text="Inquire" OnClick="dryCleaningBtn_Click" />
            </div>
            <div class="laundryContent textFont textColor">
                <asp:Label ID="washLbl" CssClass="laundryContentTitle" runat="server" Text="WASH" />
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/ROOM%20SERVICES/WASH.jpg" class="laundryContentImgLayout" />
                <asp:Label ID="washDescripton" CssClass="laundryContentDescription" runat="server" Text="You'll love our services because we'll wash your clothes and deliver them right to your door." />
                <asp:Button ID="washBtn" CssClass="laundryContentBtn" runat="server" Text="Inquire" OnClick="washBtn_Click" />
            </div>
            <div class="laundryContent textFont textColor">
                <asp:Label ID="steamIronLbl" CssClass="laundryContentTitle" runat="server" Text="STEAM IRON" />
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/ROOM%20SERVICES/STEAM%20IRON.jpg" class="laundryContentImgLayout" />
                <asp:Label ID="steamIronDescription" CssClass="laundryContentDescription" runat="server" Text="You'll love our services because we'll wash your clothes and deliver them right to your door." />
                <asp:Button ID="steamIronBtn" CssClass="laundryContentBtn" runat="server" Text="Inquire" OnClick="steamIronBtn_Click" />
            </div>
        </asp:Panel>

        <%-- SPA SERVICE CONTENT --%>
        <asp:Panel ID="spaServicePanel" runat="server" CssClass="mainContainer" Visible="false">
            <div class="spaServiceContent textFont textColor">
                <asp:Label ID="spaPedicureLbl" CssClass="spaServiceContentTitle" runat="server" Text="SPA PEDICURE" />
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/ROOM%20SERVICES/SPA%20PEDICURE.jpg" class="spaServiceContentImgLayout" />
                <asp:Label ID="spaPedicureDescription" CssClass="spaServiceContentDescription" runat="server" Text="We provide expert dry cleaning services for your clothing at incredibly low costs." />
                <asp:Button ID="spaPedicureBtn" CssClass="spaServiceContentBtn" runat="server" Text="Inquire" OnClick="spaPedicureBtn_Click" />
            </div>
            <div class="spaServiceContent textFont textColor">
                <asp:Label ID="spaManicureLbl" CssClass="spaServiceContentTitle" runat="server" Text="SPA MANICURE" />
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/ROOM%20SERVICES/SPA%20MANICURE.jpg" class="spaServiceContentImgLayout" />
                <asp:Label ID="spaManicureDescription" CssClass="spaServiceContentDescription" runat="server" Text="You'll love our services because we'll wash your clothes and deliver them right to your door." />
                <asp:Button ID="spaManicureBtn" CssClass="spaServiceContentBtn" runat="server" Text="Inquire" OnClick="spaManicureBtn_Click" />
            </div>
            <div class="spaServiceContent textFont textColor">
                <asp:Label ID="deepCleansingLbl" CssClass="spaServiceContentTitle" runat="server" Text="DEEP CLEANSING FACIAL SPA" />
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/ROOM%20SERVICES/DEEP%20CLEANSING.jpg" class="spaServiceContentImgLayout" />
                <asp:Label ID="deepCleansingDescription" CssClass="spaServiceContentDescription" runat="server" Text="You'll love our services because we'll wash your clothes and deliver them right to your door." />
                <asp:Button ID="deepCleansingBtn" CssClass="spaServiceContentBtn" runat="server" Text="Inquire" OnClick="deepCleansingBtn_Click" />
            </div>
        </asp:Panel>

        <%-- HOUSEKEEPING SERVICE CONTENT --%>
        <asp:Panel ID="housekeepingPanel" runat="server" CssClass="mainContainer" Visible="false">
            <div class="housekeepingContent textFont textColor">
                <asp:Label ID="amenitiesLbl" CssClass="housekeepingContentTitle" runat="server" Text="EXTRA AMENITIES DELIVERY" />
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/ROOM%20SERVICES/pexels-olly-3770106.jpg" class="housekeepingContentImgLayout" />
                <asp:Label ID="amenitiesDescrition" CssClass="housekeepingContentDescription" runat="server" Text="Delivering additional items such as toiletries, pillows, blankets, or bathrobes to the guest's room." />
                <asp:Button ID="amenitiesBtn" CssClass="housekeepingContentBtn" runat="server" Text="Inquire" />
            </div>
            <div class="housekeepingContent textFont textColor">
                <asp:Label ID="roomCleaningLbl" CssClass="housekeepingContentTitle" runat="server" Text="ROOM CLEANING" />
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/ROOM%20SERVICES/pexels-cottonbro-6466479.jpg" class="housekeepingContentImgLayout" />
                <asp:Label ID="roomCleaningDescription" CssClass="housekeepingContentDescription" runat="server" Text="Regular cleaning of the room, including making the bed, vacuuming, dusting, and cleaning the bathroom" />
                <asp:Button ID="roomCleaningBtn" CssClass="housekeepingContentBtn" runat="server" Text="Inquire" />
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
                    <asp:Label ID="roomServiceTypeLbl" CssClass="formContentText" runat="server" Text="Room Service Type*" />
                    <asp:TextBox ID="roomServiceTypeTxtBox" CssClass="formContentTxtBox" ReadOnly="true" runat="server" Placeholder="Enter Room Service Type" />                    
                </div>
                <div class="inquireFormContent2">
                    <asp:Label ID="guestNameLbl" CssClass="formContentText" runat="server" Text="Guest Name*" />
                    <asp:TextBox ID="guestNameTxtBox" CssClass="formContentTxtBox" runat="server" ReadOnly="true" />
                    <asp:Label ID="amountLbl" CssClass="formContentText" runat="server" Text="How many KG*" />
                    <asp:TextBox ID="amountTxtBox" CssClass="formContentTxtBox" runat="server" TextMode="Number" Placeholder="₱50 per 1kg (Minimum 1kg)" />   
                </div>
            </div>
            <asp:Label ID="serviceDescriptionLbl" runat="server" Text="Room Service Description*" />
            <asp:TextBox ID="serviceDescriptionTxtBox" runat="server" TextMode="MultiLine"  Placeholder="Enter Room Service Description" />
            <div id="requestBtnLayout">
                <asp:Label ID="servicePriceCurrencyLbl" runat="server" Text="Service Price: ₱" />
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
