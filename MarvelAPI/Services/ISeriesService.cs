using System.Collections.Generic;
using MarvelApI.Models;

namespace MarvelApI.Services
{
    public interface ISeriesService
    {
        IEnumerable<Series> GetAllSeries();
        Series GetSeriesById(int id);
        void CreateSeries(Series series);
        void UpdateSeries(Series series);
        void DeleteSeries(int id);
    }
}