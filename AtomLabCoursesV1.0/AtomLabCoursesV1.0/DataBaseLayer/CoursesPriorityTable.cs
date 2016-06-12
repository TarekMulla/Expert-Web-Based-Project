using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AtomLabCoursesV1._0.DataBaseLayer
{
    public class CoursesPriorityTable
    {
        public static CoursesDataBaseEntities CDBE = new CoursesDataBaseEntities();

        public static List<CoursesPriority> SelectAll()
        {
            List<CoursesPriority> coursespriority = new List<CoursesPriority>();
            try
            {
                coursespriority = (from o in CDBE.CoursesPriorities select o).ToList<CoursesPriority>();
                return coursespriority;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }
        }

        public static CoursesPriority Select(int id)
        {
            CoursesPriority coursespriority = null;
            try
            {
                coursespriority = (from o in CDBE.CoursesPriorities where o.ID == id select o).Single();
                return coursespriority;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }
        }

        public static int Insert(int courseID, int priority)
        {
            try
            {
                CoursesPriority new_coursespriority = new CoursesPriority
                {
                    CourseID = courseID,
                    Priority = priority
                };
                CDBE.CoursesPriorities.Add(new_coursespriority);
                CDBE.SaveChanges();
                return new_coursespriority.ID;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return -1;
            }
        }

        public static int Update(int id, int courseID, int priority)
        {
            try
            {
                CoursesPriority coursespriority = (from o in CDBE.CoursesPriorities where o.ID == id select o).Single();
                if (coursespriority == null)
                {
                    return Insert(courseID, priority);
                }
                coursespriority.CourseID = courseID;
                coursespriority.Priority = priority;

                CDBE.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return -1;
            }
        }

        public static bool Delete(int id)
        {
            try
            {
                CoursesPriority coursespriority = (from o in CDBE.CoursesPriorities where o.ID == id select o).Single();
                if (coursespriority == null) return false;

                //List<ProductDV> productDVs = ProductLogic.GetProductsBySection(newsCatDV.ID);

                //if (productDVs != null)
                //{
                //    for (int j = 0; j < productDVs.Count; j++)
                //    {
                //        ProductLogic.DeleteProduct(productDVs[j].ID);
                //    }
                //}

                CDBE.CoursesPriorities.Remove(coursespriority);
                CDBE.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return false;
            }
        }

        public static bool DeleteAll()
        {
            try
            {
                List<CoursesPriority> coursespriority = (from o in CDBE.CoursesPriorities select o).ToList<CoursesPriority>();
                if (coursespriority == null) return false;
                foreach (CoursesPriority priority in coursespriority)
                    CDBE.CoursesPriorities.Remove(priority);
                CDBE.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return false;
            }
        }
    }
}