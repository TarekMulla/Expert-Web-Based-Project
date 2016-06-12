using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AtomLabCoursesV1._0.DataBaseLayer
{
    public class UsersTable
    {
        public static CoursesDataBaseEntities CDBE = new CoursesDataBaseEntities();

        public static List<User> SelectAll()
        {
            List<User> user = new List<User>();
            try
            {
                user = (from o in CDBE.Users select o).ToList<User>();
                return user;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }
        }

        public static User Select(int id)
        {
            User user = null;
            try
            {
                user = (from o in CDBE.Users where o.ID == id select o).Single();
                return user;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }
        }

        public static User Select(string UserName)
        {
            try
            {
                User user = (from o in CDBE.Users where o.UserName == UserName select o).Single();
                return user;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return null;
            }

        }

        public static int Insert(string firstname="", string lastname="",string username=" ",string password=" ",string email="",string job="",string fieldInterest="")
        {
            try
            {
                User new_user = new User
                {
                    FirstName = firstname,
                    LastName = lastname,
                    UserName = username,
                    Password = password,
                    Email = email,
                    Job = job,
                    FieldInterest = fieldInterest
                };
                CDBE.Users.Add(new_user);
                CDBE.SaveChanges();
                return new_user.ID;
            }
            catch (Exception ex)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Admin/Error File.txt");
                File.AppendAllText(Path, "Error in Data base: " + DateTime.Now.ToString() + "\r\n" + ex.Message
                    + "\n-----------------------------------------------------------------------------------\n");
                return -1;
            }
        }

        public static int Update(int id, string firstname, string lastname, string username, string password, string email, string job, string fieldInterest)
        {
            try
            {
                User user = (from o in CDBE.Users where o.ID == id select o).Single();
                if (user == null)
                {
                    return Insert(firstname, lastname, username, password, email, job, fieldInterest);
                }
                user.FirstName = firstname;
                user.LastName = lastname;
                user.UserName = username;
                user.Password = password;
                user.Email = email;
                user.Job = job;
                user.FieldInterest = fieldInterest;

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
                User user = (from o in CDBE.Users where o.ID == id select o).Single();
                if (user == null) return false;

                List<Rate> rates = RatesTable.SelectAll();
                foreach (Rate rate in rates)
                {
                    if (rate.UserID == id)
                        RatesTable.Delete(rate.ID);
                }

                List<UsersExpert> usersExpert = UsersExpertTable.SelectAll();
                foreach (UsersExpert expert in usersExpert)
                {
                    if (expert.UserID == id)
                        UsersExpertTable.Delete(expert.ID);
                }

                CDBE.Users.Remove(user);
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