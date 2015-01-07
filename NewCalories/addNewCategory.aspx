<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addNewCategory.aspx.cs" Inherits="NewCalories.addNewCategory" %>

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
    
        <h1 style="text-align:center"><strong>Add a New Category</strong></h1><strong>What is the Name of the new category?:</strong> 
        <asp:TextBox ID="addNewCategoryTB" runat="server"></asp:TextBox>
        <br /> 
        <asp:Button ID="NewCategoryB" runat="server" OnClick="NewCategoryB_Click" Text="Add New Category!" />
        <asp:Label ID="infoMessage" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Button ID="returnToPreviousPage" runat="server" Text="Return To Previous Page" OnClick="returnToPreviousPage_Click1" />
        <br />
        </div>
    </form>
</body>
</html>
