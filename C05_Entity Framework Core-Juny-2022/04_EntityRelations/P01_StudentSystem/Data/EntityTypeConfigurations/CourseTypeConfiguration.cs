namespace P01_StudentSystem.Data.EntityTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P01_StudentSystem.Data.Models;

    public class CourseTypeConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .HasMany(c => c.HomeworkSubmissions)
                .WithOne(h => h.Course)
                .HasForeignKey(h => h.CourseId);
        }
    }
}
