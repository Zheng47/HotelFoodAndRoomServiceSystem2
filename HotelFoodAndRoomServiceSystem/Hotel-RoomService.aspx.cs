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

        }

        protected void dashBoardBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("GuestDashboard.aspx");
        }

        protected void roomServiceBtn_Click(object sender, EventArgs e)
        {
            dashBoardBtn.Visible = true;
            roomServiceBtn.Visible = false;

            roomServiceSelection.Visible = true;
            laundryAndDryCleaningServicesPanel.Visible = false;
            spaServicePanel.Visible = false;
            housekeepingPanel.Visible = false;
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
            housekeepingPanel.Visible = true;
        }

        // LAUNDRY AND DRY CLEANING CONTENT INQUIRE BUTTONS
        protected void dryCleaningBtn_Click(object sender, EventArgs e)
        {
            overlay.Visible = true;
            inquireForm.Visible = true;
        }
    }
}