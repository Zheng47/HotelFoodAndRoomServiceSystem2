<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuestLoginPage.aspx.cs" Inherits="HotelFoodAndRoomServiceSystem.GuestLoginPage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HotelService - Login</title>
    <meta charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="CssFiles/GuestLogin.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainContainer">

            <div id="hotelLogoContainer">
                <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/nobg.png" id="hotelLogo" />
                <div id="hotelNameAndDescriptionContainer">
                   <asp:Label ID="hotelName" runat="server" Text="H+ HOTEL" /> <br />
                   <asp:Label ID="hotelNameDescription" runat="server" Text="Sign in to your account" />
                </div>
            </div>

            <div id="subContainer">
                <div id="barColor"></div>
                <asp:Label ID="loginLbl" runat="server">Login</asp:Label> <br />
                <div class="subContent">
                    <asp:Label ID="emailLbl" runat="server">Email*</asp:Label>
                    <asp:Label ID="emailErrorLbl" runat="server"></asp:Label> <br />     
                    <asp:TextBox ID="emailTxtBox" runat="server" placeholder="Enter your email"></asp:TextBox> <br />
                    <asp:Label ID="passwordLbl" runat="server">Password*</asp:Label>
                    <asp:Label ID="passwordErrorLbl" runat="server"></asp:Label><br />     
                    <asp:TextBox ID="passwordTxtBox" runat="server" placeholder="minimum 8 characters" TextMode="Password"></asp:TextBox> <br />
                        <div id="subContent2">
                            <asp:Label ID="userNotFoundLbl" runat="server"></asp:Label>
                            <asp:Button ID="adminLoginBtn" runat="server" Text="Login as Admin?" onclick="adminLoginBtn_Click" />
                        </div>
                    <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click" />

                </div>
            </div>

        </div>
    </form>
</body>
</html>
