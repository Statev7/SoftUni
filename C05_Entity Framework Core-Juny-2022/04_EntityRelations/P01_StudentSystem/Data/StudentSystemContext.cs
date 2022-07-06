namespace P01_StudentSystem.Data
{
    using System.Reflection;

    using Microsoft.EntityFrameworkCore;

    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public StudentSystemContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
