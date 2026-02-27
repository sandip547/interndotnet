using interndotnet.Data;
using interndotnet.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace interndotnet.Services;

public class BookService : IBookService
{
    private readonly AppDbContext _context;

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<Book> CreateAsync(Book book)
    {
        book.PublishedDate = book.PublishedDate == default ? DateTime.UtcNow : book.PublishedDate;

        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<Book> UpdateAsync(int id, Book book)
    {
        var existingBook = await _context.Books.FindAsync(id);
        if (existingBook == null)
            return null;

        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.ISBN = book.ISBN;
        existingBook.Price = book.Price;
        existingBook.PublishedDate = book.PublishedDate;
        existingBook.Pages = book.Pages;

        await _context.SaveChangesAsync();
        return existingBook;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
            return false;

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return true;
    }
}