using DevDanApi.Domain.Common;

namespace DevDanApi.Domain.Entities;

public class Blog : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
    public List<Comment> Comments { get; set; } = new();
}
