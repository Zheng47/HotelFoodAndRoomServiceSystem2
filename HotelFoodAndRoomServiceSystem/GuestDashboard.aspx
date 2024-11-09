<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuestDashboard.aspx.cs" Inherits="HotelFoodAndRoomServiceSystem.HotelServices" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel - Guest Dashboard</title>
    <meta charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="CssFiles/GuestDashboard.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="header"> 
            <img id="hotelLogo" src="CssFiles/Gallery/Food And Room Services Elements/Images/nobg.png" />
            <asp:Label ID="logoLbl" runat="server">H+ HOTEL</asp:Label>
            <asp:Label ID="userLbl" runat="server">Welcome, GUEST</asp:Label>
        </div> 
        <div class="contentContainer">
            <div id="guestDetailsContainer">
                <div id ="guestDetailsSubContainer1">
                     <asp:Label ID="stayInfoLbl" runat="server">STAY INFORMATION</asp:Label> <br />
                     <asp:BulletedList CssClass="stayInfoList" runat="server">
                         <asp:ListItem id="roomNumLbl">Room Number: </asp:ListItem>
                         <asp:ListItem id="chkInDateLbl">Check-in Date: </asp:ListItem>
                         <asp:ListItem id="chkOutDateLbl">Check-out Date: </asp:ListItem>
                     </asp:BulletedList>
                </div>
                <div id ="guestDetailsSubContainer2">
                     <asp:Label ID="roomInfoLbl" runat="server">ROOM INFORMATION</asp:Label> <br />
                     <asp:BulletedList CssClass="stayInfoList" runat="server">
                         <asp:ListItem id="roomTypeLbl">Room Type: </asp:ListItem>
                         <asp:ListItem id="occupancyLbl">Occupancy: </asp:ListItem>
                         <asp:ListItem id="amenitiesLbl">Amenities: </asp:ListItem>
                     </asp:BulletedList>
                </div>
            </div>
            <div id="servicesBtnContainer">
                <asp:Button id="foodAndBeveragesBtn" runat="server" Text="Food & Beverages" />
                <asp:Button id="mainteReqBtn" runat="server" Text="Maintenance Request"/>
            </div>
            <asp:Button id="logoutBtn" runat="server" Text="LOG OUT" OnClick="logoutBtn_Click"/>            
        </div>
    </form>
</body>
</html>
