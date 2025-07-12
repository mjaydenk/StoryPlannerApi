namespace StoryPlannerApi.Entities;

public class Story: BaseEntity
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
}
