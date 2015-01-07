<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrationPage.aspx.cs" Inherits="NewCalories.registrationPage" %>

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
        <h1 style="text-align:center">Enter Information For New User</h1>
        First Name:
        <asp:TextBox ID="firstNameTB" runat="server"></asp:TextBox>
        <br />
        <br />
        Last Name:
        <asp:TextBox ID="lastNameTB" runat="server" style="height: 22px"></asp:TextBox>
        <br />
        <br />
        Calorie Limit:
        <asp:TextBox ID="CalorieLimitTB" runat="server"></asp:TextBox>
        <br />
        <br />
        User Name: <asp:TextBox ID="userNameTB" runat="server"></asp:TextBox>
        <br />
        <br />
        Password:
        <asp:TextBox ID="passwordTB" runat="server" TextMode="Password"></asp:TextBox>
    
        <br />
        <br />
        <asp:Button ID="addNewUserB" runat="server" OnClick="addNewUserB_Click" Text="Add New User" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="returnToLoginB" runat="server" OnClick="returnToLoginB_Click" Text="Return to Login Page" />
        <br />
        <asp:Label ID="infoMessage" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
