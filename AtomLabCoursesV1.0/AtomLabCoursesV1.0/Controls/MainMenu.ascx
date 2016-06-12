<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="AtomLabCoursesV1._0.Controls.MainMenu" %>
<%@ Register Src="~/Controls/LogIn.ascx" TagPrefix="uc1" TagName="LogIn" %>
<link href="Content/login-box.css" rel="stylesheet" />
<style type="text/css">
    .MainMenu {
	    background-image: url(../images/MasterpageImages/menubg.jpg);
	    background-repeat: repeat-x;
        background-position:center;
	    width: 100%;
	    height: 37px;
	    border: 1px solid #000000;
    }
    .MainMenu ul {
	    width: 100%;
	    height: 37px;
        list-style-type:none;
    }
    .MainMenu ul li {
	    height: 37px;
	    float: left;
	    padding-right: 20px;
	    padding-left: 20px;
    }
    .MainMenu ul li a {
	    font-family: Arial, Helvetica, sans-serif;
	    font-size: 12px;
	    font-weight: bold;
	    line-height: 37px;
	    color: #FFFFFF;
	    text-decoration: none;
	    display: block;
	    height: 37px;
	    float: left;
	    padding-right: 21px;
	    padding-left: 21px;
    }
    .MainMenu ul li a:hover {
	    background-image: url(../images/menu-hov.jpg);
	    background-repeat: repeat-x;
	    background-position: left top;
    }
</style>

<div class="MainMenu">
    <ul>
	    <li><a href="default.aspx"><asp:ImageButton ID="Defaultbtn" runat="server" AlternateText="Home" ForeColor="White" OnClick="Defaultbtn_Click"/></a></li>
	    <li><a href="CoursesPage.aspx"><asp:ImageButton ID="Coursesbtn" runat="server" AlternateText="Courses" ForeColor="White" OnClick ="Coursesbtn_Click"/></a></li>
	    <li><a href="#"><asp:ImageButton ID="ImageButton5" runat="server" AlternateText="What's new" ForeColor="White" OnClick="ImageButton5_Click"/></a></li>
	    <li><a href="About.aspx"><asp:ImageButton ID="Aboutbtn" runat="server" AlternateText="Abour us" ForeColor="White" OnClick="Aboutbtn_Click"/></a></li>
	    <li><a href="Contact.aspx"><asp:ImageButton ID="Contactbtn" runat="server" AlternateText="Contact" ForeColor="White" OnClick="Contactbtn_Click"/></a></li>
	    <li><a href="SignUp.aspx"><asp:ImageButton ID="as" runat="server" AlternateText="Sign up" ForeColor="White" OnClick="Signupbtn_Click"/></a></li>
	    <li>
            <a href="#LogINModel<%# Session["User"]==null?"":"A" %>" data-toggle="modal">
                <asp:ImageButton ID="Signinbtn" runat="server" AlternateText="Sign in" ForeColor="White" OnClick ="Signinbtn_Click"/>
            </a>
	    </li>
    </ul>
    
    <div id="LogINModel" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true"
        style="background:url(../images/Login/Slide2.png) no-repeat left top; background-image:repeating-radial-gradient(); width:500px" >
        <uc1:LogIn runat="server" ID="LogIn" />
    </div>
</div>