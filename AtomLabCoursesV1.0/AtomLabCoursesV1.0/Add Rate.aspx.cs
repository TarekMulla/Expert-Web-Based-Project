using AtomLabCoursesV1._0.DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtomLabCoursesV1._0
{
    public partial class Add_Rate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                int userid = UsersTable.Select(Session["User"].ToString()).ID;
                int courseid = CoursesTable.Select(Session["course"].ToString()).ID;
                int rate = int.Parse(Request["rate"]);
                RatesTable.Insert(courseid, userid, rate);
                Response.Write("Successful Rating user=" + Session["User"]  + " course=" + Session["course"] + " rate=" + Request["rate"]);
            }
        }
    }
}