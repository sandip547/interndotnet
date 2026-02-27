using interndotnet.Models;

namespace interndotnet.Services.Interfaces;

public interface IQuoteService
{
    Task<IEnumerable<Quote>> GetAllAsync();
    Task<Quote> GetByIdAsync(int id);
    Task<Quote> CreateAsync(Quote quote);
    Task<Quote> UpdateAsync(int id, Quote quote);
    Task<bool> DeleteAsync(int id);
}