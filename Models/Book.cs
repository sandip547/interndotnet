using System.ComponentModel.DataAnnotations;

public class Book
{   
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public decimal Price { get; set; }
    public DateTime PublishedDate { get; set; }
    public int Pages { get; set; }

    public Book() {}
    
    public Book(int id, string title, string author, string isbn,
        decimal price, DateTime publishedDate, int pages)
    {
        Id = id;
        Title = title;
        Author = author;
        ISBN = isbn;
        Price = price;
        PublishedDate = publishedDate;
        Pages = pages;
    }
    public override string ToString()
    {
        return $"Book [Id={Id}, Title={Title}, Author={Author}, ISBN={ISBN}, " +
               $"Price={Price:C}, PublishedDate={PublishedDate:yyyy-MM-dd}, Pages={Pages}]";
    }
}