<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hotel-FoodService.aspx.cs" MaintainScrollPositionOnPostBack="true" Inherits="HotelFoodAndRoomServiceSystem.Hotel_FoodService" %>

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
            <asp:TextBox ID="searchBar" AutoPostBack="true" OnTextChanged="searchBar_TextChanged" CssClass="textFont" runat="server" Placeholder="Search item" />
            <asp:Button ID="searchBtn" runat="server" OnClick="searchBtn_Click" />
        </header>

        <div id="foodBeverageContainer">
            <div id="headerContent">
                <asp:Label ID="allMenuLbl" CssClass="textFont" runat="server" Text="ALL MENU" />
                <asp:Label ID="foodAndDrinksLbl" CssClass="textFont" runat="server" Text="FOOD | DRINKS" />
            </div>


            <div id="foodAndBeverageList"> 

                <%-- Americano Item --%>
                <div runat="server" id="americanoContainer" class="foodOrBeverageContainer">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/americano.jpg" class="foodImagesLayout" />
                    <div class="foodBeverageContent">
                        <asp:Label ID="americanoItem" runat="server" CssClass="textFont foodOrBeverageLbl" Text="Americano" />
                        <div class="priceContainer">
                            <asp:Label ID="americanoCurrencyPrice" runat="server" CssClass="textFont currencyPrice foodOrBeverageLbl" Text="₱" />
                            <asp:Label ID="americanoPrice" runat="server" CssClass="textFont price foodOrBeverageLbl" Text="150" />
                        </div>
                    </div>
                    <div class="foodBeverageContent2">
                        <asp:Label ID="americanoDescription" runat="server" CssClass="textFont description" Text="A shot of expresso with a deep-tan crema that's smooth and robust and perfectly preserved for your enjoyment." />
                    </div>
                    <div class="btnContainer">
                        <asp:Button ID="americanoOrderBtn" runat="server" CssClass="addToCart" OnClick="americanoOrderBtn_Click" />
                        <div class="btnContainer2">
                            <asp:Button ID="americanoDecrease" runat="server" CssClass="btnDecrease textFont" OnClick="DecreaseQuantity_Click" Text="-"  CommandArgument="americanoQuantity" CausesValidation="false"/>
                            <asp:TextBox ID="americanoQuantity" CssClass="quantityTxtBox textFont" runat="server" ReadOnly="true" Text="0" />
                            <asp:Button ID="americanoIncrease" runat="server" CssClass="btnIncrease textFont" OnClick="IncreaseQuantity_Click" Text="+" CommandArgument="americanoQuantity" CausesValidation="false" />
                        </div>
                    </div>
                </div>

                <%-- Croissant Item --%>
                <div runat="server" id="croissantContainer" class="foodOrBeverageContainer">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/croissant.jpg" class="foodImagesLayout" />
                    <div class="foodBeverageContent">
                        <asp:Label ID="croissantItem" runat="server" CssClass="textFont foodOrBeverageLbl" Text="Croissant" />
                        <div class="priceContainer">
                            <asp:Label ID="croissantCurrencyPrice" runat="server" CssClass="textFont currencyPrice foodOrBeverageLbl" Text="₱" />
                            <asp:Label ID="croissantPrice" runat="server" CssClass="textFont price foodOrBeverageLbl" Text="95" />
                        </div>
                    </div>
                    <div class="foodBeverageContent2">
                        <asp:Label ID="croissantDescription" runat="server" CssClass="textFont description" Text="A flaky croissant filled with smoky ham and creamy cheese, lightly brushed with egg for a golden finish." />
                    </div>
                    <div class="btnContainer">
                        <asp:Button ID="croissantOrderBtn" runat="server" CssClass="addToCart" OnClick="croissantOrderBtn_Click" />
                        <div class="btnContainer2">
                            <asp:Button ID="croissantDecrease" runat="server" CssClass="btnDecrease textFont" OnClick="DecreaseQuantity_Click" Text="-" CommandArgument="croissantQuantity"  CausesValidation="false"/>
                            <asp:TextBox ID="croissantQuantity" CssClass="quantityTxtBox textFont" runat="server" ReadOnly="true" Text="0" />
                            <asp:Button ID="croissantIncrease" runat="server" CssClass="btnIncrease textFont" OnClick="IncreaseQuantity_Click" Text="+" CommandArgument="croissantQuantity" CausesValidation="false" />
                        </div>
                    </div>
                </div>

                <%-- Tapsilog Item --%>
                <div runat="server" id="tapsilogContainer" class="foodOrBeverageContainer">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/Tapsilog.jpg" class="foodImagesLayout" />
                    <div class="foodBeverageContent">
                        <asp:Label ID="tapsilogItem" runat="server" CssClass="textFont foodOrBeverageLbl" Text="Tapsilog" />
                        <div class="priceContainer">
                            <asp:Label ID="tapsilogCurrencyPrice" runat="server" CssClass="textFont currencyPrice foodOrBeverageLbl" Text="₱" />
                            <asp:Label ID="tapsilogPrice" runat="server" CssClass="textFont price foodOrBeverageLbl" Text="85" />
                        </div>
                    </div>
                    <div class="foodBeverageContent2">
                        <asp:Label ID="tapsilogDescription" runat="server" CssClass="textFont description" Text="A breakfast meal which consists of sliced beef jerky, known as tapa, a heap of garlic rice, and a fried egg." />
                    </div>
                    <div class="btnContainer">
                        <asp:Button ID="tapsilogOrderBtn" runat="server" CssClass="addToCart" OnClick="tapsilogOrderBtn_Click" />
                        <div class="btnContainer2">
                            <asp:Button ID="tapsilogDecrease" runat="server" CssClass="btnDecrease textFont" OnClick="DecreaseQuantity_Click" Text="-" CommandArgument="tapsilogQuantity"  CausesValidation="false"/>
                            <asp:TextBox ID="tapsilogQuantity" CssClass="quantityTxtBox textFont" runat="server" ReadOnly="true" Text="0" />
                            <asp:Button ID="tapsilogIncrease" runat="server" CssClass="btnIncrease textFont" OnClick="IncreaseQuantity_Click" Text="+" CommandArgument="tapsilogQuantity" CausesValidation="false" />
                        </div>
                    </div>
                </div>

                <%-- Beef Steak Item --%>
                <div runat="server" id="beefSteakContainer" class="foodOrBeverageContainer">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/beefsteak.jpg" class="foodImagesLayout" />
                    <div class="foodBeverageContent">
                        <asp:Label ID="beefSteakItem" runat="server" CssClass="textFont foodOrBeverageLbl" Text="Beef Steak" />
                        <div class="priceContainer">
                            <asp:Label ID="beefSteakCurrencyPrice" runat="server" CssClass="textFont currencyPrice foodOrBeverageLbl" Text="₱" />
                            <asp:Label ID="beefSteakPrice" runat="server" CssClass="textFont price foodOrBeverageLbl" Text="120" />
                        </div>
                    </div>
                    <div class="foodBeverageContent2">
                        <asp:Label ID="beefSteakDescription" runat="server" CssClass="textFont description" Text="It is comprised of thin slices of beef and a generous amount of onions. These are stewed in a soy sauce and lemon juice mixture until the beef gets very tender. It is best enjoyed with warm rice." />
                    </div>
                    <div class="btnContainer">
                        <asp:Button ID="beefSteakOrderBtn" runat="server" CssClass="addToCart" OnClick="beefSteakOrderBtn_Click" />
                        <div class="btnContainer2">
                            <asp:Button ID="beefSteakDecrease" runat="server" CssClass="btnDecrease textFont" OnClick="DecreaseQuantity_Click" Text="-" CommandArgument="beefSteakQuantity" CausesValidation="false" />
                            <asp:TextBox ID="beefSteakQuantity" CssClass="quantityTxtBox textFont" runat="server" ReadOnly="true" Text="0" />
                            <asp:Button ID="beefSteakIncrease" runat="server" CssClass="btnIncrease textFont" OnClick="IncreaseQuantity_Click" Text="+" CommandArgument="beefSteakQuantity" CausesValidation="false" />
                        </div>
                    </div>
                </div>

                <%-- Plain Rice Item --%>
                <div runat="server" id="plainRiceContainer" class="foodOrBeverageContainer">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/plainrice.jpg" class="foodImagesLayout" />
                    <div class="foodBeverageContent">
                        <asp:Label ID="plainRiceItem" runat="server" CssClass="textFont foodOrBeverageLbl" Text="Plain Rice" />
                        <div class="priceContainer">
                            <asp:Label ID="plainRiceCurrencyPrice" runat="server" CssClass="textFont currencyPrice foodOrBeverageLbl" Text="₱" />
                            <asp:Label ID="plainRicePrice" runat="server" CssClass="textFont price foodOrBeverageLbl" Text="35" />
                        </div>
                    </div>
                    <div class="foodBeverageContent2">
                        <asp:Label ID="plainRiceDescription" runat="server" CssClass="textFont description" Text="A hot plain rice that is perfect for your selected dish." />
                    </div>
                    <div class="btnContainer">
                        <asp:Button ID="plainRiceOrderBtn" runat="server" CssClass="addToCart" OnClick="plainRiceOrderBtn_Click" />
                        <div class="btnContainer2">
                            <asp:Button ID="plainRiceDecrease" runat="server" CssClass="btnDecrease textFont" OnClick="DecreaseQuantity_Click" Text="-" CommandArgument="plainRiceQuantity" CausesValidation="false" />
                            <asp:TextBox ID="plainRiceQuantity" CssClass="quantityTxtBox textFont" runat="server" ReadOnly="true" Text="0" />
                            <asp:Button ID="plainRiceIncrease" runat="server" CssClass="btnIncrease textFont" OnClick="IncreaseQuantity_Click" Text="+" CommandArgument="plainRiceQuantity" CausesValidation="false" />
                        </div>
                    </div>
                </div>

                <%-- Bottled Water Item --%>
                <div  runat="server" id="bottledWaterContainer" class="foodOrBeverageContainer">
                    <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/bottledwater.jpg" class="foodImagesLayout" />
                    <div class="foodBeverageContent">
                        <asp:Label ID="bottledWaterItem" runat="server" CssClass="textFont foodOrBeverageLbl" Text="Bottled Water" />
                        <div class="priceContainer">
                            <asp:Label ID="bottledWaterCurrencyPrice" runat="server" CssClass="textFont currencyPrice foodOrBeverageLbl" Text="₱" />
                            <asp:Label ID="bottledWaterPrice" runat="server" CssClass="textFont price foodOrBeverageLbl" Text="25" />
                        </div>
                    </div>
                    <div class="foodBeverageContent2">
                        <asp:Label ID="bottledWaterDescription" runat="server" CssClass="textFont description" Text="Quench your thirst with this 500ml bottled water." />
                    </div>
                    <div class="btnContainer">
                        <asp:Button ID="bottledWaterOrderBtn" runat="server" CssClass="addToCart" OnClick="bottledWaterOrderBtn_Click" />
                        <div class="btnContainer2">
                            <asp:Button ID="bottledWaterDecrease" runat="server" CssClass="btnDecrease textFont" OnClick="DecreaseQuantity_Click" Text="-" CommandArgument="bottledWaterQuantity" CausesValidation="false"/>
                            <asp:TextBox ID="bottledWaterQuantity" CssClass="quantityTxtBox textFont" runat="server" ReadOnly="true" Text="0" />
                            <asp:Button ID="bottledWaterIncrease" runat="server" CssClass="btnIncrease textFont" OnClick="IncreaseQuantity_Click" Text="+" CommandArgument="bottledWaterQuantity" CausesValidation="false" />
                        </div>
                    </div>
                </div>
                <asp:Panel ID="orderedItemPanel" runat="server" Visible="false">
                    <div id="orderItemPanelLayout">
                        <asp:Label ID="orderThisItemLbl" CssClass="textFont" runat="server" Text="ORDER THIS ITEM?" />
                        <div id="itemInfoLayout">
                            <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/americano.jpg" runat="server" id="itemImageLayout"/>
                            <label class="textFont itemDetails">Product Name: <asp:Label ID="itemNameLbl" CssClass="mainItemInfo" runat="server" Text="Test" /></label>
                            <label class="textFont itemDetails">Price: ₱<asp:Label ID="itemPriceLbl" CssClass="mainItemInfo"  runat="server" Text="Test" /></label>
                            <label class="textFont itemDetails">Quantity: (<asp:Label ID="itemQuantityLbl" CssClass="mainItemInfo"  runat="server" Text="Test" />)</label>
                            <label class="textFont itemDetails">Total Price: ₱<asp:Label ID="totalPriceLbl" CssClass="mainItemInfo"  runat="server" Text="Test" /></label>
                        </div>
                        <div id="orderItemBtnsLayout" class="textFont">
                            <asp:Button ID="orderBtn" runat="server" Text="ORDER" OnClick="orderBtn_Click" />
                            <asp:Button ID="cancelBtn" runat="server" Text="CANCEL" OnClick="cancelBtn_Click" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="confirmedOrderPanel" CssClass="textFont" runat="server" Visible="false">
                    <asp:Label ID="orderRequestedLbl" runat="server" Text=" ORDER HAS BEEN REQUESTED!" />
                    <asp:Button ID="closeBtn" runat="server" Text="CLOSE" OnClick="closeBtn_Click" />
                </asp:Panel>
            </div> 
        </div>
        
        <%-- DIM AND LOCK THE BACKGROUND TO POPUP PANEL --%>
        <asp:Panel ID="overlay" runat="server" CssClass="overlay" Visible="false" />

        <asp:Panel ID="overlay2" runat="server" CssClass="overlay2" Visible="false" />

        <footer>
            <asp:Label ID="hotelNameFooter" CssClass="textFont" runat="server" Text="H+ HOTEL" />
        </footer>
    </form>
</body>
</html>
