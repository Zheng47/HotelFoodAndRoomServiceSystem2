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
                    <asp:Button ID="inventoryBtn" runat="server" class="servicesButtons" Text="Inventory" OnClick="inventoryBtn_Click" /> <br />
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

            <%-- DASHBOARD PANEL --%>
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
                    <asp:Label ID="employeeIdLbl" CssClass="employeeIdLbl" runat="server" Text="Employee ID" />
                    <asp:Label id="employeeNameLbl" CssClass="employeeNameLbl" runat="server" Text="Employee Name"/>
                    <asp:Label id="scheduleLbl" CssClass="scheduleLbl" runat="server" Text="Schedule"/>
                    <asp:Label id="statusLbl" CssClass="statusLbl" runat="server" Text="Status"/>
                </div>

                <div>
                    <asp:Literal ID="employeeContainer" runat="server"></asp:Literal>
                </div>
                    <asp:Button ID="refreshBtn" runat="server" Text="Refresh" Onclick="refreshBtn_Click"/>
            </div>

            <%-- SERVICE REQUEST PANEL --%>
           <div id="serviceRequestPanel" runat="server">
               <asp:Label ID="taskBoardLbl" runat="server" Text="Task Board" />
               <div class="lineDesign"></div>
                <div id="taskBoardStatusLayout">
                    <asp:Button ID="foodAndBeveragesTaskBtn" CssClass="taskStatusButtons" runat="server" Text="Food And Beverages" OnClick="foodAndBeveragesTaskBtn_Click" />
                    <asp:Label ID="foodAndBeveragesCountLbl" class="taskStatusCount" runat="server" Text="0" />
                    <asp:Button ID="roomServiceTaskBtn" CssClass="taskStatusButtons" runat="server" Text="Room Service" OnClick="roomServiceTaskBtn_Click" />
                    <asp:Label ID="roomServiceCountLbl" class="taskStatusCount" runat="server" Text="0" />
                    <asp:Button ID="foodinProgressTaskBtn" CssClass="taskStatusButtons" runat="server" Text="Food Service In-Progress" OnClick="foodinProgressTaskBtn_Click" />
                    <asp:Label ID="foodinProgressCountLbl" class="taskStatusCount" runat="server" Text="0" />
                    <asp:Button ID="roominProgressTaskBtn" CssClass="taskStatusButtons" runat="server" Text="Room Service In-Progress" OnClick="roominProgressTaskBtn_Click" />
                    <asp:Label ID="roominProgressCountLbl" class="taskStatusCount" runat="server" Text="0" />
                </div>
                    
                <%-- FOOD SERVICE --%>
                <asp:Panel ID="foodServiceRequestPanel" runat="server" Visible="true">
                    <asp:Literal ID="foodRequestData" runat="server"></asp:Literal>
                </asp:Panel>
                <%-- ROOM SERVICE --%>
                <asp:Panel ID="roomServiceRequestPanel" runat="server" Visible="false">
                    <asp:Literal ID="roomServiceRequestData" runat="server"></asp:Literal>
                </asp:Panel>
                <%-- IN PROGRESS SERVICE REQUEST --%>
                <asp:Panel ID="foodInProgressServiceRequestPanel" runat="server" Visible="false">
                    <asp:Literal ID="foodInProgressRequestData" runat="server"></asp:Literal>
                </asp:Panel>
                <asp:Panel ID="roomInProgressServiceRequestPanel" runat="server" Visible="false">
                    <asp:Literal ID="roomInProgressRequestData" runat="server"></asp:Literal>
                </asp:Panel>

               <%-- ASSIGN EMPLOYEE BTN FOR SERVICE REQUEST --%>
               <asp:Button ID="foodServiceAssignBtn" CssClass="assignBtn" runat="server" Text="ASSIGN" Visible="true" OnClick="foodServiceAssignBtn_Click"/>
               <asp:Button ID="roomServiceAssignBtn" CssClass="assignBtn" runat="server" Text="ASSIGN" Visible="false" OnClick="roomServiceAssignBtn_Click" />

               <asp:Panel ID="foodServiceAssignStaffPanel" runat="server" Visible="false">
                    <div class="foodServiceAssignStaffContent textFont2">
                        <asp:Label ID="orderIdText" runat="server" Text="ORDER ID:" />
                        <asp:TextBox ID="orderIdTxtBox" TextMode="Number" runat="server" Placeholder="Enter Order ID" />
                    </div>
                    <div class="foodServiceAssignStaffContent textFont2">
                        <asp:Label ID="foodServiceEmployeeIdText" runat="server" Text="EMPLOYEE ID: "/>
                        <asp:TextBox ID="foodServiceEmployeeIdTxtBox" TextMode="Number"  runat="server" Placeholder="Enter Employee ID" />
                    </div>
                    <div class="foodServiceAssignStaffBtnLayout textFont">
                        <asp:Button ID="foodServiceAssignEmployeeBtn" runat="server" Text="ASSIGN" OnClick="foodServiceAssignEmployeeBtn_Click" />
                        <asp:Button ID="cancelFoodServiceAssignEmployeeBtn" runat="server" Text="CANCEL" OnClick="cancelFoodServiceAssignEmployeeBtn_Click" />
                    </div>
               </asp:Panel>

               <asp:Panel ID="roomServiceAssignStaffPanel" runat="server" Visible="false">
                    <div class="roomServiceAssignStaffContent textFont2">
                        <asp:Label ID="requestIdText" runat="server" Text="REQUEST ID:" />
                        <asp:TextBox ID="requestIdTxtBox" TextMode="Number" runat="server" Placeholder="Enter Request ID" />
                    </div>
                    <div class="roomServiceAssignStaffContent textFont2">
                        <asp:Label ID="roomServiceEmployeeIdText" runat="server" Text="EMPLOYEE ID: "/>
                        <asp:TextBox ID="roomServiceEmployeeIdTxtBox" TextMode="Number"  runat="server" Placeholder="Enter Employee ID" />
                    </div>
                    <div class="roomServiceAssignStaffBtnLayout textFont">
                        <asp:Button ID="roomServiceAssignEmployeeBtn" runat="server" Text="ASSIGN" OnClick="roomServiceAssignEmployeeBtn_Click" />
                        <asp:Button ID="cancelRoomServiceAssignEmployeeBtn" runat="server" Text="CANCEL" OnClick="cancelRoomServiceAssignEmployeeBtn_Click" />
                    </div>
               </asp:Panel>
           </div>

            <%-- INVENTORY PANEL --%>
            <div id="inventoryPanel" class="textFont" runat="server">
                <asp:Label ID="allItemsLbl" runat="server" Text="All Items" />
                <div class="lineDesign"></div>
                <div id="inventoryContainer1">
                    <asp:TextBox ID="searchItem" OnTextChanged="searchItem_TextChanged" AutoPostBack="True" runat="server" Placeholder="Search Item">
                    </asp:TextBox>
                    <asp:Button ID="addItemBtn" runat="server" Text="ADD ITEM" OnClick="addItemBtn_Click" />
                </div>
                <div id="inventoryContainer2">
                    <div id="inventoryTable">
                        <div class="inventoryRow">
                            <div class="inventoryContent">
                                <asp:Label ID="itemIdLbl" runat="server" Text="Item ID" />
                            </div>
                            <div class="inventoryContent">
                                <asp:Label ID="itemImage" runat="server" Text="Image" />
                            </div>
                            <div class="inventoryContent">
                                <asp:Label ID="itemNameLbl" runat="server" Text="Item Name" />
                            </div>
                            <div class="inventoryContent">
                                <asp:Label ID="itemAmountLbl" runat="server" Text="Amount" />
                            </div>
                        </div>

                        <asp:Literal ID="inventoryData" runat="server"></asp:Literal>
                    </div>
                    <asp:Button ID="refreshInventoryBtn" runat="server" Text="REFRESH" OnClick="refreshInventoryBtn_Click" />
                </div>
            </div>

            <asp:Panel ID="addItemPanel" runat="server" Visible="false">
                <div id="addItemContent">
                    <div id="addItemContent1" class="textFont">
                        <asp:Label ID="addNewItemLbl" runat="server" Text=" Add New Item" />
                        <asp:Button ID="closeAddItemBtn" runat="server" Text="X" OnClick="closeAddItemBtn_Click" />
                    </div>
                    <div id="addItemContent2" class="textFont">
                        <div class="addItemMainContent">
                            <asp:Label ID="insertItemIdLbl" CssClass="addItemLbl" runat="server" Text="Item ID:" />
                            <asp:TextBox ID="insertItemIdTxtBox" CssClass="addItemTxtBox" runat="server" TextMode="Number" Placeholder="Enter Item ID" />
                            <asp:Label ID="insertItemImgLbl" CssClass="addItemLbl" runat="server" Text="Item Image:" />
                            <asp:FileUpload ID="insertItemImgFile" runat="server" />
                            <asp:Label ID="insertItemPriceLbl" CssClass="addItemLbl" runat="server" Text="Item Price:" />
                            <asp:TextBox ID="insertItemPriceTxtBox" CssClass="addItemTxtBox" runat="server" TextMode="Number" Placeholder="Enter Item Price" />
                        </div>
                        <div class="addItemMainContent">
                            <asp:Label ID="insertItemName" CssClass="addItemLbl" runat="server" Text="Item Name:" />
                            <asp:TextBox ID="insertItemNameTxtBox" CssClass="addItemTxtBox" runat="server" Placeholder="Enter Item Name" />
                            <asp:Label ID="insertAmountLbl" CssClass="addItemLbl" runat="server" Text="Amount:" />
                            <asp:TextBox ID="insertAmountTxtBox" CssClass="addItemTxtBox" runat="server" TextMode="Number" Placeholder="Enter Amount" />
                        </div>
                    </div>
                </div>
                <div id="addItemBtnLayout">
                    <asp:Button ID="addThisItemBtn" runat="server" Text="ADD ITEM" OnClick="addThisItemBtn_Click" />
                </div>
            </asp:Panel>

            <%-- MAINTENANCE REQUEST PANEL --%>
            <div id="maintenanceRequestPanel" runat="server" >
                <asp:Label ID="maintenanceRequestLbl" runat="server" Text="Maintenance Request" />
                <div class="lineDesign"></div>

                <div id="maintenanceRequestContainer">
                    <asp:Literal ID="maintenanceRequestData" runat="server"></asp:Literal>
                </div>

                <asp:Button ID="assignBtn" CssClass="assignBtn" runat="server" Text="ASSIGN" OnClick="assignBtn_Clicked" />
                <asp:Panel ID="overlay2" CssClass="overlay" runat="server" Visible="false"></asp:Panel>

                <%-- FOR ASSIGNING EMPLOYEE IN MAINTENANCE REQUEST --%>
                <asp:Panel ID="assignStaffPanel" runat="server" Visible="false">
                    <div class="assignStaffContent textFont2">
                        <asp:Label ID="taskIdText" runat="server" Text="TASK ID:" />
                        <asp:TextBox ID="taskIdTxtBox" TextMode="Number" runat="server" Placeholder="Enter Task ID" />
                    </div>
                    <div class="assignStaffContent textFont2">
                        <asp:Label ID="employeeIdText" runat="server" Text="EMPLOYEE ID: "/>
                        <asp:TextBox ID="employeeIdTxtBox"  runat="server" Placeholder="Enter Employee ID" />
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
