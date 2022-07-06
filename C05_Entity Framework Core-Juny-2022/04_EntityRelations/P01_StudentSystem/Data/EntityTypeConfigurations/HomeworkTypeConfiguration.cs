namespace P01_StudentSystem.Data.EntityTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P01_StudentSystem.Data.Models;

    public class HomeworkTypeConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder
                .Property(h => h.Content)
                .IsUnicode(false);
        }
    }
}
