<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Show Facts.aspx.cs" Inherits="AtomLabCoursesV1._0.Admin.Show_Facts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-left:100px; padding-top:20px; padding-right:50px" >
        <asp:Label ID="Label2" runat="server" Text="Befour Processing"></asp:Label>
        <asp:ListBox ID="Facts_List_Befour_Processing" runat="server" Height="300px" Width="100%"></asp:ListBox>
        <br />
        <center>
        <asp:Label ID="Label1" runat="server" Text="After Process 1: Add Actual Rating"></asp:Label></center>
        <asp:ListBox ID="Facts_List_after_Process1" runat="server" Height="300px" Width="100%"></asp:ListBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="After Process 2: Add Final Rating"></asp:Label></center>
        <asp:ListBox ID="Facts_List_after_Process2" runat="server" Height="300px" Width="100%"></asp:ListBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="After Process 3: Add Courses Priority"></asp:Label></center>
        <asp:ListBox ID="Facts_List_after_Process3" runat="server" Height="300px" Width="100%"></asp:ListBox>
    </div>
</asp:Content>
