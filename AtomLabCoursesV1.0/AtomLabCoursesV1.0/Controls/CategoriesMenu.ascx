<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoriesMenu.ascx.cs" Inherits="AtomLabCoursesV1._0.Controls.CategoriesMenu" %>

<script runat="server">
    void Group_Init(object sender, EventArgs e)
    {
        if (groupId == 0)
        {
            ((HtmlControl)sender).Attributes.Add("Class", "item active");
            groupId++;
        }
    }
    int groupId = 0;
</script>

<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=CoursesDataBaseEntities" DefaultContainerName="CoursesDataBaseEntities" EnableFlattening="False" EntitySetName="Categories"></asp:EntityDataSource>

<asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" DataSourceID="EntityDataSource1" GroupItemCount="4" 
    ItemPlaceholderID="itemPlaceholder">
    <ItemTemplate>
        <div class="span3" style="text-align:center;">
            <div style="color:deeppink; font-size:18px;"><%# (String)Eval("Name") %></div>
            <img src="<%# "Images/Categories/" + (String)Eval("Image") %>" alt=""
                 style="max-width: 100%; max-height: 100px;  padding-top:10px; padding-bottom:10px;">
            <asp:DropDownList ID="DropDownList1" runat="server" style="max-width: 90%;">
                <asp:listitem text="No expert" Value="0" Selected="True" ></asp:listitem>
                <asp:listitem text="Beginner" Value="1"></asp:listitem>
                <asp:listitem text="Medium" Value="2"></asp:listitem>
                <asp:listitem text="Expert" Value="3"></asp:listitem>
            </asp:DropDownList>
        </div>
    </ItemTemplate>
    <GroupTemplate>
        <div runat="server" class="item" oninit="Group_Init">
            <div class="row-fluid">
                <div runat="server" id="itemPlaceholder" />
            </div>
        </div>
    </GroupTemplate>
    <LayoutTemplate>
        <div id="myHCarousel" class="carousel vertival-carousel slide">
            <div class="carousel-inner">
                <div id="groupPlaceholder" runat="server"></div>
                <a class="left carousel-control" href="#myHCarousel" data-slide="prev">‹</a>
                <a class="right carousel-control" href="#myHCarousel" data-slide="next">›</a>
            </div>
        </div>
    </LayoutTemplate>
</asp:ListView>

