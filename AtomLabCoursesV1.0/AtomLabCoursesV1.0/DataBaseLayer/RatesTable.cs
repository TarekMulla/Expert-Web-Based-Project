using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AtomLabCoursesV1._0.DataBaseLayer
{
    public class RatesTable
    {
        public static CoursesDataBaseEntities CDBE = new CoursesDataBaseEntities();

        public static List<Rate> SelectAll()
        {
            List<Rate> categories = new List<Rate>();
            try
            {
                categories = (from o in CDBE.Rates select o).ToList<Rate>();
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

        public static Rate Select(int id)
        {
            Rate rate = null;
            try
            {
                rate = (from o in CDBE.Rates where o.ID == id select o).Single();
                return rate;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }
        }

        public static int Insert(int courseID, int userID , int rating)
        {
            try
            {
                Rate new_category = new Rate
                {
                    CourseID = courseID,
                    UserID = userID,
                    UserRate = rating
                };
                CDBE.Rates.Add(new_category);
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

        public static int Update(int id, int courseID, int userID, int rating)
        {
            try
            {
                Rate rate = (from o in CDBE.Rates where o.ID == id select o).Single();
                if (rate == null)
                {
                    return Insert(courseID, userID, rating);
                }
                rate.CourseID = courseID;
                rate.UserID = userID;
                rate.UserRate = rating;

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
                Rate rate = (from o in CDBE.Rates where o.ID == id select o).Single();
                if (rate == null) return false;

                //List<ProductDV> productDVs = ProductLogic.GetProductsBySection(newsCatDV.ID);

                //if (productDVs != null)
                //{
                //    for (int j = 0; j < productDVs.Count; j++)
                //    {
                //        ProductLogic.DeleteProduct(productDVs[j].ID);
                //    }
                //}

                CDBE.Rates.Remove(rate);
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