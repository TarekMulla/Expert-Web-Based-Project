<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseDetails.aspx.cs" Inherits="AtomLabCoursesV1._0.CourseDetails" %>

<%@ Register Src="~/Controls/DetailsForm.ascx" TagPrefix="uc1" TagName="DetailsForm" %>

<asp:Content ID="Content2" ContentPlaceHolderID="headContent" runat="server">
    <script src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Content/bootstrap.css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:DetailsForm runat="server" id="DetailsForm" />
</asp:Content>
