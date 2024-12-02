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
            <div class="headBtnLayout">
                <asp:Button ID="homeBtn" CssClass="headBtn" runat="server" Text="Home" />
                <asp:Button ID="historyBtn" CssClass="headBtn" runat="server" Text="History" OnClick="historyBtn_Click" />
            </div>
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
                <div id="foodServiceContainer" class="serviceContainer">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Icons/food-service.png" class="servicesLogo"/>
                    <asp:Label ID="foodServiceLbl" CssClass="servicesLbl" runat="server" Text="Food Service" />
                        <div class="serviceContainer2">
                            <asp:Label ID="foodServiceDescriptionLbl" CssClass="servicesDescriptionLbl" runat="server" Text="Order food in different online food and grocery delivery platform!" />
                            <asp:Button ID="foodServiceBtn" runat="server" CssClass="servicesBtnLayout" OnClick="foodServiceBtn_Click"/>
                        </div>
                </div>

                <div id="roomServicesContainer" class="serviceContainer">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Icons/roomservice.png" class="servicesLogo" />
                    <asp:Label ID="roomServiceLbl" CssClass="servicesLbl" runat="server" Text="Additional Request" />
                        <div class="serviceContainer2">
                            <asp:Label ID="roomServicesDescriptionLbl" CssClass="servicesDescriptionLbl" runat="server" Text="Request additional necessities for your comfortable stay!" />
                            <asp:Button ID="roomServicesBtn" runat="server" CssClass="servicesBtnLayout" OnClick="roomServicesBtn_Click"/>
                        </div>
                </div>
                <div id="mainteReqContainer" class="serviceContainer">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Icons/Sidebar%20Icons/tools.png" class="servicesLogo" />
                    <asp:Label ID="maintenanceRequestLbl" CssClass="servicesLbl" runat="server" Text="Maintenance Request" />
                    <div class="serviceContainer2">
                        <asp:Label ID="maintenanceRequestDescriptionLbl" CssClass="servicesDescriptionLbl" runat="server" Text="Report any maintenance issues for prompt assistance" />
                        <asp:Button id="mainteReqBtn" runat="server" CssClass="servicesBtnLayout" OnClick="mainteReqBtn_Click"/>
                    </div>
                </div>
            </div>
            
            <asp:Button id="logoutBtn" runat="server" Text="LOG OUT" OnClick="logoutBtn_Click"/>          
            
        </div>

        <asp:Panel ID="overlay" runat="server" CssClass="overlay" Visible="false"></asp:Panel>

        <%-- FOR FOOD SERVICE PLATFORM --%>

        <asp:Panel ID="foodServicePlatform" runat="server" CssClass="form-container" Visible="false">
            <div id="foodServicePlatformLayout">
                <asp:Button ID="closefoodServicePlatformBtn" runat="server" CssClass="closeBtn" Text="X" OnClick="exitFormBtn_Click" />
                <div id="foodServiceSelectionLayout">
                    <div class="foodServiceSelected">
                        <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/Food%20Service%20Icons/grab.jpg" class="foodServiceIcon"/>
                        <asp:Button ID="grabFoodOrderLink" CssClass="orderBtn textFont" Text="ORDER !" runat="server" OnClick="grabFoodOrderLink_Click" />
                    </div>
                    <div class="foodServiceSelected">
                        <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/Food%20Service%20Icons/foodpanda.jpg" class="foodServiceIcon"/>
                        <asp:Button ID="foodPandaOrderLink" CssClass="orderBtn textFont" Text="ORDER !" runat="server" OnClick="foodPandaOrderLink_Click" />
                    </div>
                    <div class="foodServiceSelected">
                        <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/Food%20Service%20Icons/lalamove.jpg" class="foodServiceIcon" />
                        <asp:Button ID="lalamoveOrderLink" CssClass="orderBtn textFont" Text="ORDER !" runat="server" OnClick="lalamoveOrderLink_Click" />
                    </div>
                </div>
            </div>
        </asp:Panel>

        <%-- FOR MAINTENANCE FORM --%>
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
