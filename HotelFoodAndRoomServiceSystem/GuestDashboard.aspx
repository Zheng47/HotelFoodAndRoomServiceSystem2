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
                <div id="foodServicesContainer" class="serviceContainer">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Icons/food-service.png" class="servicesLogo" />
                    <asp:Label ID="foodServicesLbl" CssClass="servicesLbl" runat="server" Text="Food Services" />
                    <div class="serviceContainer2">
                        <asp:Label ID="foodServicesDescriptionLbl" CssClass="servicesDescriptionLbl" runat="server" Text="Order food and beverages for your stay."/>
                        <asp:Button ID="foodServicesBtn" CssClass="servicesBtnLayout" runat="server" OnClick="foodServicesBtn_Click" />
                    </div>
                </div>
                <div id="roomServicesContainer" class="serviceContainer">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Icons/roomservice.png" class="servicesLogo" />
                    <asp:Label ID="roomServiceLbl" CssClass="servicesLbl" runat="server" Text="Room Services" />
                        <div class="serviceContainer2">
                            <asp:Label ID="roomServicesDescriptionLbl" CssClass="servicesDescriptionLbl" runat="server" Text="heheheheh" />
                            <asp:Button ID="roomServicesBtn" runat="server" CssClass="servicesBtnLayout" OnClick="roomServicesBtn_Click"/>
                        </div>
                </div>
                <div id="mainteReqContainer" class="serviceContainer">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Icons/Sidebar%20Icons/tools.png" class="servicesLogo" />
                    <asp:Label ID="maintenanceRequestLbl" CssClass="servicesLbl" runat="server" Text="Maintenance Request" />
                    <div class="serviceContainer2">
                        <asp:Label ID="maintenanceRequestDescriptionLbl" CssClass="servicesDescriptionLbl" runat="server" Text="hehehehe" />
                        <asp:Button id="mainteReqBtn" runat="server" CssClass="servicesBtnLayout" OnClick="mainteReqBtn_Click"/>
                    </div>
                </div>
            </div>
            
            <asp:Button id="logoutBtn" runat="server" Text="LOG OUT" OnClick="logoutBtn_Click"/>          
            
        </div>

        <asp:Panel ID="overlay" runat="server" CssClass="overlay" Visible="false"></asp:Panel>

        <asp:Panel ID="maintenanceRequestForm" runat="server" CssClass="form-container" Visible="false">
            <div id="formSubContainer">
                <asp:Label id="mainteRequestFormLbl" runat="server" Text="Maintenance Request Fill Up Form" />
                <asp:Button ID="btnClose" runat="server" Text="×" CssClass="closeBtn" OnClick="exitFormBtn_Click" />
            </div>

            <div id="formSubContainer2">
                <div id="roomNumberContainer">
                    <asp:Label ID="roomNumberLabel"  Cssclass="textContent" runat="server" Text="Room Number*" />
                    <asp:TextBox ID="roomNumberTxtBox" Cssclass="txtBoxContent" TextMode="Number" runat="server" Placeholder="Enter Room Number" />
                </div>

                <div id="guestNameContainer">
                    <asp:Label ID="guestNameLabel" CssClass="textContent" runat="server" Text="Guest Name*" />
                    <asp:TextBox ID="guestNameTxtBox" CssClass="txtBoxContent" runat="server" Placeholder="Enter your name" />
                </div>
            </div>

            <div id="issueTitleContainer">
                <asp:Label ID="issueTitleLabel" CssClass="textContent" runat="server" Text="Issue Title*" />
                <asp:TextBox ID="issueTitleTxtBox" CssClass="txtBoxContent" runat="server" Placeholder="Enter Issue Title" />
            </div>
            <asp:TextBox ID="issueDescriptionTxtBox" runat="server" TextMode="Multiline" Placeholder="Enter Maintenance Request Description" />
            <asp:Button ID="submitBtn" class="textContent" runat="server" Text="Submit" Onclick="submitBtn_Click" />
        </asp:Panel>

    </form>
</body>
</html>
