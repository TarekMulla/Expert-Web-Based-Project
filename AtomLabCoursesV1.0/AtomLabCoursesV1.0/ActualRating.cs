//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ActualRating
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int Rate { get; set; }
    
        public virtual Course Cours { get; set; }
    }
}
