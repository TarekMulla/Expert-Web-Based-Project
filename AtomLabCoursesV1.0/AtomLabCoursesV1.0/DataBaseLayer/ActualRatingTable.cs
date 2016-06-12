using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AtomLabCoursesV1._0.DataBaseLayer
{
    public class ActualRatingTable
    {
        public static CoursesDataBaseEntities CDBE = new CoursesDataBaseEntities();

        public static List<ActualRating> SelectAll()
        {
            List<ActualRating> ActualRates = new List<ActualRating>();
            try
            {
                ActualRates = (from o in CDBE.ActualRatings select o).ToList<ActualRating>();
                return ActualRates;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }
        }

        public static ActualRating Select(int id)
        {
            ActualRating actualrate = null;
            try
            {
                actualrate = (from o in CDBE.ActualRatings where o.ID == id select o).Single();
                return actualrate;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in About Page: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }
        }

        public static int Insert(int courseID, int rating)
        {
            try
            {
                ActualRating new_rate = new ActualRating
                {
                    CourseID = courseID,
                    Rate = rating
                };
                CDBE.ActualRatings.Add(new_rate);
                CDBE.SaveChanges();
                return new_rate.ID;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return -1;
            }
        }

        public static int Update(int id, int courseID, int rating)
        {
            try
            {
                ActualRating actualrate = (from o in CDBE.ActualRatings where o.ID == id select o).Single();
                if (actualrate == null)
                {
                    return Insert(courseID, rating);
                }
                actualrate.CourseID = courseID;
                actualrate.Rate = rating;

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
                ActualRating actualrate = (from o in CDBE.ActualRatings where o.ID == id select o).Single();
                if (actualrate == null) return false;

                //List<ProductDV> productDVs = ProductLogic.GetProductsBySection(newsCatDV.ID);

                //if (productDVs != null)
                //{
                //    for (int j = 0; j < productDVs.Count; j++)
                //    {
                //        ProductLogic.DeleteProduct(productDVs[j].ID);
                //    }
                //}

                CDBE.ActualRatings.Remove(actualrate);
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
                List<ActualRating> actualrates = (from o in CDBE.ActualRatings select o).ToList<ActualRating>();
                if (actualrates == null) return false;
                foreach (ActualRating rate in actualrates)
                    CDBE.ActualRatings.Remove(rate);
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