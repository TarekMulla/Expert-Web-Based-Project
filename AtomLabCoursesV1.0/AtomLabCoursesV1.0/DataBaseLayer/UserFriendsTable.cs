using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AtomLabCoursesV1._0.DataBaseLayer
{
    public class UserFriendsTable
    {
        public static CoursesDataBaseEntities CDBE = new CoursesDataBaseEntities();

        public static List<UserFriend> SelectAll()
        {
            List<UserFriend> userfriends = new List<UserFriend>();
            try
            {
                userfriends = (from o in CDBE.UserFriends select o).ToList<UserFriend>();
                return userfriends;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }
        }

        public static UserFriend Select(int id)
        {
            UserFriend userfriend = null;
            try
            {
                userfriend = (from o in CDBE.UserFriends where o.ID == id select o).Single();
                return userfriend;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }
        }

        public static int Insert(int friendID, int priority)
        {
            try
            {
                UserFriend new_userfriend = new UserFriend
                {
                    FriendID = friendID,
                    Priority = priority
                };
                CDBE.UserFriends.Add(new_userfriend);
                CDBE.SaveChanges();
                return new_userfriend.ID;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return -1;
            }
        }

        public static int Update(int id, int friendID, int priority)
        {
            try
            {
                UserFriend userfriend = (from o in CDBE.UserFriends where o.ID == id select o).Single();
                if (userfriend == null)
                {
                    return Insert(friendID, priority);
                }
                userfriend.FriendID = friendID;
                userfriend.Priority = priority;

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
                UserFriend userfriend = (from o in CDBE.UserFriends where o.ID == id select o).Single();
                if (userfriend == null) return false;

                //List<ProductDV> productDVs = ProductLogic.GetProductsBySection(newsCatDV.ID);

                //if (productDVs != null)
                //{
                //    for (int j = 0; j < productDVs.Count; j++)
                //    {
                //        ProductLogic.DeleteProduct(productDVs[j].ID);
                //    }
                //}

                CDBE.UserFriends.Remove(userfriend);
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
                List<UserFriend> userfriends = (from o in CDBE.UserFriends select o).ToList<UserFriend>();
                if (userfriends == null) return false;
                foreach(UserFriend user in userfriends)
                    CDBE.UserFriends.Remove(user);
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