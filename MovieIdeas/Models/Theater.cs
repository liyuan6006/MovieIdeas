using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieIdeas.Models
{
    public class Theater
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TheaterID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}