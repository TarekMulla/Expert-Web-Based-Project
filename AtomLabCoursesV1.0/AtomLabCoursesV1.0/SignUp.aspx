<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="AtomLabCoursesV1._0.SignUp" %>

<%@ Register Src="~/Controls/CategoriesMenu.ascx" TagPrefix="uc1" TagName="CategoriesMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ContactsFields" >
        <table style="width:950px;">
            <tr>
                <td style="width:50%;">
                    <div class="control-group" style="padding-left:50px">
                        <label class="control-label" for="inputSubject">User name</label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-pencil"></i></span>
                                <asp:TextBox ID="UserNameTB" runat="server" CssClass="input-xlarge"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                ErrorMessage="required" ForeColor="Red" ControlToValidate="UserNameTB" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="control-group" style="padding-left:50px">
                        <label class="control-label" for="inputSubject">First name</label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-pencil"></i></span>
                                <asp:TextBox ID="FirstNameTB" style="height:20px;" runat="server" CssClass="input-xlarge"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="control-group" style="padding-left:50px">
                        <label class="control-label" for="inputSubject">Last name</label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-pencil"></i></span>
                                <asp:TextBox ID="LastNameTB" runat="server" CssClass="input-xlarge"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                </td>
                <td style="width:50%;">
                    <div class="control-group" style="padding-left:50px">
                        <label class="control-label" for="inputMobile">Password</label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-th"></i></span>
                                <asp:TextBox ID="PasswordTB" runat="server" CssClass="input-xlarge"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ErrorMessage="required" ForeColor="Red" ControlToValidate="PasswordTB" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="control-group" style="padding-left:50px">
                        <label class="control-label" for="inputEmail">Email</label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on">@</span>
                                <asp:TextBox ID="EmailTB" runat="server" CssClass="input-xlarge"></asp:TextBox>
                            </div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ErrorMessage="Unvalid Format" ForeColor="Red" ControlToValidate="EmailTB"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="control-group" style="padding-left:50px">
                        <label class="control-label" for="inputTelephone">Job</label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-home"></i></span>
                                <asp:TextBox ID="JobTB" runat="server" CssClass="input-xlarge"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label style="padding-bottom:10px; padding-left:10px">Your expert:</label>
                    <uc1:CategoriesMenu runat="server" id="CategoriesMenu" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div class="control-group" >
                        <span style="padding-left:40%">
                            <asp:Button ID="SentBtn" runat="server" Text="SignUp" class="btn btn-success btn-primary" OnClick="SentBtn_Click"/>
                            <button class="btn" type="reset">Clear All</button>
                        </span>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
