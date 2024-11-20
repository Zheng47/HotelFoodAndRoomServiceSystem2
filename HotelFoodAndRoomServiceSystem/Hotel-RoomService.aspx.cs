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

        protected void roomServiceBtn_Click(object sender, EventArgs e)
        {
            dashBoardBtn.Visible = true;
            roomServiceBtn.Visible = false;

            roomServiceSelection.Visible = true;
            laundryAndDryCleaningServicesPanel.Visible = false;
            spaServicePanel.Visible = false;
            //housekeepingPanel.Visible = false;
        }

        protected void laundryDryCleaningServiceBtn_Click(object sender, EventArgs e)
        {
            dashBoardBtn.Visible = false;
            roomServiceBtn.Visible = true;

            roomServiceSelection.Visible = false;
            laundryAndDryCleaningServicesPanel.Visible = true;

        }

        protected void spaServiceBtn_Click(object sender, EventArgs e)
        {
            dashBoardBtn.Visible = false;
            roomServiceBtn.Visible = true;

            roomServiceSelection.Visible = false;
            spaServicePanel.Visible = true;
        }

        protected void houseeKeepingServiceBtn_Click(object sender, EventArgs e)
        {
            dashBoardBtn.Visible = false;
            roomServiceBtn.Visible = true;

            roomServiceSelection.Visible = false;
            //housekeepingPanel.Visible = true;
        }

        // LAUNDRY AND DRY CLEANING CONTENT INQUIRE BUTTONS
        protected void dryCleaningBtn_Click(object sender, EventArgs e)
        {
            String serviceType = dryCleaningLbl.Text;
            roomServicePrice.Text = "50";
            inquireServiceForm(serviceType);
        }

        protected void washBtn_Click(object sender, EventArgs e)
        {
            String serviceType = washLbl.Text;
            roomServicePrice.Text = "50";
            inquireServiceForm(serviceType);
        }

        protected void steamIronBtn_Click(object sender, EventArgs e)
        {
            String serviceType = steamIronLbl.Text;
            roomServicePrice.Text = "50";
            inquireServiceForm(serviceType);
        }

        // SPA SERVICE CONTENT INQUIRE BUTTONS
        protected void spaPedicureBtn_Click(object sender, EventArgs e)
        {
            String serviceType = spaPedicureLbl.Text;
            amountLbl.Text = "Number of Guest*";
            amountTxtBox.Attributes["Placeholder"] = "₱150 per Guest";
            roomServicePrice.Text = "150";
            inquireServiceForm(serviceType);
        }

        protected void spaManicureBtn_Click(object sender, EventArgs e)
        {
            String serviceType = spaManicureLbl.Text;
            amountLbl.Text = "Number of Guest*";
            amountTxtBox.Attributes["Placeholder"] = "₱150 per Guest";
            inquireServiceForm(serviceType);
        }

        protected void deepCleansingBtn_Click(object sender, EventArgs e)
        {
            String serviceType = deepCleansingLbl.Text;
            amountLbl.Text = "Number of Guest*";
            amountTxtBox.Attributes["Placeholder"] = "₱200 per Guest";
            roomServicePrice.Text = "200";
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