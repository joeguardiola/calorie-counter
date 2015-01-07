<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="NewCalories.login" %>

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
    
        <h1 style="text-align:center"><strong>Welcome to the Calorie Counter</strong></h1>
        <h4 style="text-align:center">Please Log In</h4>
        User Name:
        <asp:TextBox ID="usernameTB" runat="server"></asp:TextBox>
        <br />
        Password:
        <asp:TextBox ID="passwordTB" runat="server" TextMode="Password" style="z-index: 1; left: 87px; top: 142px; position: absolute"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="LoginB" runat="server" OnClick="LoginB_Click" Text="Login" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="registerB" runat="server" OnClick="registerB_Click" Text="Register"/>
        <br />
        <asp:Label ID="userwarninglabel" runat="server" ForeColor="Red" Text="Incorrect Username or Password. Please try again" Visible="False"></asp:Label>
    
    </div>
    </form>
</body>
</html>
