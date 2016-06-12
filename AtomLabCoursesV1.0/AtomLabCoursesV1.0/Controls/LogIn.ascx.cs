using AtomLabCoursesV1._0.DataBaseLayer;
using AtomLabCoursesV1._0.Expert_System_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtomLabCoursesV1._0.Controls
{
    public partial class LogIn : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            User user = UsersTable.Select(usernameTB.Text);

            if (user == null)
                Statu.Text = "Wrong User name... User Name not register";
            else if(user.Password != passwordTB.Text)
                Statu.Text = "Wrong Password...";
            else if (usernameTB.Text == "Admin")
            {
                Session["User"] = "Admin";
                Expert_System.Set_Signin_User(Session["User"].ToString());
                Expert_System.Run_Inference_Engine_For_Calculate_Priority();
                HttpContext.Current.Response.Redirect("~/Admin/Main Admin.aspx");
            }
            else
            {
                Session["User"] = usernameTB.Text;
                Expert_System.Set_Signin_User(Session["User"].ToString());
                Expert_System.Run_Inference_Engine_For_Calculate_Priority();
                HttpContext.Current.Response.Redirect("CoursesPage.aspx");
            }
        }
    }
}