using AtomLabCoursesV1._0.Expert_System_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtomLabCoursesV1._0.Admin
{
    public partial class Show_Rules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Rules_File_Path = HttpContext.Current.Server.MapPath("~/Expert System Layer/Rules Knowledge Base.ruleml");
            string Facts_File_Path = HttpContext.Current.Server.MapPath("~/Expert System Layer/Facts Knowledge Base.ruleml");

            ((InferenceEngine)Application["IE"]).Load_Rules(Rules_File_Path);
            ((InferenceEngine)Application["IE"]).Load_Facts(Facts_File_Path);
            Facts.Add_All_Facts((InferenceEngine)Application["IE"]);

            ((InferenceEngine)Application["IE"]).Update_Rules(Facts_List);
        }
    }
}