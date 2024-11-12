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
            <asp:Button ID="dashBoardBtn" Cssclass="textFont" runat="server" Text="<<Return to Dashboard" Onclick="dashBoardBtn_Click"/>
            <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/nobg.png"  id="hotelLogo"/>
            <asp:Label ID="hotelName" runat="server" CssClass="textFont" Text="H+ HOTEL" />
            <asp:Button ID="shoppingCartBtn" runat="server" />
        </header> 

        <div id="mainContainer">
            <div id="subContainer1">
                <div id="laundryDryServices" class="textFont">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Icons/Room%20Services%20Icon/laundry-service.png" id="subContainer1Logo1" />
                    <asp:Label ID="subContainer1Lbl1" runat="server" Text="Laundry and Dry Cleaning Services" />
                    <asp:Label ID="subContainer1Description1" runat="server" Text="Request laundry and dry cleaning services for a spotless stay." />
                    <asp:Button ID="laundryAndDryServicesBtn" runat="server" class="servicesBtn"/>
                </div>
                <div id="spaServices" class="textFont">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Icons/Room%20Services%20Icon/hair-treatment.png" id="subContainer1Logo2"/>
                    <asp:Label ID="subContainer1Lbl2" runat="server" Text="Spa Services" />
                    <asp:Label ID="subContainer1Description2" runat="server" Text="Indulge in our relaxing spa treatments for a rejuvenating experience." />
                    <asp:Button ID="spaServicesBtn" runat="server" class="servicesBtn"/>
                </div>
            </div>
            <div id="subContainer2">
                <div id="houseKeepingServices"  class="textFont">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Icons/Room%20Services%20Icon/cleaning.png" id="subContainer2Logo1"/>
                    <asp:Label ID="subContainer2Lbl1" runat="server" Text="Housekeeping Services" />
                    <asp:Label ID="subContainer2Description1" runat="server" Text="Request a room cleaning and a fresh linen for a comfortable stay." />
                    <asp:Button ID="houseKeepingServicesBtn" runat="server" class="servicesBtn"/>
                </div>
                <div id="massageServices" class="textFont">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Icons/Room%20Services%20Icon/massage.png" id="subContainer2Logo2"/>
                    <asp:Label ID="subContainer2Lbl2" runat="server" Text="Massage Services" />
                    <asp:Label ID="subContainer2Description2" runat="server" Text="Book a relaxing massage to unwind and rejuvenate." />
                    <asp:Button ID="massageServicesBtn" runat="server" class="servicesBtn"/>
                </div>
            </div>
        </div>
        <footer id="footer" class="textFont">
            <asp:Label ID="hotelNameFooter" runat="server" Text="H+ HOTEL" />
        </footer>
    </form>
</body>
</html>
