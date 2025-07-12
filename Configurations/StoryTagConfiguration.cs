using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoryPlannerApi.Entities;

namespace StoryPlannerApi.Configurations;

public class StoryTagConfiguration : IEntityTypeConfiguration<StoryTag>
{
    public void Configure(EntityTypeBuilder<StoryTag> builder)
    {
        builder.Property(e => e.StoryId).IsRequired();
        builder.Property(e => e.TagId).IsRequired();
    }
}
