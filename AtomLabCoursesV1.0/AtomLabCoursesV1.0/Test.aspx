<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="AtomLabCoursesV1._0.Test" %>

<%@ Register Src="~/Controls/Star rating.ascx" TagPrefix="uc1" TagName="Starrating" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body class="container-fluid">
    <form runat="server">
        <asp:ListBox ID="ListBox1" runat="server" Height="235px" Width="512px"></asp:ListBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </form>
</body>
</html>
