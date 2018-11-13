using MovieIdeas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MovieIdeas.DAL
{
    public class MovieIdeasContext:DbContext
    {
        public MovieIdeasContext() : base("MovieIdeasContext") {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Theater> Theaters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}