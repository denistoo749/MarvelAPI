using MarvelApI.Data;
using MarvelApI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarvelAPI.Repositories
{
    public class SeriesRepository
    {
        private readonly MarvelContext _context;

        public SeriesRepository(MarvelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Series>> GetSeries()
        {
            return await _context.Series.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Series> GetSeries(int id)
        {
            var series = await _context.Series.FindAsync(id);
            if (series == null)
            {
                return null;
            }
            return series;
        }

        [HttpPost]
        public async Task<Series> PostSeries(Series series)
        {
            _context.Series.Add(series);
            await _context.SaveChangesAsync();
            return series;
        }

        [HttpPut("{id}")]
        public async Task<bool> PutSeries(int id, Series series)
        {
            if (id != series.Id)
            {
                return false;
            }

            _context.Entry(series).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteSeries(int id)
        {
            var series = await _context.Series.FindAsync(id);
            if (series == null)
            {
                return false;
            }

            _context.Series.Remove(series);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool SeriesExists(int id)
        {
            return _context.Series.Any(e => e.Id == id);
        }
    }
}
