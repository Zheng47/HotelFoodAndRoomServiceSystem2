<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hotel-FoodService.aspx.cs" Inherits="HotelFoodAndRoomServiceSystem.Hotel_FoodService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel - Food Services</title>
    <link rel="stylesheet" type="text/css" href="CssFiles/FoodService.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <asp:Button ID="dashBoardBtn" CssClass="textFont" runat="server" Text="<<Return to Stay Information" OnClick="dashBoardBtn_Click" />
            <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/nobg.png" id="hotelLogo" />
            <asp:Label ID="hotelName" CssClass="textFont" runat="server" Text="H+ HOTEL" />
            <asp:TextBox ID="searchBar" CssClass="textFont" runat="server" Placeholder="Search item" />
            <asp:Button ID="searchBtn" runat="server" />
            <asp:Button ID="shoppingCartBtn" runat="server" />
        </header>

        <div id="mainContainer">
            <div id="headerContent">
                <asp:Label ID="allMenuLbl" CssClass="textFont" runat="server" Text="ALL MENU" />
                <asp:Label ID="foodAndDrinksLbl" CssClass="textFont" runat="server" Text="FOOD | DRINKS" />
            </div>
            <div id="foodAndBeverageList">
                <asp:Literal ID="foodAndBeverageItems" runat="server"></asp:Literal>
                <div class="foodOrBeverageContainer">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/nobg.png" class="foodImagesLayout" />
                    <div class="foodBeverageContent">
                        <asp:Label ID="foodOrBeverageName" runat="server" CssClass="textFont foodOrBeverageLbl" Text="Americano" />
                        <asp:Label ID="foodOrBeverageCurrencyPrice" runat="server" CssClass="textFont foodOrBeverageLbl" Text="₱" />
                        <asp:Label ID="foodOrBeveragePrice" runat="server" CssClass="textFont foodOrBeverageLbl" Text="150" />
                    </div>
                    <div class="foodBeverageContent2">
                        <asp:Label ID="foodOrBeverageDescription" runat="server" CssClass="textFont" Text="hello world the quick brown fox jumps over the lazy dog" />
                    </div>
                    <asp:Button ID="addToCartBtn" runat="server" CssClass="addToCart" />
                </div>
            </div>
        </div>

        <footer>

        </footer>
    </form>
</body>
</html>
