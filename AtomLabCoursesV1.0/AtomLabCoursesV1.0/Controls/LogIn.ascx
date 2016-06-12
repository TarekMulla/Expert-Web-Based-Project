<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LogIn.ascx.cs" Inherits="AtomLabCoursesV1._0.Controls.LogIn" %>

<link href="../Content/login-box.css" rel="stylesheet" />

<div class="modal-header">
    <asp:Button ID="Button2" CssClass="close" runat="server" Text="Close"></asp:Button>
    <h3 id="HiddenFormTitle" runat="server">Sign In</h3>
</div>
<div id="login-box" style="padding-left:50px;">
    <div class="login-box-name">Username:</div>
    <div class="login-box-field">
        <asp:TextBox ID="usernameTB" runat="server" CssClass="form-login"></asp:TextBox>
    </div>

    <br style="clear: both" />

    <div class="login-box-name">Password:</div>
    <div class="login-box-field">
        <asp:TextBox ID="passwordTB" runat="server" CssClass="form-login" TextMode="Password"></asp:TextBox>
    </div>

    <br style="clear: both" />
    <asp:Label ID="Statu" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br style="clear: both" />
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/login//login-btn.png" Style="padding-bottom:30px;" Width="103" Height="42" OnClick="ImageButton1_Click"></asp:ImageButton>
</div>  