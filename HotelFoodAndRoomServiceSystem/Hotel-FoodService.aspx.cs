using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HotelFoodAndRoomServiceSystem
{
    public partial class Hotel_FoodService : System.Web.UI.Page
    {
        public MySqlConnection dbconn = new MySqlConnection("server=localhost;username=root;password=;database=hotelmanagement");
        protected void Page_Load(object sender, EventArgs e)
        {
            OpenDB();
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
                quantity++;
                quantityTxtBox.Text = quantity.ToString();
            }
        }

        protected void DecreaseQuantity_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox quantityTxtBox = (TextBox)FindControl(btn.CommandArgument);

            if (int.TryParse(quantityTxtBox.Text, out int quantity) && quantity > 0)
            {
                quantity--;
                quantityTxtBox.Text = quantity.ToString();
            }
        }

        protected void americanoOrderBtn_Click(object sender, EventArgs e)
        {
            itemImageLayout.Attributes["src"] = "CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/americano.jpg";
            itemNameLbl.Text = americanoItem.Text;
            itemPriceLbl.Text = americanoPrice.Text;
            itemQuantityLbl.Text = americanoQuantity.Text;
            int totalPrice = Convert.ToInt32(itemPriceLbl.Text) * Convert.ToInt32(itemQuantityLbl.Text) ;
            totalPriceLbl.Text = totalPrice.ToString();

            overlay.Visible = true;
            orderedItemPanel.Visible = true;
        }

        protected void croissantOrderBtn_Click(object sender, EventArgs e)
        {
            itemImageLayout.Attributes["src"] = "CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/croissant.jpg";
            itemNameLbl.Text = croissantItem.Text;
            itemPriceLbl.Text = croissantPrice.Text;
            itemQuantityLbl.Text = croissantQuantity.Text;
            int totalPrice = Convert.ToInt32(itemPriceLbl.Text) * Convert.ToInt32(itemQuantityLbl.Text);
            totalPriceLbl.Text = totalPrice.ToString();

            overlay.Visible = true;
            orderedItemPanel.Visible = true;
        }

        protected void tapsilogOrderBtn_Click(object sender, EventArgs e)
        {
            itemImageLayout.Attributes["src"] = "CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/Tapsilog.jpg";
            itemNameLbl.Text = tapsilogItem.Text;
            itemPriceLbl.Text = tapsilogPrice.Text;
            itemQuantityLbl.Text = tapsilogQuantity.Text;
            int totalPrice = Convert.ToInt32(itemPriceLbl.Text) * Convert.ToInt32(itemQuantityLbl.Text);
            totalPriceLbl.Text = totalPrice.ToString();

            overlay.Visible = true;
            orderedItemPanel.Visible = true;
        }

        protected void beefSteakOrderBtn_Click(object sender, EventArgs e)
        {
            itemImageLayout.Attributes["src"] = "CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/beefsteak.jpg";
            itemNameLbl.Text = beefSteakItem.Text;
            itemPriceLbl.Text = beefSteakPrice.Text;
            itemQuantityLbl.Text = beefSteakQuantity.Text;
            int totalPrice = Convert.ToInt32(itemPriceLbl.Text) * Convert.ToInt32(itemQuantityLbl.Text);
            totalPriceLbl.Text = totalPrice.ToString();

            overlay.Visible = true;
            orderedItemPanel.Visible = true;
        }

        protected void plainRiceOrderBtn_Click(object sender, EventArgs e)
        {
            itemImageLayout.Attributes["src"] = "CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/plainrice.jpg";
            itemNameLbl.Text = plainRiceItem.Text;
            itemPriceLbl.Text = plainRicePrice.Text;
            itemQuantityLbl.Text = plainRiceQuantity.Text;
            int totalPrice = Convert.ToInt32(itemPriceLbl.Text) * Convert.ToInt32(itemQuantityLbl.Text);
            totalPriceLbl.Text = totalPrice.ToString();

            overlay.Visible = true;
            orderedItemPanel.Visible = true;
        }

        protected void bottledWaterOrderBtn_Click(object sender, EventArgs e)
        {
            itemImageLayout.Attributes["src"] = "CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/bottledwater.jpg";
            itemNameLbl.Text = bottledWaterItem.Text;
            itemPriceLbl.Text = bottledWaterPrice.Text;
            itemQuantityLbl.Text = bottledWaterQuantity.Text;
            int totalPrice = Convert.ToInt32(itemPriceLbl.Text) * Convert.ToInt32(itemQuantityLbl.Text);
            totalPriceLbl.Text = totalPrice.ToString();

            overlay.Visible = true;
            orderedItemPanel.Visible = true;
        }


        protected void orderBtn_Click(object sender, EventArgs e)
        {
            String itemName = itemNameLbl.Text;
            String itemPrice = itemPriceLbl.Text;
            String quantity = itemQuantityLbl.Text;
            String totalPrice = totalPriceLbl.Text;
            String guestName = Session["Username"].ToString();

            insertOrderToDb(itemName, itemPrice, quantity, totalPrice, guestName);

            overlay.Visible = false;
            orderedItemPanel.Visible = false;
        }

        private void insertOrderToDb(String itemName, String itemPrice, String quantity, String totalPrice, String guestName)
        {
            try
            {
                String insertOrder = "INSERT INTO guestfoodservicehistory(order_id, order_date, item_ordered, status, quantity, total_price, item_price, guest_name) VALUES(@1, @2, @3, @4, @5, @6, @7, @8)";
                MySqlCommand cmd = new MySqlCommand(insertOrder, dbconn);

                cmd.Parameters.AddWithValue("@1", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@2", DateTime.Now);
                cmd.Parameters.AddWithValue("@3", itemName);
                cmd.Parameters.AddWithValue("@4", "Pending");
                cmd.Parameters.AddWithValue("@5", quantity);
                cmd.Parameters.AddWithValue("@6", totalPrice);  
                cmd.Parameters.AddWithValue("@7", itemPrice);     
                cmd.Parameters.AddWithValue("@8", guestName);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            overlay.Visible = false;
            orderedItemPanel.Visible = false;
        }
    }
}