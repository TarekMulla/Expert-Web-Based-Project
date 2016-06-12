using AtomLabCoursesV1._0.DataBaseLayer;
using AtomLabCoursesV1._0.Expert_System_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace AtomLabCoursesV1._0
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Expert_System.Run_Inference_Engine_For_Calculate_Priority();
        }

        void Session_Start(object sender, EventArgs e)
        {

        }
    }
}