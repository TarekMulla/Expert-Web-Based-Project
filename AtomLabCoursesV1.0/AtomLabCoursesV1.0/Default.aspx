<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AtomLabCoursesV1._0._Default" %>

<%@ Register Src="~/Controls/LeftMenu.ascx" TagPrefix="uc1" TagName="LeftMenu" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .row1 {
	        width: 739px;
	        float: left;
	        padding-bottom: 10px;
	        margin-bottom: 10px;
        }
        .title {
	        font-family: Arial, Helvetica, sans-serif;
	        font-size: 25px;
	        font-weight: normal;
	        color: #222222;
            font-weight:bold;
	        margin-bottom: 20px;
        }
        .row2 {
	        background-color: #e8eae9;
	        width: 730px;
	        float: left;
	        border: solid 1px #dbdada;
        }
        .section1 {
	        width: 340px;
	        float: left;
	        padding: 10px;
        }
        .section2 {
            background-image: url(../images/MasterpageImages/section-bg.jpg);
	        background-repeat: no-repeat;
	        background-position: left top;
	        width: 340px;
	        float: left;
	        padding: 10px;
        }
        .subtitle {
	        font-family: Arial, Helvetica, sans-serif;
	        font-size: 25px;
	        font-weight: normal;
	        color: #0b90d6;
	        margin-bottom: 15px;
        }
        a.more {
	        font-size: 12px;
	        line-height: 25px;
	        color: #4d4e4e;
	        text-decoration: none;
	        background-image: url(../images/MasterpageImages/more-btn.jpg);
	        background-repeat: no-repeat;
	        background-position: left top;
	        text-align: left;
	        display: block;
	        width: 80px;
	        height: 25px;
	        padding-left: 10px;
        }
        a.more:hover {
	        color: #0b90d6;
        }
        .content-right {
	        width: 200px;
            float:right;
	        padding-right: 20px;
	        margin-top: 20px;
	        border: 1px solid #d9d8d8;
        }
    </style>
    <table class="content">
        <tr class="content-left" style="width: 700px;">
            <td class="row1">
                <div style="float: left;"><img src="images/MasterpageImages/img1.jpg" alt="" height="101"
                 width="157"></div>
                <div style="width: 562px;float: right;">
                    <h1 class="title">Welcome to <span style="color:#ff0000;">ATom-Lab</span> Company</h1>
                    <p><strong>AtomLab is a Company that constraint by: Eng.Tarek Mulla and Eng.Ahmad Sahyouni at 2014 in LCITI at Syrian Computer Society (SCS) Build.</strong></p>
                </div>
                <div class="row2">
                    <div class="section1">
                    <h2 class="subtitle">What&#8217;s New In this Website</h2>
                    <p><strong>ATom-Lab Courses web site provided inovation method to display the best course of you.</strong><br>
                        The website use expert system way to find what you need by other users expert....</p>
                    <p><a href="#" class="more">read more</a></p>
                    </div>
                    <div class="section2">
                    <h2 class="subtitle">Technology</h2>
                    <p><strong>ATom-Lab Courses Website use the Latest web technology and Libraries in web.</strong><br>
                        AJAX tech, JQuery Lib, BootStrap Lib, ASP.NET Server side Lang, XML, SQL Server ,....</p>
                    <p><a href="#" class="more">read more</a></p>
                    </div>
                </div>
            </td>
            <td class="content-right">
                <uc1:LeftMenu runat="server" ID="LeftMenu" />
            </td>
        </tr>  
    </table>
</asp:Content>
