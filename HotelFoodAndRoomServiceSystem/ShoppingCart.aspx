<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="HotelFoodAndRoomServiceSystem.ShoppingCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel - Shopping Cart</title>
    <link rel="stylesheet" type="text/css" href="CssFiles/ShoppingCart.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <asp:Button ID="foodServiceBtn" CssClass="textFont" runat="server" Text="<<Return to Food Service" OnClick="foodServiceBtn_Click" />
            <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/nobg.png" id="hotelLogo"/>
            <asp:Label id="hotelName" runat="server" CssClass="textFont" Text="H+ HOTEL" />
        </header>

        <div id="mainContainer">
            <div id="mainHeader">
                <asp:Label ID="yourCartLbl" runat="server" CssClass="textFont" Text="YOUR CART" />
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Icons/Navbar/grocery-store.png" id="cartImg"/>
            </div>
            <div id="layout1">
                <div runat="server" id="layout2">
                    <div class="itemLayout">
                        <div class="itemLayout2">
                            <asp:Label ID="productLbl" CssClass="textFont itemLbl" runat="server" Text="Product"/>
                        </div>
                        <div class="itemLayout2">
                            <asp:Label ID="nameLbl" CssClass="textFont itemLbl" runat="server" Text="Name"/>
                        </div>
                        <div class="itemLayout2">
                            <asp:Label ID="priceLbl" CssClass="textFont itemLbl" runat="server" Text="Price"/>
                        </div>
                        <div class="itemLayout2">
                            <asp:Label ID="quantityLbl" CssClass="textFont itemLbl" runat="server" Text="Quantity"/>
                        </div>
                        <div class="itemLayout2">
                            <asp:Label ID="totalPrice" CssClass="textFont itemLbl" runat="server" Text="Total"/>
                        </div>
                    </div>
<%--                    <div runat="server" id="cartTable" class="itemLayout">
                        <div class="itemLayout2">
                            <asp:Label ID="itemProductLbl" CssClass="textFont itemLbl" runat="server" Text="Product" />
                        </div>
                        <div class="itemLayout2">
                            <asp:Label ID="itemNameLbl" CssClass="textFont itemLbl" runat="server" Text="Name"/>
                        </div>
                        <div class="itemLayout2">
                            <asp:Label ID="itemCurrencyPrice" CssClass="textFont itemLbl" runat="server" Text="₱" />
                            <asp:Label ID="itemPrice" CssClass="textFont price itemLbl" runat="server" Text="Price"/>
                        </div>
                        <div class="itemLayout2">
                            <asp:Label ID="itemQuantityLbl" CssClass="textFont itemLbl" runat="server" Text="Quantity"/>
                        </div>
                        <div class="itemLayout2">
                            <asp:Label ID="itemTotalLbl" CssClass="textFont itemLbl" runat="server" Text="Total"/>
                        </div>
                    </div>--%>

                </div>
                <div id="layout3">

                </div>
            </div>
        </div>

        <footer>

        </footer>
    </form>
</body>
</html>
