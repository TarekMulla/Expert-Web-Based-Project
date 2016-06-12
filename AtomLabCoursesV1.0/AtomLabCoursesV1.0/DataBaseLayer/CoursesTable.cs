using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AtomLabCoursesV1._0.DataBaseLayer
{
    public class CoursesTable
    {
        public static CoursesDataBaseEntities CDBE = new CoursesDataBaseEntities();

        public static List<Course> SelectAll()
        {
            List<Course> courses = new List<Course>();
            try
            {
                courses = (from o in CDBE.Courses select o).ToList<Course>();
                return courses;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<Course> SelectAllOrderdByPriority()
        {
            List<Course> courses = new List<Course>();
            try
            {
                courses = (from o in CDBE.Courses orderby o.Priority descending select o).ToList<Course>();
                return courses;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }
        }

        public static Course Select(int id)
        {
            Course course = null;
            try
            {
                //newsDV = (from o in DREE.NewsDVs orderby o.DATE descending select o).Skip<NewsDV>(skip).Take<NewsDV>(take).ToList<NewsDV>();
                //newsDV = (from o in DREE.NewsDVs orderby o.DATE descending select o).Take<NewsDV>(take).ToList<NewsDV>();
                //newsDVs = (from o in DREE.NewsDVs where o.DATE == date orderby o.DATE descending select o).ToList<NewsDV>();
                course = (from o in CDBE.Courses where o.ID == id select o).Single();
                return course;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }
        }

        public static Course Select(string course_name)
        {
            Course course = null;
            try
            {
                //newsDV = (from o in DREE.NewsDVs orderby o.DATE descending select o).Skip<NewsDV>(skip).Take<NewsDV>(take).ToList<NewsDV>();
                //newsDV = (from o in DREE.NewsDVs orderby o.DATE descending select o).Take<NewsDV>(take).ToList<NewsDV>();
                //newsDVs = (from o in DREE.NewsDVs where o.DATE == date orderby o.DATE descending select o).ToList<NewsDV>();
                course = (from o in CDBE.Courses where o.Name == course_name select o).Single();
                return course;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }
        }

        public static int Insert(string name = "", string teacher = "",  int field = 1, int courseLevel = 0, int hours = 0, string image = "", string details = "", int rate =0)
        {
            try
            {
                Course new_course = new Course
                {
                    Name = name,            Teacher = teacher,
                    Field = field,          CourseLevel = courseLevel,
                    HoursNumber = hours,    Image = image,
                    Details = details,      Rate = rate
                };
                CDBE.Courses.Add(new_course);
                CDBE.SaveChanges();
                return new_course.ID;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return -1;
            }
        }

        public static int Update(int id, string name, string teacher, int field, int hardLevel, int hours, string image, string details, int rate)
        {
            try
            {
                Course course = (from o in CDBE.Courses where o.ID == id select o).Single();
                if (course == null)
                {
                    return Insert(name, teacher, field, hardLevel, hours, image, details, rate);
                }
                course.Name = name;
                course.Teacher = teacher;
                course.Field = field;
                course.CourseLevel = hardLevel;
                course.HoursNumber = hours;
                course.Image = image;
                course.Details = details;
                course.Rate = rate;

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

        public static int Update_Rate(int id, int rate)
        {
            try
            {
                Course course = (from o in CDBE.Courses where o.ID == id select o).Single();
                course.Rate = rate;
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

        public static int Update_Priority(int id, int priority)
        {
            try
            {
                Course course = (from o in CDBE.Courses where o.ID == id select o).Single();
                course.Priority = priority;
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
                Course course = (from o in CDBE.Courses where o.ID == id select o).Single();
                if (course == null) return false;

                List<Rate> rates = RatesTable.SelectAll();
                foreach (Rate rate in rates)
                {
                    if (rate.CourseID == id)
                        RatesTable.Delete(rate.ID);
                }

                CDBE.Courses.Remove(course);
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