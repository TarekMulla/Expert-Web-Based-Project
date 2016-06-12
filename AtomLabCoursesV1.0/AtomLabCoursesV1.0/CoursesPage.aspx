<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoursesPage.aspx.cs" Inherits="AtomLabCoursesV1._0.CoursesPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="headContent" runat="server">
    <script src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link href="jquery/jRating.jquery.css" rel="stylesheet" />
    <script src="jquery/jRating.jquery.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".basic").jRating({
                decimalLength: 1,
                step: true,
                length: 5,
                isDisabled : true,
                showRateInfo: false,
            });
        });

    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:EntityDataSource ID="CoursesEntity" runat="server" ConnectionString="name=CoursesDataBaseEntities"
        DefaultContainerName="CoursesDataBaseEntities" EnableFlattening="False" OrderBy="it.[Priority] DESC"
        EntitySetName="Courses" EntityTypeFilter="Course" AutoGenerateWhereClause="True" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
    </asp:EntityDataSource>
    <asp:ListView ID="ListView1" runat="server" DataSourceID="CoursesEntity" ItemPlaceholderID="itemPlaceholder">
        <ItemTemplate>
            <h4 style="color: #0000FF; padding-left: 30px; padding-bottom: 10px; font-weight: 700;"><%# Eval("Name")%> course</h4>
            <div style="padding-left: 30px; width: 100%;">
                <a class="pull-left" href="CourseDetails.aspx?id=<%# Eval("id")%>&rate=<%# Eval("rate") %>">
                    <div class="basic" data-average="<%# Convert.ToInt32(Eval("rate"))*4 %>" data-id="1" id="Rating" style="padding-bottom:10px"></div>
                    <img class="media-object img-polaroid" style="width: 150px; height: 150px;" src="<%# "Images/courses/" + Eval("Image") %>">
                </a>
                <div class="media-body" style="padding-left: 30px;">
                    <h5>lecturer is: <%# Eval("Teacher").ToString()%></h5>
                    <h5>Course Level: <%# Eval("CourseLevel") %> </h5>
                    <h5>Course Field: <%# AtomLabCoursesV1._0.DataBaseLayer.CategoriesTable.Select(Convert.ToInt32(Eval("Field"))).Name%></h5>
                    <h5>Hours number: <%# Eval("HoursNumber") %></h5>
                    <h6 style="width: 700px; text-justify: kashida; text-align: justify;"><%# (((string)Eval("Details")).Length >=250)?((string)Eval("Details")).Substring(0,250) :Eval("Details") %>....</h6>
                    <a href="CourseDetails.aspx?id=<%# Eval("ID") %>&rate=<%# Eval("rate") %>" class="text-info button">See all about this Course</a>
                </div>
            </div>
            <hr />
        </ItemTemplate>
        <LayoutTemplate>
            <div class="container-fluid" style="margin-top: 0px; margin-bottom: 30px;">
                <div class="row-fluid">
                    <div class="span12">
                        <placeholder id="itemPlaceholder" runat="server"></placeholder>
                        <center style="clear: both;">
                            <div class="pagination pagination-centered well">
                                <ul><li><asp:DataPager runat="server" ID="RecordsDataPager" PageSize="5">
                                    <Fields> 
                                        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" FirstPageText="  First  " PreviousPageText="  Previous  " />
                                        <asp:NumericPagerField ButtonCount="10" />
                                        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" NextPageText="  Next  " LastPageText="  End  " />
                                    </Fields>
                                </asp:DataPager></li></ul>
                            </div>
                        </center>
                    </div>
                </div>
            </div>
        </LayoutTemplate>
        <EmptyDataTemplate>
            <center>There isn't any record.</center>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
