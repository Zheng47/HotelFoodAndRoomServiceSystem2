using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace HotelFoodAndRoomServiceSystem
{
    public partial class HotelServices : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            OpenDB();

            if (Session["Email"] != null)
            {
                userLbl.Text = "Welcome, " + Session["Username"].ToString();
                roomNumLbl.Text = "Room Number: " + Session["RoomNumber"].ToString();
                chkInDateLbl.Text = "Check-in Date: " + Session["CheckInDate"].ToString();
                chkOutDateLbl.Text = "Check-out Date: " + Session["CheckOutDate"].ToString();
                roomTypeLbl.Text = "Room Type: " + Session["RoomType"].ToString();
                occupancyLbl.Text = "Occupancy: " + Session["Occupancy"].ToString();
                amenitiesLbl.Text = "Amenities: " + Session["Amenities"].ToString();
            }
        }

        public MySqlConnection dbconn = new MySqlConnection("server=localhost;username=root;password=;database=hotelmanagement");

        protected void historyBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("GuestHistory.aspx");
        }

        public void OpenDB()
        {
            try
            {
                dbconn.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CloseDB()
        {
            try
            {
                dbconn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            CloseDB();
            Response.Redirect("GuestLoginPage.aspx");
        }
        protected void foodServicesBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Hotel-FoodService.aspx");
        }

        protected void roomServicesBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Hotel-RoomService.aspx");
        }

        protected void mainteReqBtn_Click(object sender, EventArgs e)
        {
            overlay.Visible = true;
            maintenanceRequestForm.Visible = true;
        }

        protected void exitFormBtn_Click(object sender, EventArgs e)
        {
            overlay.Visible = false;
            maintenanceRequestForm.Visible = false;
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            String roomNumber, guestName, issueTitle, issueDescription;
            roomNumber = roomNumberTxtBox.Text.Trim();
            guestName = guestNameTxtBox.Text.Trim();
            issueTitle = issueTitleTxtBox.Text.Trim();
            issueDescription = issueDescriptionTxtBox.Text.Trim();

            submitMaintenanceRequest(roomNumber, guestName, issueTitle, issueDescription);

            overlay.Visible = false;
            maintenanceRequestForm.Visible = false;
        }

        private void submitMaintenanceRequest(String roomNumber, String guestName, String issueTitle, String issueDescription)
        {
            try
            {
                String submitMaintenanceRequest = "INSERT INTO maintenancerequest(room_number, guest_name, issue_title, issue_description) VALUES(@1, @2, @3, @4)";
                MySqlCommand cmd = new MySqlCommand(submitMaintenanceRequest, dbconn);

                cmd.Parameters.AddWithValue("@1", roomNumber);
                cmd.Parameters.AddWithValue("@2", guestName);
                cmd.Parameters.AddWithValue("@3", issueTitle);
                cmd.Parameters.AddWithValue("@4", issueDescription);
               
                int rowInserted = cmd.ExecuteNonQuery();

                if(rowInserted > 0)
                {
                    Console.WriteLine("Data inserted");
                } else
                {
                    Console.WriteLine("Data not inserted");
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

    }
}