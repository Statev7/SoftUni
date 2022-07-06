namespace P01_StudentSystem.Data.EntityTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P01_StudentSystem.Data.Models;

    public class StudentTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasMany(s => s.HomeworkSubmissions)
                .WithOne(h => h.Student)
                .HasForeignKey(h => h.StudentId);
        }
    }
}
