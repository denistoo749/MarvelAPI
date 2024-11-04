using System.Collections.Generic;
using System.Linq;
using MarvelApI.Data;
using MarvelApI.Models;

namespace MarvelApI.Services
{
    public class SeriesService : ISeriesService
    {
        private readonly MarvelContext _context;

        public SeriesService(MarvelContext context)
        {
            _context = context;
        }

        public IEnumerable<Series> GetAllSeries()
        {
            return _context.Series.ToList();
        }

        public Series GetSeriesById(int id)
        {
            return _context.Series.Find(id);
        }

        public void CreateSeries(Series series)
        {
            _context.Series.Add(series);
            _context.SaveChanges();
        }

        public void UpdateSeries(Series series)
        {
            var existingSeries = _context.Series.Find(series.Id);
            if (existingSeries != null)
            {
                existingSeries.Title = series.Title;
                existingSeries.Description = series.Description;
                existingSeries.Seasons = series.Seasons;
                existingSeries.ReleaseYear = series.ReleaseYear;
                _context.SaveChanges();
            }
        }

        public void DeleteSeries(int id)
        {
            var series = _context.Series.Find(id);
            if (series != null)
            {
                _context.Series.Remove(series);
                _context.SaveChanges();
            }
        }
    }
}