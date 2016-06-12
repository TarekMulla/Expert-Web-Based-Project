using AtomLabCoursesV1._0.Expert_System_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtomLabCoursesV1._0.Controls
{
    public partial class MainMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["User"] != null)
               // Signinbtn.AlternateText = "Sign out";
        }

        protected void Signinbtn_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["User"] != null)
            {
                Session["User"] = null;
                Expert_System.Set_Signin_User("");
            }
            else
            {

            }
            HttpContext.Current.Response.Redirect("Default.aspx");
        }

        protected void Defaultbtn_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.Redirect("Default.aspx");
        }

        protected void Coursesbtn_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.Redirect("CoursesPage.aspx");
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.Redirect("Default.aspx");
        }

        protected void Signupbtn_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.Redirect("Signup.aspx");
        }

        protected void Contactbtn_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.Redirect("Contact.aspx");
        }

        protected void Aboutbtn_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.Redirect("About.aspx");
        }


    }
}