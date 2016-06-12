using AtomLabCoursesV1._0.DataBaseLayer;
using AtomLabCoursesV1._0.Expert_System_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtomLabCoursesV1._0.Admin
{
    public partial class Show_Facts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InferenceEngine IE = new InferenceEngine();
            string Rules_File_Path = HttpContext.Current.Server.MapPath("~/Expert System Layer/Rules Knowledge Base.ruleml");
            string Facts_File_Path = HttpContext.Current.Server.MapPath("~/Expert System Layer/Facts Knowledge Base.ruleml");
            IE.Load_Rules(Rules_File_Path);
            IE.Load_Facts(Facts_File_Path);
            Facts.Add_All_Facts(IE);
            IE.Update_Facts(Facts_List_Befour_Processing);



            IE.Process();
            IE.Update_Facts(Facts_List_after_Process1);



            Rules.insert_Actual_Rating(IE);
            Rules.insert_Final_Rating(IE);
            foreach (Course course in CoursesTable.SelectAll())
                Facts.Add_Final_Rate_Fact(IE, course);
            IE.Update_Facts(Facts_List_after_Process2);



            IE.Process();
            Rules.insert_Course_Priority(IE);
            IE.Update_Facts(Facts_List_after_Process3);
        }
    }
}