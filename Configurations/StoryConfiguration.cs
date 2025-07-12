using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoryPlannerApi.Entities;

namespace StoryPlannerApi.Configurations;

public class StoryConfiguration : IEntityTypeConfiguration<Story>
{
    public void Configure(EntityTypeBuilder<Story> builder)
    {
        builder.Property(e => e.Title).IsRequired()
            .HasMaxLength(500);
        builder.Property(e => e.Description).HasMaxLength(2000);
    }
}
