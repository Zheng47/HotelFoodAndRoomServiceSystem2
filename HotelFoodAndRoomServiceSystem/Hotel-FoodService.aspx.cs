using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelFoodAndRoomServiceSystem
{
    public partial class Hotel_FoodService : System.Web.UI.Page
    {
        public MySqlConnection dbconn = new MySqlConnection("server=localhost;username=root;password=;database=hotelmanagement");
        protected void Page_Load(object sender, EventArgs e)
        {

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
                Console.WriteLine($"{e.Message}");
            }
        }
        protected void dashBoardBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("GuestDashboard.aspx");
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string searchItem = searchBar.Text.Trim().ToLower();

            // Filter visibility based on search item using searchBtn
            americanoContainer.Visible = americanoItem.Text.ToLower().Contains(searchItem);
            croissantContainer.Visible = croissantItem.Text.ToLower().Contains(searchItem);
            tapsilogContainer.Visible = tapsilogItem.Text.ToLower().Contains(searchItem);
            beefSteakContainer.Visible = beefSteakItem.Text.ToLower().Contains(searchItem);
            plainRiceContainer.Visible = plainRiceItem.Text.ToLower().Contains(searchItem);
            bottledWaterContainer.Visible = bottledWaterItem.Text.ToLower().Contains(searchItem); 
        }

        protected void searchBar_TextChanged(object sender, EventArgs e)
        {
            string searchItem = searchBar.Text.Trim().ToLower();

            // Filter visibility based on search item using search bar only
            americanoContainer.Visible = americanoItem.Text.ToLower().Contains(searchItem);
            croissantContainer.Visible = croissantItem.Text.ToLower().Contains(searchItem);
            tapsilogContainer.Visible = tapsilogItem.Text.ToLower().Contains(searchItem);
            beefSteakContainer.Visible = beefSteakItem.Text.ToLower().Contains(searchItem);
            plainRiceContainer.Visible = plainRiceItem.Text.ToLower().Contains(searchItem);
            bottledWaterContainer.Visible = bottledWaterItem.Text.ToLower().Contains(searchItem);
        }

        protected void IncreaseQuantity_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox quantityTxtBox = (TextBox)FindControl(btn.CommandArgument);

            if (int.TryParse(quantityTxtBox.Text, out int quantity))
            {
                quantity ++;
                quantityTxtBox.Text = quantity.ToString();
            }
        }

        protected void DecreaseQuantity_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox quantityTxtBox = (TextBox)FindControl(btn.CommandArgument);

            if (int.TryParse(quantityTxtBox.Text, out int quantity) && quantity > 0)
            {
                quantity --;
                quantityTxtBox.Text = quantity.ToString();
            }
        }
    }
}