using interndotnet.Data;
using interndotnet.Models;
using interndotnet.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace interndotnet.Services;

public class QuoteService : IQuoteService
{
    private readonly AppDbContext _context;

    public QuoteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Quote>> GetAllAsync()
    {
        return await _context.Quotes.ToListAsync();
    }

    public async Task<Quote> GetByIdAsync(int id)
    {
        return await _context.Quotes.FindAsync(id);
    }

    public async Task<Quote> CreateAsync(Quote quote)
    {
        if (quote.CreatedAt == default || quote.CreatedAt.Kind != DateTimeKind.Utc)
        {
            quote.CreatedAt = DateTime.UtcNow;
        }

        _context.Quotes.Add(quote);
        await _context.SaveChangesAsync();
        return quote;
    }

    public async Task<Quote> UpdateAsync(int id, Quote quote)
    {
        var existingQuote = await _context.Quotes.FindAsync(id);
        if (existingQuote == null)
            return null;

        existingQuote.Text = quote.Text;
        existingQuote.Author = quote.Author;

        await _context.SaveChangesAsync();
        return existingQuote;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var quote = await _context.Quotes.FindAsync(id);
        if (quote == null)
            return false;

        _context.Quotes.Remove(quote);
        await _context.SaveChangesAsync();
        return true;
    }
}