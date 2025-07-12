namespace StoryPlannerApi.Entities;

public class Tag: BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
