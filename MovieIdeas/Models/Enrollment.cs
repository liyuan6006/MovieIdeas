using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieIdeas.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int TheaterID { get; set; }
        public int MovieID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Theater Theater { get; set; }
        public virtual Movie Movie { get; set; }
    }
}