<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="AtomLabCoursesV1._0.About" %>

<%@ Register Src="~/Controls/DetailsForm.ascx" TagPrefix="uc1" TagName="DetailsForm" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <ul class="thumbnails pull-left">
            <li class="thumbnails pull-left" style="margin-right: 30px;margin-bottom: 6px; margin-top: 30px;">
                <a href="#myModal" role="button" class="btn thumbnail" data-toggle="modal">
                    <asp:Image id="Thumb" runat="server" style="width: 360px; height: 270px;"/>
                </a>
                <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="width: inherit;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">Close</button>
                        <h3 id="HiddenFormTitle" runat="server"></h3>
                    </div>
                    <div class="modal-body" style="max-height: 1000px;">
                        <asp:Image ID="HiddenFormImage" runat="server" Width="480px" Height="360px" ImageAlign="AbsMiddle" />
                    </div>
                    <div class="modal-footer">
                        <h4 id="HiddenFormFooter" runat="server"></h4>
                    </div>
                </div>
            </li>
            <br />
            <br />
            <h4 id="TextTitle" runat="server" style="padding-left:20px;"></h4>
            <p id="TextDetails" runat="server" style="padding-left:20px; text-align:justify;"></p>
            <hr>
        </ul>
    </div>
</asp:Content>
