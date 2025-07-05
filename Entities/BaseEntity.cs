namespace StoryPlannerApi.Entities;

public class BaseEntity
{
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set; } = null;
    public DateTime? DisabledDate { get; set; }
    public string? DisabledBy { get; set; } = null;
    public DateTime? DeletedDate { get; set; }
    public string? DeletedBy { get; set; } = null;
}
