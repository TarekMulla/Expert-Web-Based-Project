using NxBRE.InferenceEngine.Rules;
using AtomLabCoursesV1._0.DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtomLabCoursesV1._0.Expert_System_Layer
{
    public class Rules
    {
        static public void insert_User_Friends(InferenceEngine IE)
        {
            UserFriendsTable.DeleteAll();
            List<Fact> userfriends = IE.Run_Query("Get User Friend");
            foreach(Fact fact in userfriends)
            {
                int friendid = UsersTable.Select(fact.PredicateValues[0].ToString()).ID;
                int priority = Convert.ToInt32(fact.PredicateValues[1]);
                UserFriendsTable.Insert(friendid, priority);
            }
        }
        
        static public void insert_Expert_Friends(InferenceEngine IE)
        {
            UserFriendsTable.DeleteAll();
            List<Fact> userfriends = IE.Run_Query("Get expert person");
            foreach(Fact fact in userfriends)
            {
                int friendid = UsersTable.Select(fact.PredicateValues[0].ToString()).ID;
                int priority = Convert.ToInt32(fact.PredicateValues[1]);
                UserFriendsTable.Insert(friendid, priority);
            }
        }

        static public void insert_Actual_Rating(InferenceEngine IE)
        {
            ActualRatingTable.DeleteAll();
            List<Fact> actualrating = IE.Run_Query("Get Actual Rating");
            foreach (Fact fact in actualrating)
            {
                int courseid = CoursesTable.Select(fact.PredicateValues[1].ToString()).ID;
                int rating = Convert.ToInt32(fact.PredicateValues[2]);
                ActualRatingTable.Insert(courseid, rating);
            }
        }

        static public void insert_Course_Priority(InferenceEngine IE)
        {
            foreach(Course course in CoursesTable.SelectAll())
                CoursesTable.Update_Priority(course.ID, 0);
            CoursesPriorityTable.DeleteAll();
            List<Fact> coursespriority = IE.Run_Query("Get Courses Priority");
            foreach (Fact fact in coursespriority)
            {
                int courseid = CoursesTable.Select(fact.PredicateValues[0].ToString()).ID;
                int priority = Convert.ToInt32(fact.PredicateValues[1]);
                CoursesTable.Update_Priority(courseid, priority);
            }
        }
    
        static public void insert_Final_Rating(InferenceEngine IE)
        {
            List<ActualRating> actualrates = ActualRatingTable.SelectAll();
            List<Course> courses = CoursesTable.SelectAll();
            int Final_rating = 0;
            foreach (Course course in courses)
            {
                int sum = 0;
                int i = 0;
                foreach (ActualRating rate in actualrates)
                {
                    if (rate.CourseID == course.ID)
                    {
                        sum += rate.Rate;
                        i++;
                    }
                }
                Final_rating = Convert.ToInt32(Math.Round((double)sum / (double)(i == 0 ? 1 : i)));
                CoursesTable.Update_Rate(course.ID, Final_rating);
            }
        }
    }
}