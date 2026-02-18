using System.ComponentModel.DataAnnotations;

namespace interndotnet.Models;

public class User
{   
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MaxLength(100)]
    public string Password { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public User() { }
 
    public User(int id, string firstName, string lastName, string email, string password, DateTime? createdAt = null)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedAt = createdAt ?? DateTime.UtcNow;
    }

    public override string ToString()
    {
        return $"User[Id={Id}, Name={FirstName} {LastName}, Email={Email}, CreatedAt={CreatedAt:yyyy-MM-dd HH:mm:ss}]";
    }

  
}
