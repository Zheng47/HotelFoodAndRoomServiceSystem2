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

        //private void retrieveFoodAndBeveragesItem()
        //{
        //    try
        //    {
        //        String retrieveFoodAndBeverages = "SELECT COUNT(*) item_name, item_price, item_description, item_pricecurrency FROM foodandbeverageinventory";
        //        MySqlCommand cmd = new MySqlCommand(retrieveFoodAndBeverages, dbconn);
        //        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
        //        DataTable dataTable = new DataTable();
        //        dataAdapter.Fill(dataTable);

        //        StringBuilder divHtml = new StringBuilder();

        //        foreach (DataRow row in dataTable.Rows)
        //        {
        //            divHtml.Append("<div class='foodOrBeverageContainer'> ");
        //            divHtml.Append("<img src='CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/nobg.png' class='foodImagesLayout'/> ");

        //            divHtml.Append("<div class='foodBeverageContent'>");
        //            divHtml.Append($"<asp:Label ID='foodOrBeverageName' runat='server' CssClass='textFont foodOrBeverageLbl' Text='{row["item_name"]}'/>");
        //            divHtml.Append($"<asp:Label ID='foodOrBeverageCurrencyPrice' runat='server' CssClass='textFont foodOrBeverageLbl' Text='{row["item_pricecurrency"]}'/>");
        //            divHtml.Append($"<asp:Label ID='foodOrBeveragePrice' runat='server' CssClass='textFont foodOrBeverageLbl' Text='{row["item_price"]}'/>");
        //            divHtml.Append("</div>");

        //            divHtml.Append("<div class='foodBeverageContent2'>");
        //            divHtml.Append($"<asp:Label ID='foodOrBeverageDescription' runat='server' CssClass='textFont' Text='{row["item_description"]}'/> ");
        //            divHtml.Append("</div");

        //            divHtml.Append("<asp:Button ID='addToCartBtn' runat='server' CssClass='addToCart' />");
        //            divHtml.Append("</div> ");

        //            foodAndBeverageItems.Text= divHtml.ToString();
        //        }

        //    }
        //    catch (MySqlException e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}

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
    }
}