using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelFoodAndRoomServiceSystem
{
    public partial class Hotel_RoomService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OpenDB();
        }

        public MySqlConnection dbconn = new MySqlConnection("server=localhost;username=root;password=;database=hotelmanagement");

        private void OpenDB()
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

        private void CloseDB()
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


        protected void dashBoardBtn_Click(object sender, EventArgs e)
        {
            CloseDB();
            Response.Redirect("GuestDashboard.aspx");
        }


        // LAUNDRY AND DRY CLEANING CONTENT INQUIRE BUTTONS
        protected void additionalPillowBtn_Click(object sender, EventArgs e)
        {
            String serviceType = pillowLbl.Text;
            roomServicePrice.Text = "100";
            inquireServiceForm(serviceType);
        }

        protected void additionalBathTowelBtn_Click(object sender, EventArgs e)
        {
            String serviceType = bathTowelLbl.Text;
            roomServicePrice.Text = "100";
            inquireServiceForm(serviceType);
        }

        protected void additionalComforterBtn_Click(object sender, EventArgs e)
        {
            String serviceType = comforterLbl.Text;
            roomServicePrice.Text = "150";
            inquireServiceForm(serviceType);
        }

        private void inquireServiceForm(String serviceType)
        {
            overlay.Visible = true;
            inquireForm.Visible = true;

            roomNumberTxtBox.Text = Session["RoomNumber"].ToString();
            roomServiceTypeTxtBox.Text = serviceType;
            guestNameTxtBox.Text = Session["Username"].ToString();
        }

        private void submitrequestService (String serviceType, String price, String quantity, String totalCharges, String guestName, String roomNumber)
        {
            try
            {
                String submitRequest = "INSERT INTO guestroomservicehistory(request_id, request_date, service_type, status, total_charges, quantity, guest_name, service_price, room_number) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9)";
                MySqlCommand cmd = new MySqlCommand(submitRequest, dbconn);
                cmd.Parameters.AddWithValue("@1", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@2", DateTime.Now);
                cmd.Parameters.AddWithValue("@3", serviceType);
                cmd.Parameters.AddWithValue("@4", "Pending");
                cmd.Parameters.AddWithValue("@5", totalCharges);
                cmd.Parameters.AddWithValue("@6", quantity);
                cmd.Parameters.AddWithValue("@7", guestName);
                cmd.Parameters.AddWithValue("@8", price);
                cmd.Parameters.AddWithValue("@9", roomNumber);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected void requestBtn_Click(object sender, EventArgs e)
        {
            String guestName = guestNameTxtBox.Text;
            String roomNumber = Session["RoomNumber"].ToString();
            String serviceType = roomServiceTypeTxtBox.Text;
            String price = roomServicePrice.Text;
            String quantity = amountTxtBox.Text;
            int total = int.Parse(price) * int.Parse(quantity);
            String totalCharges = total.ToString();

            submitrequestService(serviceType, price, quantity, totalCharges, guestName, roomNumber);

            overlay.Visible = false;
            inquireForm.Visible = false;
        }

        protected void closeFormBtn_Click(object sender, EventArgs e)
        {
            overlay.Visible = false;
            inquireForm.Visible = false;
        }
    }
}