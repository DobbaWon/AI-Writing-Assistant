using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromptEntriesController : ControllerBase
    {
        private readonly AppDbContext _context; // Database context (see Data/AppDbContext.cs)
        public PromptEntriesController(AppDbContext context)
        {
            _context = context;
        }

        // 1. POST: api/promptentries
        // Creates a new prompt
        [HttpPost]
        public async Task<IActionResult> CreatePrompt([FromBody] PromptEntry newPrompt)
        {
            newPrompt.LastModified = DateTime.UtcNow;

            _context.PromptEntries.Add(newPrompt);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPromptText), new { id = newPrompt.Id }, newPrompt);
        }

        // 2. GET: api/promptentries/names
        // Returns all prompt names (Id + Prompt only)
        [HttpGet("names")]
        public async Task<IActionResult> GetPromptNames()
        {
            var names = await _context.PromptEntries
                .Select(p => new { p.Id, p.Prompt, p.LastModified }) // Omit Text for brevity
                .OrderByDescending(p => p.LastModified) // Order by last modified date
                .ToListAsync();

            return Ok(names);
        }

        // 3. GET: api/promptentries/{id}/text
        // Returns the text for a specific prompt
        [HttpGet("{id}/text")]
        public async Task<IActionResult> GetPromptText(int id)
        {
            var entry = await _context.PromptEntries
                .Where(p => p.Id == id) // Filter by ID
                .Select(p => new { p.Id, p.Text }) // Select only Id and Text
                .FirstOrDefaultAsync(); // Get the first matching entry

            if (entry == null)
                return NotFound();

            return Ok(entry);
        }

        // 4. PUT: api/promptentries/{id}
        // Updates an existing prompt
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrompt(int id, [FromBody] PromptEntry updated)
        {
            var entry = await _context.PromptEntries.FindAsync(id);
            if (entry == null) return NotFound();

            entry.Prompt = updated.Prompt;
            entry.Text = updated.Text;
            entry.LastModified = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // 5. DELETE: api/promptentries/{id}
        // Deletes a prompt by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrompt(int id)
        {
            var entry = await _context.PromptEntries.FindAsync(id);
            if (entry == null) return NotFound();

            _context.PromptEntries.Remove(entry);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
