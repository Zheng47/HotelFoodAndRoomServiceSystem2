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
                    <asp:Label ID="hotelNameLbl" runat="server">H+ HOTEL</asp:Label>
                </div>
                <div id="servicesSelection">
                    <asp:Button ID="dashboardBtn" runat="server" class="servicesButtons" Text="Dashboard" OnClick="dashboardBtn_Click" /> <br />
                    <asp:Button ID="serviceRequestBtn" runat="server" class="servicesButtons" Text="Service Request" OnClick="serviceRequestBtn_Click"/> <br />
                    <asp:Button ID="inventoryBtn" runat="server" class="servicesButtons" Text="Inventory" /> <br />
                    <asp:Button ID="maintenanceRequestBtn" runat="server" class="servicesButtons" Text="Maintenance Request" OnClick="maintenanceRequestBtn_Click" />

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

            <%-- FOR CONRFIRMATION OF SIGN OUT --%>
            <asp:Panel ID="overlay" CssClass="overlay" runat="server" Visible="false"></asp:Panel>

            <asp:Panel ID="confirmSignOutPanel" CssClass="confirmSignOutPanel" runat="server" Visible="false">
                <asp:Label ID="confirmSignOutLbl" CssClass="textFont" runat="server" Text="Confirm" />
                <asp:Label ID="signOutQuestionLbl" CssClass="textFont" runat="server" Text="Are you sure you want to log out?" />
                <div id="buttonSelection">
                    <asp:Button ID="okBtn" CssClass="textFont" runat="server" Text="OK" OnClick="okBtn_Click"/>
                    <asp:Button ID="cancelBtn" CssClass="textFont" runat="server" Text="Cancel" OnClick="cancelBtn_Click" />
                </div>
            </asp:Panel>


            <div id="dashboardPanel" runat="server">
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


           <div id="serviceRequestPanel" runat="server">
               <asp:Label ID="taskBoardLbl" runat="server" Text="Task Board" />
               <div class="lineDesign"></div>
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

            <div id="maintenanceRequestPanel" runat="server" >
                <asp:Label ID="maintenanceRequestLbl" runat="server" Text="Maintenance Request" />
                <div class="lineDesign"></div>

                <div id="maintenanceRequestContainer">
                    <asp:Literal ID="maintenanceRequestData" runat="server"></asp:Literal>
                </div>

                <asp:Button ID="assignBtn" CssClass="assignBtn" runat="server" Text="ASSIGN" OnClick="assignBtn_Clicked" />
                <asp:Panel ID="overlay2" CssClass="overlay" runat="server" Visible="false"></asp:Panel>

                <asp:Panel ID="assignStaffPanel" runat="server" Visible="false">
                    <div class="assignStaffContent textFont2">
                        <asp:Label ID="taskIdText" runat="server" Text="TASK ID:" />
                        <asp:TextBox ID="taskIdTxtBox" TextMode="Number" runat="server" Placeholder="Enter Task ID" />
                    </div>
                    <div class="assignStaffContent textFont2">
                        <asp:Label ID="employeeNameText" runat="server" Text="EMPLOYEE NAME: "/>
                        <asp:TextBox ID="employeeNameTxtBox"  runat="server" Placeholder="Enter employee name (LN, FN MN)" />
                    </div>
                    <div class="assignStaffBtnLayout textFont">
                        <asp:Button ID="assignEmployeeBtn" runat="server" Text="ASSIGN" OnClick="assignEmployeeBtn_Click" />
                        <asp:Button ID="cancelAssignEmployeeBtn" runat="server" Text="CANCEL" OnClick="cancelAssignEmployeeBtn_Click" />
                    </div>
                </asp:Panel>
            </div>

        </div>
    </form>
</body>
</html>
