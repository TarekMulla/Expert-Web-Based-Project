using AtomLabCoursesV1._0.DataBaseLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtomLabCoursesV1._0.Admin
{
    public partial class AddCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SentBtn_Click(object sender, EventArgs e)
        {            
            string coursename = CourseNameTB.Text;
            string lecturername = LecturerNameTB.Text;
            int category = int.Parse(CategoryDDL.SelectedValue);
            int hardlevel = int.Parse(HardLevelTB.SelectedValue);
            int hours;
            try { hours = int.Parse(HoursTB.Text); }
            catch (Exception ex) { hours = 0; }
            string imagename = ImagePathTB.Text;
            string details = DetailsTB.Text;
            CoursesTable.Insert(coursename, lecturername, category, hardlevel, hours, imagename, details,0);
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile)
            {
                if (ImagePathTB.Text!=null)
                { 
                    try{File.Delete(Server.MapPath("~/Images/Courses/" + ImagePathTB.Text));}
                    catch(Exception Exception){}
                }
                ImagePathTB.Text = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/Courses/" + FileUpload1.FileName));
                CourseImage.ImageUrl = "../Images/Courses/" + FileUpload1.FileName;
            }
        }
    }
}