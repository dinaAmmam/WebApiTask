using CoreLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DbContextLayer
{
    public class AppDbContext:DbContext 
    {
        public AppDbContext(DbContextOptions con):base(con) 
        { 
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<StudentCourse>().HasKey(c => new { c.StudentId, c.CourseId });
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentsCourse { get; set;}
    }
}
