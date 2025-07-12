namespace StoryPlannerApi.Entities;

public class StoryTag
{
    public int StoryTagId { get; set; }
    public int StoryId { get; set; }
    public int TagId { get; set; }
    public Story Story { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}
