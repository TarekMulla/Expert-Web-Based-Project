using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AtomLabCoursesV1._0.DataBaseLayer
{
    public class UsersExpertTable
    {
        public static CoursesDataBaseEntities CDBE = new CoursesDataBaseEntities();

        public static List<UsersExpert> SelectAll()
        {
            List<UsersExpert> expert = new List<UsersExpert>();
            try
            {
                expert = (from o in CDBE.UsersExperts select o).ToList<UsersExpert>();
                return expert;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }
        }

        public static UsersExpert Select(int id)
        {
            UsersExpert expert = null;
            try
            {
                expert = (from o in CDBE.UsersExperts where o.ID == id select o).Single();
                return expert;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }
        }

        public static int Insert(int categoryID, int userID, int experting)
        {
            try
            {
                UsersExpert new_expert = new UsersExpert
                {
                    CategoryID = categoryID,
                    UserID = userID,
                    Expert = experting
                };
                CDBE.UsersExperts.Add(new_expert);
                CDBE.SaveChanges();
                return new_expert.ID;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return -1;
            }
        }

        public static int Update(int id, int categoryID, int userID, int experting)
        {
            try
            {
                UsersExpert expert = (from o in CDBE.UsersExperts where o.ID == id select o).Single();
                if (expert == null)
                {
                    return Insert(categoryID, userID, experting);
                }
                expert.CategoryID = categoryID;
                expert.UserID = userID;
                expert.Expert = experting;

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
                UsersExpert expert = (from o in CDBE.UsersExperts where o.ID == id select o).Single();
                if (expert == null) return false;

                //List<ProductDV> productDVs = ProductLogic.GetProductsBySection(newsCatDV.ID);

                //if (productDVs != null)
                //{
                //    for (int j = 0; j < productDVs.Count; j++)
                //    {
                //        ProductLogic.DeleteProduct(productDVs[j].ID);
                //    }
                //}

                CDBE.UsersExperts.Remove(expert);
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