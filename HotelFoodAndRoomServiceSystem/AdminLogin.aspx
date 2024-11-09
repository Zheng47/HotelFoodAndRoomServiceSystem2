<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="HotelFoodAndRoomServiceSystem.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HotelMotel - AdminLogin</title>
    <link rel="stylesheet" type="text/css" href="CssFiles/AdminLogin.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header id="header">
            <img src ="CssFiles/Gallery/Food And Room Services Elements/Icons/hotel.png" id="logoImg" />
            <asp:Label ID="logoLbl" runat="server">HOTEL MOTEL</asp:Label>
        </header>
        <div class="mainContainer">
            <div id="loginContent">
                <asp:Label ID="loginLbl" runat="server">Login</asp:Label> <br />
                <asp:Label ID="loginInfo" runat="server">Login to access your admin account.</asp:Label> <br />

                <asp:Label ID="emailLbl" runat="server">Email*</asp:Label> <br />
                <asp:Label ID="emailErrorLbl" runat="server"></asp:Label> <br />   
                <asp:TextBox ID="emailTxtBox" runat="server" placeholder="Enter your email"></asp:TextBox>

                <asp:Label ID="passwordLbl" runat="server">Password*</asp:Label> <br />
                <asp:Label ID="passwordErrorLbl" runat="server"></asp:Label> <br />   
                <asp:TextBox ID="passwordTxtBox" runat="server" placeholder="minimum 8 characters" TextMode="Password"></asp:TextBox>

                <asp:Button ID="guestLogin" runat="server" Text="Sign in as guest?" OnClick="guestLogin_Click" />
                <asp:Label ID="userNotFoundLbl" runat="server"></asp:Label>
                <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click"/>
            </div>
            <div id="hotelLogoContainer">
                <img src ="CssFiles/Gallery/Food And Room Services Elements/Icons/hotel.png" id="logoImg2" /> 
            </div>
        </div>
        <footer id="footer"></footer>
    </form>
</body>
</html>
