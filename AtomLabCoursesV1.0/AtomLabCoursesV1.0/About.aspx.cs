using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtomLabCoursesV1._0
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CoursesDataBaseEntities CDBE = new CoursesDataBaseEntities();
                About about = new About();
                about = (from o in CDBE.Abouts select o).Single();
                Thumb.ImageUrl = "Images/AboutImage/" + about.Image;
                HiddenFormImage.ImageUrl = "Images/AboutImage/" + about.Image;
                TextTitle.InnerHtml = about.Title;
                TextDetails.InnerHtml = about.Details;
            }
            catch(Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in About Page: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
            }
        }
    }
}