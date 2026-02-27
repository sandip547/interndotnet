using System.ComponentModel.DataAnnotations;

namespace interndotnet.Models;

public class Quote
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(500)]
    public string Text { get; set; }

    [Required]
    [MaxLength(100)]
    public string Author { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Quote() { }

    public Quote(int id, string text, string author)
    {
        Id = id;
        Text = text;
        Author = author;
        CreatedAt = DateTime.UtcNow;
    }

    public override string ToString()
    {
        return $"Quote [Id={Id}, Text={Text}, Author={Author}, CreatedAt={CreatedAt:yyyy-MM-dd HH:mm:ss}]";
    }
}