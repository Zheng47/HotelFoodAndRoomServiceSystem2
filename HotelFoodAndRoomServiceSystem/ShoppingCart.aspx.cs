using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static HotelFoodAndRoomServiceSystem.Hotel_FoodService;

namespace HotelFoodAndRoomServiceSystem
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve the cart items from Session
            var cartItems = (List<CartItem>)Session["CartItems"];

            if (cartItems != null && cartItems.Count > 0)
            {
                foreach (var item in cartItems)
                {
                    // Create a new div for each cart item
                    var cartItemDiv = new HtmlGenericControl("div");
                    cartItemDiv.Attributes.Add("class", "itemLayout");

                    var itemNameLayout = new HtmlGenericControl("div");
                    itemNameLayout.Attributes.Add("class", "itemLayout2");

                    var itemPriceLayout = new HtmlGenericControl ("div");
                    itemPriceLayout.Attributes.Add("class", "itemLayout2");

                    var itemQuantityLayout = new HtmlGenericControl("div");
                    itemQuantityLayout.Attributes.Add("class", "itemLayout2");

                    var itemTotalLayout = new HtmlGenericControl("div");
                    itemTotalLayout.Attributes.Add("class", "itemLayout2");


                    cartItemDiv.Controls.Add(itemNameLayout);
                    cartItemDiv.Controls.Add(itemPriceLayout);
                    cartItemDiv.Controls.Add(itemQuantityLayout);
                    cartItemDiv.Controls.Add(itemTotalLayout);


                    // Create and add Label for Item Name
                    var itemNameLabel = new Label();
                    itemNameLabel.Attributes.Add("class", "textFont itemLbl");
                    itemNameLabel.Text = $"{item.ItemName}";
                    itemNameLayout.Controls.Add(itemNameLabel);

                    

                    // Create and add Label for Currency and Price
                    var priceLabel = new Label();
                    priceLabel.Attributes.Add("class", "textFont itemLbl");
                    priceLabel.Text = $"{item.CurrencyPrice} {item.Price}";
                    itemPriceLayout.Controls.Add(priceLabel);

                    // Create and add Label for Quantity
                    var quantityLabel = new Label();
                    quantityLabel.Attributes.Add("class", "textFont itemLbl");
                    quantityLabel.Text = $"{item.Quantity}";
                    itemQuantityLayout.Controls.Add(quantityLabel);

                    // Create and add Label for Total
                    var totalLabel = new Label();
                    totalLabel.Attributes.Add("class", "textFont itemLbl");
                    totalLabel.Text = $"₱{item.Total}";
                    itemTotalLayout.Controls.Add(totalLabel);

                    // Add the new cart item div to the CartContainer
                    layout2.Controls.Add(cartItemDiv);

                }
            }
            else
            {
                // Display a message if the cart is empty
                var emptyMessage = new Label();
                emptyMessage.Text = "Your cart is empty.";
                layout2.Controls.Add(emptyMessage);
            }
        }

        protected void foodServiceBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Hotel-FoodService.aspx");
        }
        
    }
}