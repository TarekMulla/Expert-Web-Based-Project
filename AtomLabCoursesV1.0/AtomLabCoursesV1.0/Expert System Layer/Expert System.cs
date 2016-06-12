using AtomLabCoursesV1._0.DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtomLabCoursesV1._0.Expert_System_Layer
{
    public class Expert_System
    {
        static public void Set_Signin_User(string name)
        {
            InferenceEngine IE = new InferenceEngine();
            string Rules_File_Path = HttpContext.Current.Server.MapPath("~/Expert System Layer/Rules Knowledge Base.ruleml");
            string Facts_File_Path = HttpContext.Current.Server.MapPath("~/Expert System Layer/Facts Knowledge Base.ruleml");
            IE.Load_Rules(Rules_File_Path);
            IE.Load_Facts(Facts_File_Path);
            Facts.Add_User_Signin_Fact(IE, name.ToLower());
            IE.Save_Facts(Facts_File_Path);
        }

        static public void Run_Inference_Engine_For_Calculate_Priority()
        {
            InferenceEngine IE = new InferenceEngine();
            string Rules_File_Path = HttpContext.Current.Server.MapPath("~/Expert System Layer/Rules Knowledge Base.ruleml");
            string Facts_File_Path = HttpContext.Current.Server.MapPath("~/Expert System Layer/Facts Knowledge Base.ruleml");
            IE.Load_Rules(Rules_File_Path);
            IE.Load_Facts(Facts_File_Path);
            Facts.Add_All_Facts(IE);
            IE.Process();
            Rules.insert_Actual_Rating(IE);
            Rules.insert_Final_Rating(IE);
            foreach (Course course in CoursesTable.SelectAll())
                Facts.Add_Final_Rate_Fact(IE, course);
            IE.Process();
            Rules.insert_Course_Priority(IE);
        }

        static public void Run_Inference_Engine_For_Calculate_Friend()
        {
            InferenceEngine IE = new InferenceEngine();
            string Rules_File_Path = HttpContext.Current.Server.MapPath("~/Expert System Layer/Rules Knowledge Base 2.ruleml");
            string Facts_File_Path = HttpContext.Current.Server.MapPath("~/Expert System Layer/Facts Knowledge Base.ruleml");
            IE.Load_Rules(Rules_File_Path);
            IE.Load_Facts(Facts_File_Path);
            Facts.Add_All_Facts(IE);
            IE.Process();
            Rules.insert_User_Friends(IE);
            Rules.insert_Expert_Friends(IE);
        }
    }
}