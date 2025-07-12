using Microsoft.EntityFrameworkCore;
using StoryPlannerApi.Entities;

namespace StoryPlannerApi;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // Define DbSets for your entities here
    // public DbSet<YourEntity> YourEntities { get; set; }
    public DbSet<Tag> Tags { get; set; } = null!;
    public DbSet<Story> Stories { get; set; } = null!;
    public DbSet<StoryTag> StoryTags { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //? Need this?
        //base.OnModelCreating(modelBuilder);
        // Configure all entity mappings here
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}