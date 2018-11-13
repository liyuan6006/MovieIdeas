using MovieIdeas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieIdeas.DAL
{
    public class MovieIdeasInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<MovieIdeasContext>
    {
        protected override void Seed(MovieIdeasContext context)
        {
            var movies = new List<Movie>
            {
            new Movie{Name="Carson",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Movie{Name="Meredith",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Movie{Name="Arturo",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Movie{Name="Gytis",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Movie{Name="Yan",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Movie{Name="Peggy",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Movie{Name="Laura",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Movie{Name="Nino",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

            movies.ForEach(s => context.Movies.Add(s));
            context.SaveChanges();
            var theaters = new List<Theater>
            {
            new Theater{TheaterID=1050,Title="Chemistry"},
            new Theater{TheaterID=4022,Title="Microeconomics"},
            new Theater{TheaterID=4041,Title="Macroeconomics"},
            new Theater{TheaterID=1045,Title="Calculus"},
            new Theater{TheaterID=3141,Title="Trigonometry"},
            new Theater{TheaterID=2021,Title="Composition"},
            new Theater{TheaterID=2042,Title="Literature"}
            };
            theaters.ForEach(s => context.Theaters.Add(s));
            context.SaveChanges();
            var enrollments = new List<Enrollment>
            {
            new Enrollment{MovieID=1,TheaterID=1050,Grade=Grade.A},
            new Enrollment{MovieID=1,TheaterID=4022,Grade=Grade.C},
            new Enrollment{MovieID=1,TheaterID=4041,Grade=Grade.B},
            new Enrollment{MovieID=2,TheaterID=1045,Grade=Grade.B},
            new Enrollment{MovieID=2,TheaterID=3141,Grade=Grade.F},
            new Enrollment{MovieID=2,TheaterID=2021,Grade=Grade.F},
            new Enrollment{MovieID=3,TheaterID=1050},
            new Enrollment{MovieID=4,TheaterID=1050,},
            new Enrollment{MovieID=4,TheaterID=4022,Grade=Grade.F},
            new Enrollment{MovieID=5,TheaterID=4041,Grade=Grade.C},
            new Enrollment{MovieID=6,TheaterID=1045},
            new Enrollment{MovieID=7,TheaterID=3141,Grade=Grade.A},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}