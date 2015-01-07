<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateProfile.aspx.cs" Inherits="NewCalories.updatePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        h1{background-color: bisque; border:thick dotted; font-size: x-large}
        h4 {background-color: gray ; border:medium dashed #948846}
        body {background-color: burlywood}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1" height: 100vh; width: 100%;>
    
        <h1 style="text-align:center"><strong>Update Profile</strong></h1>
        <p>
            Enter New Password:
            <asp:TextBox ID="changePasswordTB" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="changePasswordB" runat="server" OnClick="changePasswordB_Click" Text="Change Password" />
            <asp:Label ID="infoMessage" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
            <asp:Button ID="returnB" runat="server" OnClick="returnB_Click" Text="Return to Previous Page" style="z-index: 1; left: 177px; top: 119px; position: absolute" />
            <asp:Button ID="deleteAccountB" runat="server" OnClick="deleteAccountB_Click" Text="Delete Account" />
    </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
