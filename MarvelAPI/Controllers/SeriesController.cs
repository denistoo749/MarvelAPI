using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarvelApI.Data;
using MarvelApI.Models;

namespace MarvelApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly MarvelContext _context;

        public SeriesController(MarvelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Series>>> GetSeries()
        {
            return await _context.Series.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Series>> GetSeries(int id)
        {
            var series = await _context.Series.FindAsync(id);
            if (series == null)
            {
                return NotFound();
            }
            return series;
        }

        [HttpPost]
        public async Task<ActionResult<Series>> PostSeries(Series series)
        {
            _context.Series.Add(series);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSeries), new { id = series.Id }, series);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeries(int id, Series series)
        {
            if (id != series.Id)
            {
                return BadRequest();
            }

            _context.Entry(series).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeriesExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeries(int id)
        {
            var series = await _context.Series.FindAsync(id);
            if (series == null)
            {
                return NotFound();
            }

            _context.Series.Remove(series);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeriesExists(int id)
        {
            return _context.Series.Any(e => e.Id == id);
        }
    }
}
