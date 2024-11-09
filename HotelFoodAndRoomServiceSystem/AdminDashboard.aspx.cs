using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
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
                retrieveEmployeesData();
                ShowOnlyDashboardPanel();
                updateTotalStaffCount();
                retrieveStatusCount();
            }

        }

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

        private void updateTotalStaffCount ()
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
        protected void signOutBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("AdminLogin.aspx");
        }

        protected void refreshBtn_Click(object sender, EventArgs e)
        {
            ShowOnlyDashboardPanel();
        }

        protected void dashboardBtn_Click(object sender, EventArgs e)
        {
            ShowOnlyDashboardPanel();
        }
        protected void serviceRequestBtn_Click(object sender, EventArgs e)
        {
            ShowOnlyServiceRequestPanel();
        }

        private void ShowOnlyDashboardPanel()
        {
            // BACKGROUND COLOR OF BUTTONS
            dashboardBtn.Style["background-color"] = "#EAEAEA";
            serviceRequestBtn.Style["background-color"] = "transparent";

            // TEXT COLOR OF BUTTON
            dashboardBtn.Style["color"] = "blue";
            serviceRequestBtn.Style["color"] = "black";

            // DISPLAY PANEL WHEN CLICKING THE BUTTON
            dashboardPanel.Style["display"] = "block";
            serviceRequestPanel.Style["display"] = "none";
            retrieveEmployeesData();
            updateTotalStaffCount();
            retrieveStatusCount();
        }

        private void ShowOnlyServiceRequestPanel()
        {
            // BACKGROUND COLOR OF BUTTONS
            dashboardBtn.Style["background-color"] = "transparent";
            serviceRequestBtn.Style["background-color"] = "#EAEAEA";

            // TEXT COLOR OF BUTTON
            dashboardBtn.Style["color"] = "black";
            serviceRequestBtn.Style["color"] = "blue";

            dashboardPanel.Style["display"] = "none";
            serviceRequestPanel.Style["display"] = "block";
        }


    }
}