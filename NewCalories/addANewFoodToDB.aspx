<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addANewFoodToDB.aspx.cs" Inherits="NewCalories.addANewFoodToDB" %>

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
    <div style="height: 100vh; width: 100%;">
    
        <h1 style="text-align:center"><strong>Add a New Food</strong></h1>
        What is the name of the new food?
        <asp:TextBox ID="foodNameTB" runat="server" style="z-index: 1; left: 306px; top: 71px; position: absolute"></asp:TextBox>
        <br />
        <br />
        How many calories per serving of the new food?
        <asp:TextBox ID="caloriesTB" runat="server"></asp:TextBox>
        <br />
        <br />
        What is the category of the new food?
        <asp:DropDownList ID="categoryDDL" runat="server" DataSourceID="category" DataTextField="categoryType" DataValueField="Id" style="z-index: 1; left: 307px; top: 156px; position: absolute; width: 129px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:HyperLink ID="addNewCategory" runat="server" NavigateUrl="~/addNewCategory.aspx">Add a New Category to Drop Down List</asp:HyperLink>
        <br />
        <br />
        <asp:Button ID="addNewFoodB" runat="server" OnClick="addNewFoodB_Click" Text="Add Your New Food!" />
        <asp:Label ID="infoMessage" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="returnToPreviousPage" runat="server" OnClick="returnToPreviousPage_Click" Text="Return to Previous Page" />
        <br />
    
    </div>
        <asp:SqlDataSource ID="category" runat="server" ConnectionString="<%$ ConnectionStrings:CCDB %>" SelectCommand="ChooseCategory" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </form>
</body>
</html>
