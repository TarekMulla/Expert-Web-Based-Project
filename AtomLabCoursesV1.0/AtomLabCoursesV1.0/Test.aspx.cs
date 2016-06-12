using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtomLabCoursesV1._0.DataBaseLayer;
using AtomLabCoursesV1._0.Expert_System_Layer;

namespace AtomLabCoursesV1._0
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Expert_System.Run_Inference_Engine_For_Calculate_Priority();
            //List<Course> courses = CoursesTable.SelectAllOrderdByPriority();
            //foreach(Course course in courses)
            //{
            //    ListBox1.Items.Add(course.Name + "   " + course.Priority);
            //}

            InferenceEngine IE = new InferenceEngine();
            string Rules_File_Path = HttpContext.Current.Server.MapPath("~/Expert System Layer/Rules Knowledge Base.ruleml");
            string Facts_File_Path = HttpContext.Current.Server.MapPath("~/Expert System Layer/Facts Knowledge Base.ruleml");
            string Facts_File_Path2 = HttpContext.Current.Server.MapPath("~/Expert System Layer/Facts Knowledge Base2.ruleml");
            
            IE.Load_Rules(Rules_File_Path);
            IE.Load_Facts(Facts_File_Path);
            Facts.Add_User_Signin_Fact(IE, "Admon");
            IE.Save_Facts(Facts_File_Path2);
        }
    }
}