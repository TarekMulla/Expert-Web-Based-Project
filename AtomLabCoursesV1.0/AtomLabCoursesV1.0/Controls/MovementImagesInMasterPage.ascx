<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MovementImagesInMasterPage.ascx.cs" Inherits="AtomLabCoursesV1._0.Controls.MovementImagesInMasterPage" %>

<script src="Scripts/jquery.min.js"></script>
<script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
<link rel="stylesheet" href="Content/bootstrap.css" />

<div class="container Content" style="padding-top:3px; width:100%;">
    <div class="container-fluid">
        <asp:ListView ID="ListView3" runat="server" DataSourceID="MainImagesEntity">
            <EmptyDataTemplate>
                <table runat="server">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <div class="item <%# Container.DataItemIndex ==0 ? "active":"" %>">
                    <img src='<%# "images/MainImages/" + (String)Eval("ImageURL") %>' alt="" />
                </div>
            </ItemTemplate>
            <LayoutTemplate>
                <div id="myCarousel" class="carousel slide">
                    <asp:ListView ID="ListView2" runat="server" ItemPlaceholderID="itemPlaceholderInner"
                        DataSourceID="MainImagesEntity" DataKeyNames="ID">
                        <LayoutTemplate>
                            <ol class="carousel-indicators">
                                <li id="itemPlaceholderInner" runat="server"></li>
                            </ol>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li data-target="#myCarousel" data-slide-to="<%# Container.DataItemIndex %>" class="<%# Container.DataItemIndex ==0 ? "active":"" %>"></li>
                        </ItemTemplate>
                    </asp:ListView>

                    <div class="carousel-inner">
                        <div id="itemPlaceholder" runat="server"></div>
                    </div>
                    <a class="left carousel-control" href="#myCarousel" data-slide="prev">‹</a>
                    <a class="right carousel-control" href="#myCarousel" data-slide="next">›</a>
                </div>
            </LayoutTemplate>
        </asp:ListView>

        <asp:EntityDataSource ID="MainImagesEntity" runat="server" ConnectionString="name=CoursesDataBaseEntities"
             DefaultContainerName="CoursesDataBaseEntities" EnableFlattening="False" EntitySetName="MainImages"
             Select="it.[Id], it.[ImageUrl], it.[ImageThumbURL]" EntityTypeFilter="MainImage"></asp:EntityDataSource>
    </div>
</div>