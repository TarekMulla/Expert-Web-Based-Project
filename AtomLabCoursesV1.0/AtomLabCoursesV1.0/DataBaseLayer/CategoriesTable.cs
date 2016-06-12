using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AtomLabCoursesV1._0.DataBaseLayer
{
    public class CategoriesTable
    {
        public static CoursesDataBaseEntities CDBE = new CoursesDataBaseEntities();

        public static List<Category> SelectAll()
        {
            List<Category> categories = new List<Category>();
            try
            {
                categories = (from o in CDBE.Categories select o).ToList<Category>();
                return categories;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }
        }

        public static Category Select(int id)
        {
            Category category = null;
            try
            {
                category = (from o in CDBE.Categories where o.ID == id select o).Single();
                return category;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static int Insert(string name = "", string image = "", string description = "")
        {
            try
            {
                Category new_category = new Category
                {
                    Name = name,
                    Image = image,
                    Description = description
                };
                CDBE.Categories.Add(new_category);
                CDBE.SaveChanges();
                return new_category.ID;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return -1;
            }
        }

        public static int Update(int id, string name, string image, string description)
        {
            try
            {
                Category category = (from o in CDBE.Categories where o.ID == id select o).Single();
                if (category == null)
                {
                    return Insert(name, image, description);
                }
                category.Name = name;
                category.Image = image;
                category.Description = description;

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
                Category category = (from o in CDBE.Categories where o.ID == id select o).Single();
                if (category == null) return false;

                List<Course> courses = CoursesTable.SelectAll();
                foreach (Course c in courses)
                {
                    if(c.Field == id)
                        CoursesTable.Delete(c.ID);
                }

                List<UsersExpert> usersExpert = UsersExpertTable.SelectAll();
                foreach (UsersExpert expert in usersExpert)
                {
                    if (expert.CategoryID == id)
                        UsersExpertTable.Delete(expert.ID);
                }

                CDBE.Categories.Remove(category);
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