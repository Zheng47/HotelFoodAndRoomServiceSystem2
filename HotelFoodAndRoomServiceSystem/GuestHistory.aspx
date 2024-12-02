<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuestHistory.aspx.cs" Inherits="HotelFoodAndRoomServiceSystem.GuestHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel - Guest History</title>
    <link rel="stylesheet" type="text/css" href="CssFiles/GuestHistory.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <img src="CssFiles/Gallery/Food%20And%20Room%20Services%20Elements/Images/nobg.png" id="hotelLogo" />
            <asp:Label ID="hotelName" CssClass="textFont" runat="server" Text="H+ HOTEL" />
            <div class="headBtnLayout">
                <asp:Button ID="homeBtn" CssClass="headBtn" runat="server" Text="Home" OnClick="homeBtn_Click" />
                <asp:Button ID="historyBtn" CssClass="headBtn" runat="server" Text="History" />
            </div>
            <asp:Label ID="userLbl" runat="server">Welcome, GUEST</asp:Label>
        </div>

        <div id="mainContainer">
            <div id="serviceHistoryLayout">
                <asp:Label ID="serviceHistoryLbl" CssClass="textFont" runat="server" Text="Service History" /> <br />
                <div id="barColor"></div>
            </div>

            <div id="historyContainer">
                <div id="serviceBtnLayout">
                    <asp:Button ID="roomServiceHistoryBtn" CssClass="textFont serviceHistoryBtn" runat="server" Text="Room Service" OnClick="roomServiceHistoryBtn_Click" />
                </div>

                <div id="roomServiceHistoryView" runat="server" class="tableContainer" style="display:block">
                    <div class="historyTable">
                        <div class="textFont requestIdColumn">REQUEST ID</div>
                        <div class="textFont requestDateTimeColumn">REQUEST DATE AND TIME</div>
                        <div class="textFont serviceTypeColumn">SERVICE TYPE</div>
                        <div class="textFont statusColumn">STATUS</div>
                        <div class="textFont chargesColumn">CHARGES</div>
                    </div>
                    <asp:Literal ID="roomServiceHistory" runat="server" />
                </div>

                <asp:Panel id="roomServiceRefreshDeleteLayout" CssClass="refreshAndDeleteBtnLayout" runat="server" Visible="true" >
                    <asp:Button ID="roomServiceRefreshBtn" CssClass="refreshBtn" runat="server" OnClick="roomServiceRefreshBtn_Click" />
                </asp:Panel>
            </div>

        </div>

    </form>
</body>
</html>
