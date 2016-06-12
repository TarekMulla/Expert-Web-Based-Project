<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailsForm.ascx.cs" Inherits="AtomLabCoursesV1._0.Controls.DetailsForm" %>
<%@ Register Src="~/Controls/Star rating.ascx" TagPrefix="uc1" TagName="Starrating" %>

<script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
<link rel="stylesheet" href="Content/bootstrap.css" />
<script src="Scripts/jquery.min.js"></script>
<link href="jquery/jRating.jquery.css" rel="stylesheet" />
<script src="jquery/jRating.jquery.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        var course = sessionStorage["coure"];
        // simple jRating call
        $(".basic").jRating({
            decimalLength: 1,
            step: true,
            //type: 'small',
            length: 5,
            //isDisabled : true,
            canRateAgain: true,
            nbRates: 100,
            showRateInfo: false,
            sendRequest: true,
            onSuccess: function () { alert('Success : your rate has been saved :)'); },
            onError: function () { alert('Error : please retry'); },
            onClick: function (element, rate) { AJAX_connection("../Add Rate.aspx?rate=" + (rate / 4)); }
        });
    });

    function connect() {
        var xmlhttp;
        try {
            xmlhttp = new XMLHttpRequest();
        }
        catch (err) {
            try {
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch (err) {
                try {
                    xmlhttp = new ActiveXObject("Msxml2.XMLHTTP.3.0");
                }
                catch (err) {
                    xmlhttp = new ActiveXObject("Msxml2.XMLHTTP.6.0");
                }
            }
        }
        return xmlhttp;
    }

    function statechange() {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("jax").innerHTML = this.responseText;
        }
    }

    function AJAX_connection(page) {
        var xmlhttp;
        xmlhttp = connect();
        xmlhttp.onreadystatechange = statechange;
        xmlhttp.open("GET", page, true);
        xmlhttp.send();
    }

    </script>

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
        <br>
        <h4 id="TextTitle" runat="server" style="padding-left:20px;"></h4>
        <div class="basic" data-average="0" data-id="1" id="Rating"></div>
        <div id="jax"></div>
        <p id="TextDetails" runat="server" style="padding-left:20px; text-align:justify;"></p>
        <hr>
    </ul>
</div>
