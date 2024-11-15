using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!IsPostBack)
            {
                if (Session["CartItems"] == null)
                {
                    Session["CartItems"] = new List<CartItem>();
                }
                displayCartItems();
            }
        }

        private void displayCartItems()
        {
            // Retrieve the cart items from Session
            var cartItems = (List<CartItem>)Session["CartItems"];


            itemLayout1.Controls.Clear();
            decimal totalPrice = 0;

            if (cartItems != null && cartItems.Count > 0)
            {
                foreach (var item in cartItems)
                {
                    totalPrice += item.Total;

                    var itemProductLayout = new HtmlGenericControl("div");
                    itemProductLayout.Attributes.Add("class", "itemLayout2");

                    var itemNameLayout = new HtmlGenericControl("div");
                    itemNameLayout.Attributes.Add("class", "itemLayout2");

                    var itemPriceLayout = new HtmlGenericControl("div");
                    itemPriceLayout.Attributes.Add("class", "itemLayout2");

                    var itemQuantityLayout = new HtmlGenericControl("div");
                    itemQuantityLayout.Attributes.Add("class", "itemLayout2");

                    var itemTotalLayout = new HtmlGenericControl("div");
                    itemTotalLayout.Attributes.Add("class", "itemLayout2");

                    var deleteBtnLayout = new HtmlGenericControl("div");
                    deleteBtnLayout.Attributes.Add("class", "btnLayout");


                    // Create img src for the item image
                    Image itemImage = new Image();
                    itemImage.Attributes.Add("class", "itemImage");
                    itemImage.ImageUrl = item.ItemProduct;
                    itemProductLayout.Controls.Add(itemImage);

                    // Create and add Label for Item Name
                    var itemNameLabel = new Label();
                    itemNameLabel.Attributes.Add("class", "textFont itemLbl");
                    itemNameLabel.Text = item.ItemName;
                    itemNameLayout.Controls.Add(itemNameLabel);

                    // Create and add Label for Currency and Price
                    var priceLabel = new Label();
                    priceLabel.Attributes.Add("class", "textFont itemLbl");
                    priceLabel.Text = item.CurrencyPrice + item.Price;
                    itemPriceLayout.Controls.Add(priceLabel);

                    // Create and add Label for Quantity
                    var quantityLabel = new Label();
                    quantityLabel.Attributes.Add("class", "textFont itemLbl");
                    quantityLabel.Text = item.Quantity.ToString();
                    itemQuantityLayout.Controls.Add(quantityLabel);

                    // Create and add Label for Total
                    var totalLabel = new Label();
                    totalLabel.Attributes.Add("class", "textFont itemLbl");
                    totalLabel.Text = "₱" + item.Total;
                    itemTotalLayout.Controls.Add(totalLabel);

                    // Create and add delete button for every item
                    Button deleteBtn = new Button();
                    deleteBtn.Attributes.Add("class", "deleteBtn");
                    deleteBtn.CommandArgument = itemLayout1.ID;
                    deleteBtn.Click += new EventHandler(deleteButton_Click);
                    deleteBtnLayout.Controls.Add(deleteBtn);


                    // Add the new cart item div to the CartContainer
                    itemLayout1.Controls.Add(itemProductLayout);
                    itemLayout1.Controls.Add(itemNameLayout);
                    itemLayout1.Controls.Add(itemPriceLayout);
                    itemLayout1.Controls.Add(itemQuantityLayout);
                    itemLayout1.Controls.Add(itemTotalLayout);
                    itemLayout1.Controls.Add(deleteBtnLayout);
                }

                subTotalLbl.Text = "Subtotal: ₱" + totalPrice.ToString("N2");
            }
            else
            {
                // Display a message if the cart is empty
                var emptyMessage = new Label();
                emptyMessage.Attributes.Add("class", "textFont itemLbl");
                emptyMessage.Text = "Your cart is empty.";
                itemLayout1.Controls.Add(emptyMessage);

                subTotalLbl.Text = "Sub Total: ₱0.00";
            }
        }
        protected void deleteButton_Click(object sender, EventArgs e)
        {
            Button deleteBtn = (Button)sender;
            string itemNameToDelete = deleteBtn.CommandArgument;

            if (Session["CartItems"] != null)
            {
                List<CartItem> cartItems = (List<CartItem>)Session["CartItems"];

                // Find and remove the item from the cart
                CartItem itemToRemove = cartItems.FirstOrDefault(item => item.ItemName == itemNameToDelete);
                if (itemToRemove != null)
                {
                    cartItems.Remove(itemToRemove);
                    // Update the session with the modified cart items
                    Session["CartItems"] = cartItems;

                    decimal newSubtotal = cartItems.Sum(item => item.Total);
                    subTotalLbl.Text = "Subtotal: ₱" + newSubtotal.ToString("N2");

                    // Refresh the cart display
                    displayCartItems();
                }
            }
        }

        protected void foodServiceBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Hotel-FoodService.aspx");
        }

    }
}