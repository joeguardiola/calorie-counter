<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userOptions.aspx.cs" Inherits="NewCalories.userOptions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <style type="text/css">
        h1{background-color: bisque; border:thick dotted; font-size: x-large}
        h4 {background-color: gray ; border:medium dashed #948846}
        body {background-color: burlywood}
    </style>
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-weight: 700; z-index: 1; left: 10px; top: 15px; position: absolute; height: 100vh; width: 100%;">
    
        <h1 style="text-align:center">Please Select an Option</h1>
        <h4><span class="auto-style1"><asp:HyperLink ID="logoutLink" runat="server" NavigateUrl="login.aspx" style="font-weight: 700">Logout</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/updateProfile.aspx" style="font-weight: 700">Account Options</asp:HyperLink>
        </span></h4>
        
        Add a New Food to Your Record:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
        <br />
        <br />
        <asp:Button ID="addFoodB" runat="server" OnClick="addFoodB_Click" Text="Add Food" />
        <br />
        <br />
        Select an Option:<asp:RadioButtonList ID="choiceRBL" runat="server" AutoPostBack="True">
            <asp:ListItem Selected="True" Value="1">Caloric Breakdown on a Date</asp:ListItem>
            <asp:ListItem Value="2">Caloric Breakdown Between Two Dates</asp:ListItem>
            <asp:ListItem Value="3">Diet Breakdown for Specific Foods</asp:ListItem>
        </asp:RadioButtonList>
        <span class="auto-style1">
        <asp:DropDownList ID="foodsDDL" runat="server" DataSourceID="foods" DataTextField="food_name" DataValueField="food_name" style="z-index: 1; left: 552px; top: 209px; position: absolute; width: 117px;">
        </asp:DropDownList>
        <br />
        <asp:Button ID="submitB" runat="server" OnClick="submitB_Click" Text="Submit" style="width: 61px" />
        </span>
        <br />
        <asp:Label ID="firstDateLabel" runat="server" Text="Select a date:" style="z-index: 1; left: 352px; top: 209px; position: absolute"></asp:Label>
        <span class="auto-style1">
        <asp:Calendar ID="startDateCalendar" runat="server" style="z-index: 1; left: 350px; top: 243px; position: absolute; height: 188px; width: 259px" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" Width="400px" NextPrevFormat="FullMonth" TitleFormat="Month">
            <DayHeaderStyle BackColor="#CCCCCC" ForeColor="#333333" Height="10pt" Font-Bold="True" Font-Size="7pt" />
            <DayStyle Width="14%" />
            <NextPrevStyle Font-Size="8pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" ForeColor="#333333" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" Width="1%" />
            <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
            <TodayDayStyle BackColor="#CCCC99" />
        </asp:Calendar>
        <asp:Label ID="endDateLabel" runat="server" style="font-weight: 700; z-index: 1; left: 674px; top: 212px; position: absolute; margin-top: 0px;" Text="Select an End Date:"></asp:Label>
        <asp:Label ID="resultsLabel" runat="server"></asp:Label>
        <asp:SqlDataSource ID="foods" runat="server" ConnectionString="<%$ ConnectionStrings:CCDB %>" SelectCommand="ChooseFoodEaten" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="2" Name="users_id" SessionField="users_id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:Calendar ID="endDateCalendar" runat="server" style="z-index: 1; left: 672px; top: 242px; position: absolute; height: 188px; width: 259px" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" Width="400px" NextPrevFormat="FullMonth" TitleFormat="Month">
            <DayHeaderStyle BackColor="#CCCCCC" ForeColor="#333333" Height="10pt" Font-Bold="True" Font-Size="7pt" />
            <DayStyle Width="14%" />
            <NextPrevStyle Font-Size="8pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" ForeColor="#333333" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" Width="1%" />
            <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
            <TodayDayStyle BackColor="#CCCC99" />
        </asp:Calendar>
        <br />
        <br />
        <br />
        <br />
        <br />
        <strong>
        <br />
        </strong>
        <br />
        </span>
    
    </div>
    <p style="font-weight: 700">
        &nbsp;</p>
    </form>
    </body>
</html>
