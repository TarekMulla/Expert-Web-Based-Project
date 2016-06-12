<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftMenu.ascx.cs" Inherits="AtomLabCoursesV1._0.Controls.LeftMenu" %>

<style type="text/css">
    
.left-content{
	background-color: #d6d6d6;
	background-image: url(../images/sidebarbg.jpg);
	background-repeat: repeat-x;
	width: 210px;
	padding-left: 5px;
	margin-top: 21px;
	border: 1px solid #d9d8d8;
}

.right-content{
    padding-left:10px;
    padding-right:10px;
    padding-top:10px;
    padding-bottom:10px;
}
.Menu h2 {
	font-size: 22px;
	font-weight: normal;
	color: #0b90d6;
	margin-top: 20px;
	margin-bottom: 16px;
	margin-left: 35px;
}
.Menu ul {
	list-style-type: none;
}
.Menu ul li {
	background-image: url(../images/bullet.gif);
	background-repeat: no-repeat;
	background-position: 1px center;
	padding-left: 10px;
	padding-top: 4px;
	padding-bottom: 4px;
	border-top-width: 1px;
	border-top-style: solid;
	border-top-color: #cbcccc;
}
.Menu ul li a {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	color: #3e3d3d;
	text-decoration: none;
	text-align: left;
	display: block;
}
.Menu ul li a:hover {
	color: #0b90d6;
}
</style>

<div class="Menu">
	<h2>Main Menu</h2>
	<ul>
		<li style="border-top: medium none;"><a href="#">courses</a></li>
		<li><a href="#">Books</a></li>
		<li><a href="#">Friends can ask him</a></li>
		<li><a href="#">Best Rating Courses</a></li>
		<li><a href="#">new expert</a></li>
		<li><a href="#">new expert</a></li>
		<li><a href="#">new expert</a></li>
	</ul>
</div>
