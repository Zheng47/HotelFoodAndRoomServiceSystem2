using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelFoodAndRoomServiceSystem
{
    public partial class HotelServices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
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

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("GuestLoginPage.aspx");
        }

        protected void roomServicesBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Hotel-RoomService.aspx");
        }
    }
}