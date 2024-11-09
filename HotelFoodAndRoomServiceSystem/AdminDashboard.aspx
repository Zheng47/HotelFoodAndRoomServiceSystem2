<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="HotelFoodAndRoomServiceSystem.AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel - Admin Side</title>
    <link rel="stylesheet" type="text/css" href="CssFiles/AdminDashboard.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class ="mainContainer">

            <div id="sideBarComponent">
                <div id="hotelIconAndName">
                    <img src="CssFiles/Gallery/Food And Room Services Elements/Images/nobg.png" id ="hotelLogo"/>
                    <asp:Label ID="hotelNameLbl" runat="server">H+ Hotel</asp:Label>
                </div>
                <div id="servicesSelection">
                    <asp:Button ID="dashboardBtn" runat="server" class="servicesButtons" Text="Dashboard" OnClick="dashboardBtn_Click" /> <br />
                    <asp:Button ID="serviceRequestBtn" runat="server" class="servicesButtons" Text="Service Request" OnClick="serviceRequestBtn_Click"/> <br />
                    <asp:Button ID="inventoryBtn" runat="server" class="servicesButtons" Text="Inventory" /> <br />
                    <asp:Button ID="maintenanceRequestBtn" runat="server" class="servicesButtons" Text="Maintenance Request" />

                    <footer id="adminInfoContainer">
                        <img src="CssFiles/Gallery/Food And Room Services Elements/Icons/user.png" id="adminIcon"/>
                        <div id="adminInfoContainer2">
                            <asp:Label ID="adminName" runat="server">Guest</asp:Label> <br />
                            <asp:Label ID ="adminPosition" runat="server">Administrator</asp:Label>
                        </div>
                    </footer>
                        <asp:Button ID="signOutBtn" runat="server" OnClick="signOutBtn_Click"/>
                </div>
            </div>


            <div id="dashboardPanel" runat="server" class="panel-content">
                <asp:Label ID="overviewLbl" runat="server">Overview</asp:Label>
                <div class="lineDesign"></div>
                <div id="staffStatusContainer">
                    <div class="staffStatus">
                        <asp:Label id="totalStaffLbl" runat="server" Text="Total Staff" />
                        <img src="CssFiles/Gallery/Food And Room Services Elements/Icons/user.png" class="staffIcon "/> <br />
                        <asp:Label ID="totalStaffCount" runat="server" Text="0"/>
                    </div>
                    <div class="staffStatus">
                        <asp:Label id="availabilityStaffLbl" runat="server" Text="Available" />
                        <img src="CssFiles/Gallery/Food And Room Services Elements/Icons/user.png" class="staffIcon"/> <br />
                        <asp:Label ID="availableStaffCount" runat="server" Text="0"/>
                    </div>
                    <div class="staffStatus">
                        <asp:Label id="occupiedStaffLbl" runat="server" Text="Occupied" />
                        <img src="CssFiles/Gallery/Food And Room Services Elements/Icons/user.png" class="staffIcon"/> <br />
                        <asp:Label ID="occupiedStaffCount" runat="server" Text="0"/>
                    </div>
                </div>
                <div id="staffDetails" >
                    <asp:Label id="employeeNameLbl" CssClass="employeeNameLbl" runat="server" Text="Employee Name"/>
                    <asp:Label id="scheduleLbl" CssClass="scheduleLbl" runat="server" Text="Schedule"/>
                    <asp:Label id="statusLbl" CssClass="statusLbl" runat="server" Text="Status"/>
                </div>

                <div>
                    <asp:Literal ID="employeeContainer" runat="server"></asp:Literal>
                </div>
                    <asp:Button ID="refreshBtn" runat="server" Text="Refresh" Onclick="refreshBtn_Click"/>
            </div>


           <div id="serviceRequestPanel" runat="server" class="panel-content" >
               <asp:Label ID="taskBoardLbl" runat="server" Text="Task Board" />
               <div class="lineDesign" />
                   <div id="taskBoardStatusLayout">
                       <asp:Button ID="toDoTaskBtn" CssClass="taskStatusButtons" runat="server" Text="To-Do"/>
                       <asp:Label ID="toDoCountLbl" class="taskStatusCount" runat="server" Text="0"/>
                       <asp:Button ID="foodAndBeveragesTaskBtn" CssClass="taskStatusButtons" runat="server" Text="Food And Beverages" />
                       <asp:Label ID="foodAndBeveragesCountLbl" class="taskStatusCount" runat="server" Text="0" />
                       <asp:Button ID="roomServiceTaskBtn" CssClass="taskStatusButtons" runat="server" Text="Room Service" />
                       <asp:Label ID="roomServiceCountLbl" class="taskStatusCount" runat="server" Text="0" />
                       <asp:Button ID="inProgressTaskBtn" CssClass="taskStatusButtons" runat="server" Text="In-Progress" />
                       <asp:Label ID="inProgressCountLbl" class="taskStatusCount" runat="server" Text="0" />
                       <asp:Button ID="completedTaskBtn" CssClass="taskStatusButtons" runat="server" Text="Completed" />
                       <asp:Label ID="completedCountLbl" class="taskStatusCount" runat="server" Text="0" />
                   </div>
           </div>

        </div>
    </form>
</body>
</html>
