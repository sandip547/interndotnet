using interndotnet.Models;
using interndotnet.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace interndotnet.Controllers;
[ApiController]
[Route("api/[controller]")]
public class QuoteController : ControllerBase
{
 
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var quotes = await _quoteService.GetAllAsync();
            if (quotes == null || !quotes.Any())
                return NotFound(new { message = "No quotes found" });
            return Ok(quotes);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var quote = await _quoteService.GetByIdAsync(id);
            if (quote == null)
                return NotFound(new { message = $"Quote with Id {id} not found" });
            return Ok(quote);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] Quote quote)
        {
            var createdQuote = await _quoteService.CreateAsync(quote);
            return CreatedAtAction(nameof(GetById), new { id = createdQuote.Id }, createdQuote);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] Quote quote)
        {
            var updatedQuote = await _quoteService.UpdateAsync(id, quote);
            if (updatedQuote == null)
                return NotFound(new { message = $"Quote with Id {id} not found" });
            return Ok(updatedQuote);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _quoteService.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Quote with Id {id} not found" });
            return NoContent();
        }
}