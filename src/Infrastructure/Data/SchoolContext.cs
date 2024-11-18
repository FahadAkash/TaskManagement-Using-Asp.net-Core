using Microsoft.EntityFrameworkCore;
using WEBAPITEST.src.Application.Core.Models;
using WEBAPITEST.src.Application.Core.Models.StudentManagementSystemModels;
using MainTask = WEBAPITEST.src.Application.Core.Models.MainTask;

namespace WEBAPITEST.src.Infrastructure.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
       /* public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<MainTask> Tasks { get; set; }*/
        public DbSet<TaskModel> taskModels { get; set; }    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
