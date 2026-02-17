// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var a = 10;
Console.WriteLine(a);

// test data
var b = new Book();
b.Id = 12;
b.Author = "Paulo";
b.ISBN = "987654321";
b.Pages = 200;
b.Price = 9.99m;
b.PublishedDate = DateTime.Now;
b.Title = "Alchemist";
Console.WriteLine(b.ToString());
