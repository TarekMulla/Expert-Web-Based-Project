using AtomLabCoursesV1._0.DataBaseLayer;
using NxBRE.InferenceEngine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtomLabCoursesV1._0.Expert_System_Layer
{
    public class Facts
    {
        static public void Add_All_Facts(InferenceEngine IE)
        {
            List<Course> courses = CoursesTable.SelectAll();
            foreach (Course course in courses)
            {
                Facts.Add_Course_Fact(IE, course);
                Facts.Add_Category_Fact(IE, course);
                Facts.Add_Level_Fact(IE, course);
            }

            List<User> users = UsersTable.SelectAll();
            foreach (User user in users)
                Facts.Add_User_Fact(IE, user);

            List<UsersExpert> user_expert = UsersExpertTable.SelectAll();
            foreach (UsersExpert expert in user_expert)
                Facts.Add_User_Expert_Fact(IE, expert);

            List<Rate> rates = RatesTable.SelectAll();
            foreach (Rate rate in rates)
                Facts.Add_Rate_Fact(IE, rate);
        }

        static public void Add_Course_Fact(InferenceEngine IE, Course course)
        {
            string ID = "Course" + course.ID.ToString();
            Individual[] individuals = new Individual[1] { new Individual(course.Name.ToLower()) };
            Atom atom = new Atom("COURSE", individuals);
            Fact fact = new Fact(ID, atom);
            IE.Add_Fact(fact, ID);
        }

        static public void Add_User_Signin_Fact(InferenceEngine IE, string user)
        {
            string ID = "Signin User";
            Individual[] individuals = new Individual[1] { new Individual(user.ToLower()) };
            Atom atom = new Atom("SIGNIN USER", individuals);
            Fact fact = new Fact(ID, atom);
            IE.Add_Fact(fact, ID);
        }

        static public void Add_User_Fact(InferenceEngine IE, User user)
        {
            string ID = "User" + user.ID.ToString();
            Individual[] individuals = new Individual[1] { new Individual(user.UserName.ToLower()) };
            Atom atom = new Atom("USER", individuals);
            Fact fact = new Fact(ID, atom);
            IE.Add_Fact(fact, ID);
        }

        static public void Add_Category_Fact(InferenceEngine IE, Course course)
        {
            string ID = "Category" + course.ID.ToString();
            string Category = CategoriesTable.Select(course.Field.Value).Name.ToLower();
            Individual[] individuals = new Individual[2] { new Individual(course.Name.ToLower()), new Individual(Category,"int") };
            Atom atom = new Atom("CATEGORY", individuals);
            Fact fact = new Fact(ID, atom);
            IE.Add_Fact(fact, ID);
        }

        static public void Add_User_Expert_Fact(InferenceEngine IE, UsersExpert user_expert)
        {
            string ID = "User Expert" + user_expert.ID.ToString();
            string User_Name = UsersTable.Select(user_expert.UserID).UserName.ToLower();
            string Expert_Category = CategoriesTable.Select(user_expert.CategoryID).Name.ToLower();
            int Expert = user_expert.Expert;
            Individual[] individuals = new Individual[3] { new Individual(User_Name), new Individual(Expert_Category), new Individual(Expert, "int") };
            Atom atom = new Atom("USER EXPERT", individuals);
            Fact fact = new Fact(ID, atom);
            IE.Add_Fact(fact, ID);
        }

        static public void Add_Level_Fact(InferenceEngine IE, Course course)
        {
            string ID = "Level" + course.ID.ToString();
            int Level = course.CourseLevel.Value;
            Individual[] individuals = new Individual[2] { new Individual(course.Name.ToLower()), new Individual(Level, "int") };
            Atom atom = new Atom("LEVEL", individuals);
            Fact fact = new Fact(ID, atom);
            IE.Add_Fact(fact, ID);
        }

        static public void Add_Rate_Fact(InferenceEngine IE, Rate rate)
        {
            string ID = "Rate" + rate.ID.ToString();
            string User = UsersTable.Select(rate.UserID).UserName.ToLower();
            string Course = CoursesTable.Select(rate.CourseID).Name.ToLower();
            int Level = rate.UserRate;
            Individual[] individuals = new Individual[3] { new Individual(User), new Individual(Course), new Individual(Level,"int") };
            Atom atom = new Atom("RATE", individuals);
            Fact fact = new Fact(ID, atom);
            IE.Add_Fact(fact, ID);
        }

        static public void Add_Final_Rate_Fact(InferenceEngine IE, Course course)
        {
            string ID = "Final Rate" + course.ID.ToString();
            string Course = course.Name.ToLower();
            int final_rate = course.Rate.Value;
            Individual[] individuals = new Individual[2] { new Individual(Course), new Individual(final_rate, "int") };
            Atom atom = new Atom("FINAL RATE", individuals);
            Fact fact = new Fact(ID, atom);
            IE.Add_Fact(fact, ID);
        }
    
    }
}