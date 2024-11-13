<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="HotelFoodAndRoomServiceSystem.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HotelMotel - AdminLogin</title>
    <link rel="stylesheet" type="text/css" href="CssFiles/AdminLogin.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainContainer">
            <div id="hotelLogoContainer">
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/nobg.png" id="hotelLogo"/>
                <div id="hotelNameAndDescriptionLayout">
                    <asp:Label ID="hotelName" runat="server" Text="H+ HOTEL" />
                    <asp:Label ID="hotelNameDescription" runat="server" Text="Sign in to your account" />
                </div>
            </div>
            <div id="loginContent">
                <div id="barColor" ></div>
                <asp:Label ID="loginLbl" runat="server">Login</asp:Label> <br />
                <asp:Label ID="loginInfo" runat="server">Login to access your admin account.</asp:Label> <br />

                <div id="subContent">
                    <asp:Label ID="emailLbl" runat="server">Email*</asp:Label>
                    <asp:Label ID="emailErrorLbl" runat="server"></asp:Label> <br />   
                    <asp:TextBox ID="emailTxtBox" runat="server" placeholder="Enter your email"></asp:TextBox>
                    <asp:Label ID="passwordLbl" runat="server">Password*</asp:Label>
                    <asp:Label ID="passwordErrorLbl" runat="server"></asp:Label> <br />   
                    <asp:TextBox ID="passwordTxtBox" runat="server" placeholder="minimum 8 characters" TextMode="Password"></asp:TextBox>

                    <div id="subContent2">
                        <asp:Label ID="userNotFoundLbl" runat="server"></asp:Label>
                        <asp:Button ID="guestLogin" runat="server" Text="Sign in as guest?" OnClick="guestLogin_Click" />
                    </div>
                </div>
                <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
