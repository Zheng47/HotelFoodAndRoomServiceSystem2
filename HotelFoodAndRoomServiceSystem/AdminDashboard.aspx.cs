using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace HotelFoodAndRoomServiceSystem
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OpenDB();

            if (Session["Email"] != null)
            {
                adminName.Text = Session["LastName"].ToString() + ", " + Session["FirstName"].ToString() + " " + Session["MiddleName"].ToString();
                adminPosition.Text = Session["Position"].ToString();
            }

            if (!IsPostBack)
            {
                //FOR DASHBOARD PANEL
                retrieveEmployeesData();
                ShowOnlyDashboardPanel();
                retrieveTotalStaffCount();
                retrieveStatusCount();

                //FOR SERVICE REQUEST UNDER FOOD AND BEVERAGES SERVICES
                retrieveTotalFoodServiceRequest();
                retrieveFoodServiceRequest();

                //FOR SERVICE REQUEST UNDER ROOM SERVICES
                retrieveTotalRoomServiceRequest();
                retrieveRoomServiceRequest();

                //FOR INVENTORY
                retrieveInventoryData();

                //FOR IN PROGRESS SERVICE REQUEST
                retrieveInProgressFoodService();
                totalFoodServiceInProgress();
                retrieveInProgressRoomService();
                totalRoomServiceInProgress();
            }

        }
        
        //DATABASE CONNECTION
        public MySqlConnection dbconn = new MySqlConnection("server=localhost;username=root;password=;database=hotelmanagement");

        private void OpenDB()
        {
            try
            {
                dbconn.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void CloseDB()
        {
            try
            {
                dbconn.Close();
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
        }

        // RETRIEVE EMPLOYEE DATA
        private void retrieveEmployeesData()
        {
            try
            {
                String retrieveEmployeeData = "SELECT CONCAT(last_name, ', ', first_name, ' ', middle_name) AS FullName, schedule, status FROM employees";
                MySqlCommand cmd = new MySqlCommand(retrieveEmployeeData, dbconn);
                MySqlDataAdapter dataAdapater = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapater.Fill(dataTable);

                StringBuilder divHtml = new StringBuilder();

                // Generate rows for each employee
                foreach (DataRow row in dataTable.Rows)
                {
                    divHtml.Append("<div class='employeesTable'>");
                    divHtml.Append($"<div id='employeeNameLayout'>{row["FullName"]}</div>");
                    divHtml.Append($"<div id='scheduleLayout'>{row["schedule"]}</div>");
                    divHtml.Append($"<div id='statusLayout'>{row["status"]}</div>");
                    divHtml.Append("</div>");
                }

                employeeContainer.Text = divHtml.ToString(); // Set HTML to Literal control
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //RETRIEVE EMPLOYEE STATUS COUNT
        private void retrieveStatusCount ()
        {
            try
            {
                String retrieveAvailableStaffStatus = "SELECT COUNT(*) FROM employees WHERE status = 'Available' ";
                MySqlCommand cmdAvailable = new MySqlCommand( retrieveAvailableStaffStatus, dbconn);
                int availbleStaffTotal= Convert.ToInt32(cmdAvailable.ExecuteScalar());

                String retrieveOccupiedStaffStatus = "SELECT COUNT(*) FROM employees WHERE status = 'Occupied' ";
                MySqlCommand cmdOccupied = new MySqlCommand( retrieveOccupiedStaffStatus, dbconn);
                int occupiedStaffTotal = Convert.ToInt32 (cmdOccupied.ExecuteScalar());

                availableStaffCount.Text = availbleStaffTotal.ToString();
                occupiedStaffCount.Text = occupiedStaffTotal.ToString();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //RETRIEVE EMPLOYEE COUNT 

        private void retrieveTotalStaffCount ()
        {
            try
            {
                String countTotalemployees = "SELECT COUNT(*) FROM employees";
                MySqlCommand cmd = new MySqlCommand(countTotalemployees, dbconn);


                object result = cmd.ExecuteScalar();
                int totalEmployees = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                totalStaffCount.Text = totalEmployees.ToString();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // FOR SIGNING OUT
        protected void signOutBtn_Click(object sender, EventArgs e)
        {
            overlay.Visible = true;
            confirmSignOutPanel.Visible = true;
        }

        protected void okBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("AdminLogin.aspx");
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            overlay.Visible = false;
            confirmSignOutPanel.Visible = false;
        }

        //REFRESHING DASHBOARD PANEL
        protected void refreshBtn_Click(object sender, EventArgs e)
        {
            ShowOnlyDashboardPanel();
        }

        // SELECTIONS OF PANEL
        protected void dashboardBtn_Click(object sender, EventArgs e)
        {
            ShowOnlyDashboardPanel();
        }
        protected void serviceRequestBtn_Click(object sender, EventArgs e)
        {
            ShowOnlyServiceRequestPanel();

            //FOR SERVICE REQUEST UNDER FOOD AND BEVERAGES SERVICES
            retrieveTotalFoodServiceRequest();
            retrieveFoodServiceRequest();

            //FOR SERVICE REQUEST UNDER ROOM SERVICES
            retrieveTotalRoomServiceRequest();
            retrieveRoomServiceRequest();

            //FOR IN PROGRESS SERVICE REQUEST
            retrieveInProgressFoodService();
            totalFoodServiceInProgress();
            retrieveInProgressRoomService();
            totalRoomServiceInProgress();
        }

        protected void inventoryBtn_Click(object sender, EventArgs e)
        {
            ShowOnlyInventory();
            retrieveInventoryData();
        }

        protected void maintenanceRequestBtn_Click(object sender, EventArgs e)
        {
            ShowOnlyMaintenanceRequestPanel();
            retrieveMaintenanceRequest();
        }



        //FOR SHOWING DIFFERENT PANELS  
        private void ShowOnlyDashboardPanel()
        {
            // BACKGROUND COLOR OF BUTTONS
            dashboardBtn.Style["background-color"] = "#EAEAEA";
            serviceRequestBtn.Style["background-color"] = "transparent";
            inventoryBtn.Style["background-color"] = "transparent";
            maintenanceRequestBtn.Style["background-color"] = "transparent";

            // TEXT COLOR OF BUTTON
            dashboardBtn.Style["color"] = "blue";
            serviceRequestBtn.Style["color"] = "black";
            inventoryBtn.Style["color"] = "black";
            maintenanceRequestBtn.Style["color"] = "black";

            // DISPLAY PANEL WHEN CLICKING THE BUTTON
            dashboardPanel.Style["display"] = "block";
            serviceRequestPanel.Style["display"] = "none";
            inventoryPanel.Style["display"] = "none";
            maintenanceRequestPanel.Style["display"] = "none";

            retrieveEmployeesData();
            retrieveTotalStaffCount();
            retrieveStatusCount();
        }

        private void ShowOnlyServiceRequestPanel()
        {
            // BACKGROUND COLOR OF BUTTONS
            dashboardBtn.Style["background-color"] = "transparent";
            serviceRequestBtn.Style["background-color"] = "#EAEAEA";
            inventoryBtn.Style["background-color"] = "transparent";
            maintenanceRequestBtn.Style["background-color"] = "transparent";

            // TEXT COLOR OF BUTTON
            dashboardBtn.Style["color"] = "black";
            serviceRequestBtn.Style["color"] = "blue";
            inventoryBtn.Style["color"] = "black";
            maintenanceRequestBtn.Style["color"] = "black";

            // DISPLAY PANEL WHEN CLICKING THE BUTTON
            dashboardPanel.Style["display"] = "none";
            serviceRequestPanel.Style["display"] = "block";
            inventoryPanel.Style["display"] = "none";
            maintenanceRequestPanel.Style["display"] = "none";
        }

        private void ShowOnlyInventory()
        {
            // BACKGROUND COLOR OF BUTTONS
            dashboardBtn.Style["background-color"] = "transparent";
            serviceRequestBtn.Style["background-color"] = "transparent";
            inventoryBtn.Style["background-color"] = "#EAEAEA";
            maintenanceRequestBtn.Style["background-color"] = "transparent";

            // TEXT COLOR OF BUTTON
            dashboardBtn.Style["color"] = "black";
            serviceRequestBtn.Style["color"] = "black";
            inventoryBtn.Style["color"] = "blue";
            maintenanceRequestBtn.Style["color"] = "black";

            // DISPLAY PANEL WHEN CLICKING THE BUTTON
            dashboardPanel.Style["display"] = "none";
            serviceRequestPanel.Style["display"] = "none";
            inventoryPanel.Style["display"] = "block";
            maintenanceRequestPanel.Style["display"] = "none";
        }

        private void ShowOnlyMaintenanceRequestPanel() 
        {
            // BACKGROUND COLOR OF BUTTONS
            dashboardBtn.Style["background-color"] = "transparent";
            serviceRequestBtn.Style["background-color"] = "transparent";
            inventoryBtn.Style["background-color"] = "transparent";
            maintenanceRequestBtn.Style["background-color"] = "#EAEAEA";


            // TEXT COLOR OF BUTTON
            dashboardBtn.Style["color"] = "black";
            serviceRequestBtn.Style["color"] = "black";
            inventoryBtn.Style["color"] = "black";
            maintenanceRequestBtn.Style["color"] = "blue";


            // DISPLAY PANEL WHEN CLICKING THE BUTTON
            dashboardPanel.Style["display"] = "none";
            serviceRequestPanel.Style["display"] = "none";
            inventoryPanel.Style["display"] = "none";
            maintenanceRequestPanel.Style["display"] = "block";
        }

        //RETRIEVING GUEST FOOD SERVICE REQUEST 

        protected void foodAndBeveragesTaskBtn_Click(object sender, EventArgs e)
        {
            foodServiceRequestPanel.Visible = true;
            roomServiceRequestPanel.Visible = false;
            foodInProgressServiceRequestPanel.Visible = false;
            roomInProgressServiceRequestPanel.Visible = false;

            //ASSIGN EMPLOYEE BTN IN SERVICE REQUEST
            foodServiceAssignBtn.Visible = true;
            roomServiceAssignBtn.Visible = false;

            retrieveTotalFoodServiceRequest();
            retrieveFoodServiceRequest();
        }

        private void retrieveTotalFoodServiceRequest()
        {
            try
            {
                String retrieveTotalFoodService = "SELECT COUNT(*) FROM guestfoodservicehistory WHERE status = 'Pending'";
                MySqlCommand cmd = new MySqlCommand(retrieveTotalFoodService, dbconn);
                
                object result = cmd.ExecuteScalar();
                int totalFoodService = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                foodAndBeveragesCountLbl.Text = totalFoodService.ToString();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        private void retrieveFoodServiceRequest()
        {
            try
            {
                String retrieveFoodServiceRequestQuery = "SELECT * FROM guestfoodservicehistory WHERE status = 'Pending'";
                MySqlCommand cmd = new MySqlCommand(retrieveFoodServiceRequestQuery, dbconn);


                MySqlDataAdapter dataAdapater = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapater.Fill(dataTable);

                StringBuilder divHtml = new StringBuilder();

                foreach (DataRow row in dataTable.Rows)
                {
                    divHtml.Append("<div class='foodRequestTable'>");

                    divHtml.Append("<div id='foodRequestTableContent1' class='foodRequestTableContent foodRequestTableText textFont2'> ");
                    divHtml.Append($"<div id='foodOrderIdLbl'>{"ORDER ID: " + row["order_id"]}</div>");
                    divHtml.Append($"<div id='foodRoomNumLbl'>{"ROOM # " + row["room_number"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("<div class='foodRequestTableContent foodRequestTableText textFont2'>");
                    divHtml.Append($"<div id='foodGuestNameLbl'>{"GUEST NAME: " + row["guest_name"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("<div class='requestTableContent2 textFont'>");
                    divHtml.Append($"<div id='foodItemNameLbl'>{row["item_ordered"] + " " + "(" + row["quantity"] + ")"}</div>");
                    divHtml.Append($"<div id='foodPriceLbl'>{"ITEM PRICE: ₱" + row["item_price"]}</div>");
                    divHtml.Append($"<div id='foodTotalPriceLbl'>{"TOTAL: ₱" + row["total_price"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("<div class='foodRequestTableContent textFont2'>");
                    divHtml.Append($"<div id='foodAssignedStaffLbl'>{"ASSIGNED EMPLOYEE: " + row["assigned_employee"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("<div class='requestTableContent3 textFont2'>");
                    DateTime requestDate = Convert.ToDateTime(row["order_date"]);
                    divHtml.Append($"<div id='foodRequestDateLbl'>{requestDate: yyyy-MM-dd HH-mm-ss}</div>");
                    divHtml.Append($"<div id='foodRequestStatusLbl'>{"STATUS: " + row["status"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("</div>");

                    foodRequestData.Text = divHtml.ToString();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }




        //RETRIEVING GUEST ROOM SERVICE REQUEST

        protected void roomServiceTaskBtn_Click(object sender, EventArgs e)
        {
            foodServiceRequestPanel.Visible = false;
            roomServiceRequestPanel.Visible = true;
            foodInProgressServiceRequestPanel.Visible = false;
            roomInProgressServiceRequestPanel.Visible = false;

            //ASSIGN EMPLOYEE BTN IN SERVICE REQUEST
            foodServiceAssignBtn.Visible = false;
            roomServiceAssignBtn.Visible = true;

            retrieveTotalRoomServiceRequest();
            retrieveRoomServiceRequest();
        }

        private void retrieveTotalRoomServiceRequest()
        {
            try
            {
                String retrieveTotalRoomService = "SELECT COUNT(*) FROM guestroomservicehistory WHERE status = 'Pending'";
                MySqlCommand cmd = new MySqlCommand(retrieveTotalRoomService, dbconn);

                object result = cmd.ExecuteScalar();
                int totalRoomService = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                roomServiceCountLbl.Text = totalRoomService.ToString();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void retrieveRoomServiceRequest()
        {
            try
            {
                String retrieveRoomServiceRequestQuery = "SELECT * FROM guestroomservicehistory WHERE status = 'Pending'";
                MySqlCommand cmd = new MySqlCommand(retrieveRoomServiceRequestQuery, dbconn);
                MySqlDataAdapter dataAdapater = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapater.Fill(dataTable);

                StringBuilder divHtml = new StringBuilder();

                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["service_type"].Equals("DRY CLEANING") || row["service_type"].Equals("WASH") || row["service_type"].Equals("STEAM IRON"))
                    {
                        divHtml.Append("<div class='roomRequestTable'>");

                        divHtml.Append("<div id='roomRequestTableContent1' class='roomRequestTableContent roomRequestTableText textFont2'> ");
                        divHtml.Append($"<div id='roomRequestIdLbl'>{"REQUEST ID: " + row["request_id"]}</div>");
                        divHtml.Append($"<div id='roomRoomNumLbl'>{"ROOM # " + row["room_number"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='roomRequestTableContent roomRequestTableText textFont2'>");
                        divHtml.Append($"<div id='roomGuestNameLbl'>{"GUEST NAME: " + row["guest_name"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='requestTableContent2 textFont'>");
                        divHtml.Append($"<div id='roomServiceNameLbl'>{row["service_type"] + " " + "(" + row["quantity"] + "kg" + ")"}</div>");
                        divHtml.Append($"<div id='roomPriceLbl'>{"SERVICE PRICE: ₱" + row["service_price"] + " per kg"}</div>");
                        divHtml.Append($"<div id='roomTotalPriceLbl'>{"TOTAL: ₱" + row["total_charges"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='roomRequestTableContent textFont2'>");
                        divHtml.Append($"<div id='roomAssignedStaffLbl'>{"ASSIGNED EMPLOYEE: " + row["assigned_employee"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='requestTableContent3 textFont2'>");
                        DateTime requestDate = Convert.ToDateTime(row["request_date"]);
                        divHtml.Append($"<div id='roomRequestDateLbl'>{requestDate: yyyy-MM-dd HH-mm-ss}</div>");
                        divHtml.Append($"<div id='roomRequestStatusLbl'>{"STATUS: " + row["status"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("</div>");

                        roomServiceRequestData.Text = divHtml.ToString();

                    }
                    else if (row["service_type"].Equals("SPA PEDICURE") || row["service_type"].Equals("SPA MANICURE") || row["service_type"].Equals("DEEP CLEANSING FACIAL SPA"))
                    {
                        divHtml.Append("<div class='roomRequestTable'>");

                        divHtml.Append("<div id='roomRequestTableContent1' class='roomRequestTableContent roomRequestTableText textFont2'> ");
                        divHtml.Append($"<div id='roomRequestIdLbl'>{"REQUEST ID: " + row["request_id"]}</div>");
                        divHtml.Append($"<div id='roomRoomNumLbl'>{"ROOM # " + row["room_number"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='roomRequestTableContent roomRequestTableText textFont2'>");
                        divHtml.Append($"<div id='roomGuestNameLbl'>{"GUEST NAME: " + row["guest_name"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='requestTableContent2 textFont'>");
                        divHtml.Append($"<div id='roomServiceNameLbl'>{row["service_type"] + " " + "(" + row["quantity"] + ")"}</div>");
                        divHtml.Append($"<div id='roomPriceLbl'>{"SERVICE PRICE: ₱" + row["service_price"] + " per guest"}</div>");
                        divHtml.Append($"<div id='roomTotalPriceLbl'>{"TOTAL: ₱" + row["total_charges"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='roomRequestTableContent textFont2'>");
                        divHtml.Append($"<div id='roomAssignedStaffLbl'>{"ASSIGNED EMPLOYEE: " + row["assigned_employee"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='requestTableContent3 textFont2'>");
                        DateTime requestDate = Convert.ToDateTime(row["request_date"]);
                        divHtml.Append($"<div id='roomRequestDateLbl'>{requestDate: yyyy-MM-dd HH-mm-ss}</div>");
                        divHtml.Append($"<div id='roomRequestStatusLbl'>{"STATUS: " + row["status"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("</div>");

                        roomServiceRequestData.Text = divHtml.ToString();
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }



        //RETRIEVING IN PROGRESS GUEST REQUESTED SERVICES
        protected void foodinProgressTaskBtn_Click(object sender, EventArgs e)
        {
            foodServiceRequestPanel.Visible = false;
            roomServiceRequestPanel.Visible = false;
            foodInProgressServiceRequestPanel.Visible = true;
            roomInProgressServiceRequestPanel.Visible = false;

            //ASSIGN EMPLOYEE BTN IN SERVICE REQUEST
            foodServiceAssignBtn.Visible = false;
            roomServiceAssignBtn.Visible = false;

            totalFoodServiceInProgress();
            retrieveInProgressFoodService();
        }

        protected void roominProgressTaskBtn_Click(object sender, EventArgs e)
        {
            foodServiceRequestPanel.Visible = false;
            roomServiceRequestPanel.Visible = false;
            foodInProgressServiceRequestPanel.Visible = false;
            roomInProgressServiceRequestPanel.Visible = true;

            //ASSIGN EMPLOYEE BTN IN SERVICE REQUEST
            foodServiceAssignBtn.Visible = false;
            roomServiceAssignBtn.Visible = false;

            totalRoomServiceInProgress();
            retrieveInProgressRoomService();
        }

        private void retrieveInProgressFoodService()
        {
            try
            {
                String retrieveFoodServiceRequestQuery = "SELECT * FROM guestfoodservicehistory WHERE status = 'In-Progress'";
                MySqlCommand cmd = new MySqlCommand(retrieveFoodServiceRequestQuery, dbconn);


                MySqlDataAdapter dataAdapater = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapater.Fill(dataTable);

                StringBuilder divHtml = new StringBuilder();

                foreach (DataRow row in dataTable.Rows)
                {
                    divHtml.Append("<div class='foodRequestTable'>");

                    divHtml.Append("<div id='foodRequestTableContent1' class='foodRequestTableContent foodRequestTableText textFont2'> ");
                    divHtml.Append($"<div id='foodOrderIdLbl'>{"ORDER ID: " + row["order_id"]}</div>");
                    divHtml.Append($"<div id='foodRoomNumLbl'>{"ROOM # " + row["room_number"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("<div class='foodRequestTableContent foodRequestTableText textFont2'>");
                    divHtml.Append($"<div id='foodGuestNameLbl'>{"GUEST NAME: " + row["guest_name"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("<div class='requestTableContent2 textFont'>");
                    divHtml.Append($"<div id='foodItemNameLbl'>{row["item_ordered"] + " " + "(" + row["quantity"] + ")"}</div>");
                    divHtml.Append($"<div id='foodPriceLbl'>{"ITEM PRICE: ₱" + row["item_price"]}</div>");
                    divHtml.Append($"<div id='foodTotalPriceLbl'>{"TOTAL: ₱" + row["total_price"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("<div class='foodRequestTableContent textFont2'>");
                    divHtml.Append($"<div id='foodAssignedStaffLbl'>{"ASSIGNED EMPLOYEE: " + row["assigned_employee"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("<div class='requestTableContent3 textFont2'>");
                    DateTime requestDate = Convert.ToDateTime(row["order_date"]);
                    divHtml.Append($"<div id='foodRequestDateLbl'>{requestDate: yyyy-MM-dd HH-mm-ss}</div>");
                    divHtml.Append($"<div id='foodRequestStatusLbl'>{"STATUS: " + row["status"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("</div>");

                    foodInProgressRequestData.Text = divHtml.ToString();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void totalFoodServiceInProgress()
        {
            try
            {
                String retrieveTotalFoodService = "SELECT COUNT(*) FROM guestfoodservicehistory WHERE status = 'In-Progress'";
                MySqlCommand cmd = new MySqlCommand(retrieveTotalFoodService, dbconn);

                object result = cmd.ExecuteScalar();
                int totalFoodService = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                foodinProgressCountLbl.Text = totalFoodService.ToString();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void retrieveInProgressRoomService()
        {
            try
            {
                String retrieveRoomServiceRequestQuery = "SELECT * FROM guestroomservicehistory WHERE status = 'In-Progress'";
                MySqlCommand cmd = new MySqlCommand(retrieveRoomServiceRequestQuery, dbconn);
                MySqlDataAdapter dataAdapater = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapater.Fill(dataTable);

                StringBuilder divHtml = new StringBuilder();

                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["service_type"].Equals("DRY CLEANING") || row["service_type"].Equals("WASH") || row["service_type"].Equals("STEAM IRON"))
                    {
                        divHtml.Append("<div class='roomRequestTable'>");

                        divHtml.Append("<div id='roomRequestTableContent1' class='roomRequestTableContent roomRequestTableText textFont2'> ");
                        divHtml.Append($"<div id='roomRequestIdLbl'>{"REQUEST ID: " + row["request_id"]}</div>");
                        divHtml.Append($"<div id='roomRoomNumLbl'>{"ROOM # " + row["room_number"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='roomRequestTableContent roomRequestTableText textFont2'>");
                        divHtml.Append($"<div id='roomGuestNameLbl'>{"GUEST NAME: " + row["guest_name"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='requestTableContent2 textFont'>");
                        divHtml.Append($"<div id='roomServiceNameLbl'>{row["service_type"] + " " + "(" + row["quantity"] + "kg" + ")"}</div>");
                        divHtml.Append($"<div id='roomPriceLbl'>{"SERVICE PRICE: ₱" + row["service_price"] + " per kg"}</div>");
                        divHtml.Append($"<div id='roomTotalPriceLbl'>{"TOTAL: ₱" + row["total_charges"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='roomRequestTableContent textFont2'>");
                        divHtml.Append($"<div id='roomAssignedStaffLbl'>{"ASSIGNED EMPLOYEE: " + row["assigned_employee"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='requestTableContent3 textFont2'>");
                        DateTime requestDate = Convert.ToDateTime(row["request_date"]);
                        divHtml.Append($"<div id='roomRequestDateLbl'>{requestDate: yyyy-MM-dd HH-mm-ss}</div>");
                        divHtml.Append($"<div id='roomRequestStatusLbl'>{"STATUS: " + row["status"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("</div>");

                        roomInProgressRequestData.Text = divHtml.ToString();

                    }
                    else if (row["service_type"].Equals("SPA PEDICURE") || row["service_type"].Equals("SPA MANICURE") || row["service_type"].Equals("DEEP CLEANSING FACIAL SPA"))
                    {
                        divHtml.Append("<div class='roomRequestTable'>");

                        divHtml.Append("<div id='roomRequestTableContent1' class='roomRequestTableContent roomRequestTableText textFont2'> ");
                        divHtml.Append($"<div id='roomRequestIdLbl'>{"REQUEST ID: " + row["request_id"]}</div>");
                        divHtml.Append($"<div id='roomRoomNumLbl'>{"ROOM # " + row["room_number"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='roomRequestTableContent roomRequestTableText textFont2'>");
                        divHtml.Append($"<div id='roomGuestNameLbl'>{"GUEST NAME: " + row["guest_name"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='requestTableContent2 textFont'>");
                        divHtml.Append($"<div id='roomServiceNameLbl'>{row["service_type"] + " " + "(" + row["quantity"] + ")"}</div>");
                        divHtml.Append($"<div id='roomPriceLbl'>{"SERVICE PRICE: ₱" + row["service_price"] + " per guest"}</div>");
                        divHtml.Append($"<div id='roomTotalPriceLbl'>{"TOTAL: ₱" + row["total_charges"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='roomRequestTableContent textFont2'>");
                        divHtml.Append($"<div id='roomAssignedStaffLbl'>{"ASSIGNED EMPLOYEE: " + row["assigned_employee"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("<div class='requestTableContent3 textFont2'>");
                        DateTime requestDate = Convert.ToDateTime(row["request_date"]);
                        divHtml.Append($"<div id='roomRequestDateLbl'>{requestDate: yyyy-MM-dd HH-mm-ss}</div>");
                        divHtml.Append($"<div id='roomRequestStatusLbl'>{"STATUS: " + row["status"]}</div>");
                        divHtml.Append("</div>");

                        divHtml.Append("</div>");

                        roomInProgressRequestData.Text = divHtml.ToString();
                    }
                    
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void totalRoomServiceInProgress()
        {
            try
            {
                String retrieveTotalRoomService = "SELECT COUNT(*) FROM guestroomservicehistory WHERE status = 'In-Progress'";
                MySqlCommand cmd = new MySqlCommand(retrieveTotalRoomService, dbconn);

                object result = cmd.ExecuteScalar();
                int totalRoomService = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                roominProgressCountLbl.Text = totalRoomService.ToString();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //ASSIGN EMPLOYEE IN SERVICE REQUEST
        protected void foodServiceAssignBtn_Click(object sender, EventArgs e)
        {
            overlay.Visible = true;
            foodServiceAssignStaffPanel.Visible = true;
        }

        protected void roomServiceAssignBtn_Click(object sender, EventArgs e)
        {
            overlay.Visible = true;
            roomServiceAssignStaffPanel.Visible = true;
        }

        protected void foodServiceAssignEmployeeBtn_Click(object sender, EventArgs e)
        {
            String orderId = orderIdTxtBox.Text;
            String employeeId = foodServiceEmployeeIdTxtBox.Text;

            assignEmployeeTaskToFoodServiceRequest(orderId, employeeId);

            retrieveFoodServiceRequest();

            retrieveTotalFoodServiceRequest();
            totalFoodServiceInProgress();

            overlay.Visible = false;
            foodServiceAssignStaffPanel.Visible = false;
        }

        protected void cancelFoodServiceAssignEmployeeBtn_Click(object sender, EventArgs e)
        {
            overlay.Visible = false;
            foodServiceAssignStaffPanel.Visible = false;
        }

        protected void roomServiceAssignEmployeeBtn_Click(object sender, EventArgs e)
        {
            String requestID = requestIdTxtBox.Text;
            String assignedEmployee = roomServiceEmployeeIdTxtBox.Text;

            assignEmployeeTaskToRoomServiceRequest(requestID, assignedEmployee);

            retrieveTotalRoomServiceRequest();
            totalRoomServiceInProgress();

            overlay.Visible = false;
            roomServiceAssignStaffPanel.Visible = false;

        }

        protected void cancelRoomServiceAssignEmployeeBtn_Click(object sender, EventArgs e)
        {
            overlay.Visible = false;
            roomServiceAssignStaffPanel.Visible = false;
        }



        // RETRIEVING INVENTORY DATA 
        private void retrieveInventoryData(String searchTerm = "")
        {
            try
            {
                String retrieveInventory = "SELECT * FROM inventory WHERE item_name LIKE @searchTerm";
                MySqlCommand cmd = new MySqlCommand(retrieveInventory, dbconn);
                cmd.Parameters.AddWithValue("@searchTerm", "%"+searchTerm+"%");
                MySqlDataAdapter dataAdapater = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapater.Fill(dataTable);

                StringBuilder divHtml = new StringBuilder();

                foreach (DataRow row in dataTable.Rows)
                {
                    divHtml.Append("<div class='inventoryRow'>");

                    divHtml.Append("<div class='inventoryContent'>");
                    divHtml.Append($"<div id='itemIdLbl'>{row["item_id"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("<div class='inventoryContent'>");
                    if (row["image_data"] != DBNull.Value)
                    {
                        byte[] imageData = (byte[])row["image_data"];
                        string base64Image = Convert.ToBase64String(imageData);
                        divHtml.Append($"<img id='itemImage' src='data:image/jpeg;base64,{base64Image}' class='inventoryImgLayout'/>");
                    }
                    else
                    {
                        divHtml.Append("<img id='itemImage' src='/path/to/default/image.jpg' alt='No Image Available' style='width:100px; height:100px;' />");
                    }
                    divHtml.Append("</div>");

                    divHtml.Append("<div class='inventoryContent'>");
                    divHtml.Append($"<div id='itemNameLbl'>{row["item_name"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("<div class='inventoryContent'>");
                    divHtml.Append($"<div id='itemAmountLbl'>{row["amount"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("</div>");

                    inventoryData.Text= divHtml.ToString();
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected void refreshInventoryBtn_Click(object sender, EventArgs e)
        {
            retrieveInventoryData();
        }

        //FOR SEARCHING ITEMS IN INVENTORY
        protected void searchItem_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchItem.Text.Trim();
            retrieveInventoryData(searchTerm);
        }

        //ADD ITEM IN INVENTORY
        protected void addItemBtn_Click(object sender, EventArgs e)
        {
            overlay.Visible = true;
            addItemPanel.Visible = true;
        }

        protected void closeAddItemBtn_Click(object sender, EventArgs e)
        {
            overlay.Visible = false;
            addItemPanel.Visible = false;
        }

        protected void addThisItemBtn_Click(object sender, EventArgs e)
        {
            String itemID = insertItemIdTxtBox.Text;
            String itemName = insertItemNameTxtBox.Text;
            byte[] imageData = insertItemImgFile.FileBytes;
            String itemAmount = insertAmountTxtBox.Text;
            String price = insertItemPriceTxtBox.Text;

            insertItemsToInventory(itemID, itemName, imageData, itemAmount, price);
            retrieveInventoryData();

            overlay.Visible = false;
            addItemPanel.Visible = false;
        }

        private void insertItemsToInventory(String itemID,String itemName, byte[] imageData, String itemAmount, String price)
        {
            try
            {
                String insertItem = "INSERT INTO inventory(item_id, item_name, image_data, amount, price) VALUES (@1, @2, @3, @4, @5)";
                MySqlCommand cmd = new MySqlCommand(insertItem, dbconn);
                cmd.Parameters.AddWithValue("@1", itemID);
                cmd.Parameters.AddWithValue("@2", itemName);
                cmd.Parameters.AddWithValue("@3", imageData);
                cmd.Parameters.AddWithValue("@4", itemAmount);
                cmd.Parameters.AddWithValue("@5", price);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }



        //RETRIEVING GUEST MAINTENANCE REQUEST
        private void retrieveMaintenanceRequest()
        {
            try
            {
                String retrieveMaintenanceRequest = "SELECT * FROM maintenancerequest";
                MySqlCommand cmd = new MySqlCommand(retrieveMaintenanceRequest, dbconn);


                MySqlDataAdapter dataAdapate = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapate.Fill(dataTable);

                StringBuilder divHtml = new StringBuilder();

                foreach (DataRow row in dataTable.Rows)
                {
                    divHtml.Append("<div class='requestTable'>");

                    divHtml.Append("<div id='requestTableContent1' class='requestTableContent requestTableText textFont2'> ");
                    divHtml.Append($"<div id='taskIdLbl'>{"TASK ID: " + row["task_id"]}</div>");
                    divHtml.Append($"<div id='roomNumLbl'>{"ROOM # " + row["room_number"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("<div class='requestTableContent requestTableText textFont2'>");
                    divHtml.Append($"<div id='guestNameLbl'>{"GUEST NAME: " + row["guest_name"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("<div class='requestTableContent2 textFont'>");
                    divHtml.Append($"<div id='issueTitleLbl'>{row["issue_title"]}</div>");
                    divHtml.Append($"<div id='issueTitleDescription'>{row["issue_description"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("<div class='requestTableContent textFont2'>");
                    divHtml.Append($"<div id='assignedStaffLbl'>{"ASSIGNED EMPLOYEE: " + row["assigned_employee"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("<div class='requestTableContent3 textFont2'>");
                    DateTime requestDate = Convert.ToDateTime(row["request_date"]);
                    divHtml.Append($"<div id='requestDateLbl'>{requestDate: yyyy-MM-dd HH-mm-ss}</div>");
                    divHtml.Append($"<div id='maintenanceRequestStatusLbl'>{"STATUS: " + row["status"]}</div>");
                    divHtml.Append("</div>");

                    divHtml.Append("</div>");

                    maintenanceRequestData.Text = divHtml.ToString();
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //ASSIGNING EMPLOYEE FOR THE MAINTENANCE REQUEST
        protected void assignBtn_Clicked (object sender,EventArgs e)
        {
            overlay2.Visible = true;
            assignStaffPanel.Visible = true;
        }

        protected void assignEmployeeBtn_Click(object sender, EventArgs e)
        {
            String taskID = taskIdTxtBox.Text.ToString();
            String employeeID = employeeIdTxtBox.Text.ToString();

            assignEmployeeTaskToMaintenanceRequest(taskID, employeeID);

            overlay2.Visible = false;
            assignStaffPanel.Visible = false;

            retrieveMaintenanceRequest();
        }

        protected void cancelAssignEmployeeBtn_Click(object sender, EventArgs e)
        {
            overlay2.Visible = false;
            assignStaffPanel.Visible = false;
        }


        // ASSIGN TASK FOR EMPLOYEE
        private void assignEmployeeTaskToMaintenanceRequest (String taskID,String employeeID)
        {
            try
            {
                String fullName = "";
                String selectEmployeeNameUsingEmployeeId = "SELECT last_name, first_name, middle_name FROM employees WHERE employee_id = @employeeId";
                MySqlCommand selectEmployeeCmd = new MySqlCommand(selectEmployeeNameUsingEmployeeId, dbconn);
                selectEmployeeCmd.Parameters.AddWithValue("@employeeId", employeeID);
                using (MySqlDataReader reader = selectEmployeeCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string lastName = reader["last_name"].ToString();
                        string firstName = reader["first_name"].ToString();
                        string middleName = reader["middle_name"].ToString();

                        fullName = lastName + ", " + firstName + " " + middleName;
                    }
                }

                //ASSIGN EMPLOYEE TO TASK
                String assignEmployeeOnTask = "UPDATE maintenancerequest SET assigned_employee = @assignedEmployee, status = @status WHERE task_id = @taskId";
                MySqlCommand cmd = new MySqlCommand(assignEmployeeOnTask, dbconn);
                cmd.Parameters.AddWithValue("@assignedEmployee", fullName);
                cmd.Parameters.AddWithValue("@status", "In-Progress");
                cmd.Parameters.AddWithValue("@taskId", taskID);
                cmd.ExecuteNonQuery();

                String updateEmployeeStatus = "UPDATE employees SET status = 'Occupied' WHERE employee_id = @employeeId";
                MySqlCommand updateCmd = new MySqlCommand(updateEmployeeStatus, dbconn);
                updateCmd.Parameters.AddWithValue("@employeeId", employeeID);
                updateCmd.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void assignEmployeeTaskToFoodServiceRequest(String orderId, String employeeId)
        {
            try
            {
                String fullName = "";
                String selectEmployeeNameUsingEmployeeId = "SELECT last_name, first_name, middle_name FROM employees WHERE employee_id = @employeeId";
                MySqlCommand selectEmployeeCmd = new MySqlCommand(selectEmployeeNameUsingEmployeeId, dbconn);
                selectEmployeeCmd.Parameters.AddWithValue("@employeeId", employeeId);
                using (MySqlDataReader reader = selectEmployeeCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string lastName = reader["last_name"].ToString();
                        string firstName = reader["first_name"].ToString();
                        string middleName = reader["middle_name"].ToString();

                        fullName = lastName + ", " + firstName + " " + middleName;
                    }
                }

                String assignEmployee = "UPDATE guestfoodservicehistory SET assigned_employee = @assignedEmployee, status = @status WHERE order_id = @orderId";
                MySqlCommand cmd = new MySqlCommand(assignEmployee, dbconn);
                cmd.Parameters.AddWithValue("@assignedEmployee", fullName);
                cmd.Parameters.AddWithValue("@status", "In-Progress");
                cmd.Parameters.AddWithValue("@orderId", orderId);
                cmd.ExecuteNonQuery();

                String updateEmployeeStatus = "UPDATE employees SET status = 'Occupied' WHERE employee_id = @employeeId";
                MySqlCommand updateCmd = new MySqlCommand(updateEmployeeStatus, dbconn);
                updateCmd.Parameters.AddWithValue("@employeeId", employeeId);
                updateCmd.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void assignEmployeeTaskToRoomServiceRequest(String requestId, String employeeId)
        {
            try
            {
                String fullName = "";
                String selectEmployeeNameUsingEmployeeId = "SELECT last_name, first_name, middle_name FROM employees WHERE employee_id = @employeeId";
                MySqlCommand selectEmployeeCmd = new MySqlCommand(selectEmployeeNameUsingEmployeeId, dbconn);
                selectEmployeeCmd.Parameters.AddWithValue("@employeeId", employeeId);
                using(MySqlDataReader reader = selectEmployeeCmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        string lastName = reader["last_name"].ToString();
                        string firstName = reader["first_name"].ToString();
                        string middleName = reader["middle_name"].ToString();

                        fullName = lastName + ", " + firstName + " " + middleName;
                    }
                }

                String assignEmployee = "UPDATE guestroomservicehistory SET assigned_employee = @assignedEmployee, status = @status WHERE request_id = @requestId";
                MySqlCommand cmd = new MySqlCommand(assignEmployee, dbconn);
                cmd.Parameters.AddWithValue("@assignedEmployee", fullName);
                cmd.Parameters.AddWithValue("@status", "In-Progress");
                cmd.Parameters.AddWithValue("@requestId", requestId);
                cmd.ExecuteNonQuery();

                String updateEmployeeStatus = "UPDATE employees SET status = 'Occupied' WHERE employee_id = @employeeId";
                MySqlCommand updateCmd = new MySqlCommand(updateEmployeeStatus, dbconn);
                updateCmd.Parameters.AddWithValue("@employeeId", employeeId);
                updateCmd.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}