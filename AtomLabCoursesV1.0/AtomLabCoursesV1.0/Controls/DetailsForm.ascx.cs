using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtomLabCoursesV1._0.Controls
{
    public partial class DetailsForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"]);
                CoursesDataBaseEntities entity = new CoursesDataBaseEntities();
                Course c = (from o in entity.Courses where o.ID == id select o).Single();
                Session["course"] = c.Name;
                TextTitle.InnerHtml = c.Name + " by Lecturer: " + c.Teacher;
                TextDetails.InnerHtml = c.Details;
                Thumb.ImageUrl = "/Images/courses/" + c.Image;
                HiddenFormImage.ImageUrl = "/Images/courses/" + c.Image;
                HiddenFormFooter.InnerHtml = c.Name + " Course";
                HiddenFormTitle.InnerHtml = c.Name + " image";
            }
            catch (Exception ex)
            { }
        }
    }
}