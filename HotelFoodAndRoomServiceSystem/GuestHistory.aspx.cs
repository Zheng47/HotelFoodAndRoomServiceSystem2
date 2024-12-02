using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelFoodAndRoomServiceSystem
{
    public partial class GuestHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] != null)
            {
                OpenDB();
                String guestName = Session["Username"].ToString();
                retrieveGuestRoomServiceHistory(guestName);

                userLbl.Text = "Welcome, " + Session["Username"].ToString();
            }

        }

        public MySqlConnection dbconn = new MySqlConnection("server=localhost;username=root;password=;database=hotelmanagement");

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("GuestDashboard.aspx");
        }

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

        protected void roomServiceHistoryBtn_Click(object sender, EventArgs e)
        {
            roomServiceHistoryBtn.Style["border-bottom"] = "2px solid #101450";

            roomServiceHistoryView.Style["display"] = "block";

            String guestName = Session["Username"].ToString();
            retrieveGuestRoomServiceHistory(guestName);
        }

        private void retrieveGuestRoomServiceHistory (String guestName)
        {
            try
            {
                String retrieveGuestRoomServiceHistory = "SELECT * FROM guestroomservicehistory where guest_name = @1";
                MySqlCommand cmd = new MySqlCommand(retrieveGuestRoomServiceHistory, dbconn);
                cmd.Parameters.AddWithValue("@1", guestName);

                MySqlDataAdapter dataAdapater = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapater.Fill(dataTable);

                StringBuilder divHtml = new StringBuilder();

                // Generate rows for each employee
                foreach (DataRow row in dataTable.Rows)
                {
                    divHtml.Append("<div class='historyTable'>");
                    divHtml.Append($"<div class='textFont requestIdColumn'> {row["request_id"]} </div>");

                    DateTime requestDate = Convert.ToDateTime(row["request_date"]);
                    divHtml.Append($"<div class='textFont requestDateTimeColumn'> {requestDate:yyyy-MM-dd HH:mm:ss} </div>");

                    divHtml.Append($"<div class='textFont serviceTypeColumn'> {row["service_type"] + " " + "₱" + row["service_price"] + " " + "(" + row["quantity"] + ")"} </div>");

                    divHtml.Append($"<div class='textFont statusColumn'> {row["status"]} </div>");

                    divHtml.Append($"<div class='textFont chargesColumn'> {"₱" + row["total_charges"]} </div>");
                    divHtml.Append("</div>");
                }

                roomServiceHistory.Text = divHtml.ToString(); // Set HTML to Literal control

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected void roomServiceRefreshBtn_Click(object sender, EventArgs e)
        {
            roomServiceRefreshDeleteLayout.Visible = true;

            String guestName = Session["Username"].ToString();
            retrieveGuestRoomServiceHistory(guestName);
        }
    }
}