﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AtomLabCoursesV1._0
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CoursesDataBaseEntities : DbContext
    {
        public CoursesDataBaseEntities()
            : base("name=CoursesDataBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActualRating> ActualRatings { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CoursesPriority> CoursesPriorities { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserFriend> UserFriends { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersExpert> UsersExperts { get; set; }
        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<MainImage> MainImages { get; set; }
    }
}
