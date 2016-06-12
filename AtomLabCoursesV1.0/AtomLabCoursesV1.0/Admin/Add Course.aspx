<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Add Course.aspx.cs" Inherits="AtomLabCoursesV1._0.Admin.AddCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <script src="../Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Content/bootstrap.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="CoursesFields"  style="margin-left:100px;" >
        <table style="padding-left:20px; align-content:center">
            <tr>
                <td style="width:50%;">
                    <div class="control-group">
                        <label class="control-label" for="inputSubject">Course name</label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-pencil"></i></span>
                                <asp:TextBox ID="CourseNameTB" runat="server" style="height:20px;" CssClass="input-xlarge"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                ErrorMessage="required" ForeColor="Red" ControlToValidate="CourseNameTB" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label" for="inputSubject">Lecturer name</label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-pencil"></i></span>
                                <asp:TextBox ID="LecturerNameTB" style="height:20px;" runat="server" CssClass="input-xlarge"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label" for="inputSubject">Category</label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-th"></i></span>
                                <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=CoursesDataBaseEntities"
                                     DefaultContainerName="CoursesDataBaseEntities" EnableFlattening="False" EntitySetName="Categories"></asp:EntityDataSource>
                                <asp:DropDownList ID="CategoryDDL" runat="server" CssClass="input-xlarge" DataSourceID="EntityDataSource1" DataTextField="Name" DataValueField="ID">
                                    <asp:ListItem Text="Beginner" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Mederait" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Expert" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label" for="inputMobile">Hard Level</label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-th"></i></span>
                                <asp:DropDownList ID="HardLevelTB" runat="server" CssClass="input-xlarge">
                                    <asp:ListItem Text="Beginner" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Mederait" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Expert" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label" for="Hours">Hours</label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-home"></i></span>
                                <asp:TextBox ID="HoursTB" runat="server" style="height:20px;" CssClass="input-xlarge"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </td>
                <td style="width:50%;">
                    <div class="container-fluid">
                        <ul class="thumbnails pull-left">
                            <li class="thumbnails pull-left" style="margin-right: 30px;margin-bottom: 6px; margin-top: 30px;">
                                <a href="#myModal" role="button" class="btn thumbnail" data-toggle="modal">
                                    <asp:Image id="CourseImage" runat="server" style="width: 400px; height: 300px;"/>
                                    <asp:TextBox ID="ImagePathTB" runat="server"></asp:TextBox>
                                </a>
                                <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="width: inherit;">
                                    <div class="modal-header">
                                        <asp:Button ID="Button2" CssClass="close" runat="server" Text="Close"></asp:Button>
                                        <h3 id="HiddenFormTitle" runat="server"> Select Image path</h3>
                                    </div>
                                    <div class="modal-body" style="width:300px;">
                                        <asp:FileUpload ID="FileUpload1" runat="server"/>
                                        <asp:Button ID="Button1" Width="100px" Height="50px" runat="server" Text="OK" OnClick="Upload_Click" />
                                    </div>
                                    <div class="modal-footer">
                                        <h4 id="HiddenFormFooter" runat="server"></h4>
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div class="control-group">
                        <label class="control-label" for="inputMessage">Course Details</label>
                        <div class="controls">
                            <div class="input-prepend" >
                                <span class="add-on"><i class="icon-comment"></i></span>
                                <asp:TextBox ID="DetailsTB" runat="server" TextMode="MultiLine" width="800px" Columns="1000" Rows="10" placeholder="Write a details of the course here"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div class="control-group" >
                        <span style="padding-left:40%">
                            <asp:Button ID="SentBtn" runat="server" Text="Add Course" class="btn btn-success btn-primary" OnClick="SentBtn_Click"/>
                            <button class="btn" type="reset">Clear All</button>
                        </span>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
