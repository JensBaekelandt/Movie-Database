using BlazorWebAppMovies.Data;
using BlazorWebAppMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly BlazorWebAppMoviesContext _context;

        public MovieController(BlazorWebAppMoviesContext context)
        {
            _context = context;
        }

        // Find
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> Find()
        {
            return await _context.Movie.ToListAsync();
        }

        // Get
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            var todoItem = await _context.Movie.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // Post
        [HttpPost]
        public async Task<ActionResult<Movie>> Post(Movie todoItem)
        {
            _context.Movie.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = todoItem.Id }, todoItem);
        }
        // Put
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Movie todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todoItem = await _context.Movie.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
