<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addFood.aspx.cs" Inherits="NewCalories.addFood" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <style type="text/css">
        h1{background-color: bisque; border:thick dotted; font-size: x-large}
        h4 {background-color: gray ; border:medium dashed #948846}
        body {background-color: burlywood}
    </style>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1 style="text-align:center"><strong>Add Food to Your Record for a Date</strong></h1>
        <strong>Select a food from the dropdown menu:</strong>
        <asp:DropDownList ID="selectFoodDDL" runat="server" DataSourceID="foods" DataTextField="food_name" DataValueField="Id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="foods" runat="server" ConnectionString="<%$ ConnectionStrings:CCDB %>" SelectCommand="ChooseFood" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <asp:HyperLink ID="addNewFoodLink" runat="server" NavigateUrl="~/addANewFoodToDB.aspx">Add a new food to dropdown menu</asp:HyperLink>
        <br />
        <strong>When did you eat your food?</strong><asp:Calendar ID="foodCalendar" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="317px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
            <DayStyle Width="14%" />
            <NextPrevStyle Font-Size="8pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
            <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
            <TodayDayStyle BackColor="#CCCC99" />
        </asp:Calendar>
        <br />
        <br />
        <strong>How many of this food did you eat on this date?</strong>
        <asp:TextBox ID="quantityTB" runat="server" TextMode="Number">1</asp:TextBox>
        <br />
    
    </div>
        <asp:Button ID="submitB" runat="server" OnClick="submitB_Click" Text="Add Your Food!" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="returnUserOptionsB" runat="server" OnClick="returnUserOptionsB_Click" Text="Return To User Options" />
        <br />
        <asp:Label ID="infoMessage" runat="server"></asp:Label>
    </form>
</body>
</html>
