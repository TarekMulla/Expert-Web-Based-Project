<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Star rating.ascx.cs" Inherits="AtomLabCoursesV1._0.Controls.Star_rating" %>

<script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
<link rel="stylesheet" href="Content/bootstrap.css" />
<script src="Scripts/jquery.min.js"></script>
<link href="jquery/jRating.jquery.css" rel="stylesheet" />
<script src="jquery/jRating.jquery.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
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

<div class="exemple">
    <div class="basic" data-average="0" data-id="1" id="Rating"></div>
    <div id="jax"></div>
</div>