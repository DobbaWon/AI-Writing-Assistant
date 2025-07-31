namespace MyApi.Models;

public class PromptEntry
{
    public int Id { get; set; }

    public string Prompt { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;

    public DateTime LastModified { get; set; } = DateTime.UtcNow;
}
