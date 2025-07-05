using Microsoft.EntityFrameworkCore;
using StoryPlannerApi.Entities;

namespace StoryPlannerApi;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    // Define DbSets for your entities here
    // public DbSet<YourEntity> YourEntities { get; set; }
    public DbSet<Tags> Tags { get; set; } = null!;
}