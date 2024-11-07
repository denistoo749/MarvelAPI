using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarvelApI.Data;
using MarvelApI.Models;
using MarvelAPI.Repositories;

namespace MarvelApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly SeriesRepository _seriesRepository;

        public SeriesController(SeriesRepository seriesRepository)
        {
            _seriesRepository = seriesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Series>>> GetSeries()
        {
            var series =  await _seriesRepository.GetSeries();
            return Ok(series);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Series>> GetSeries(int id)
        {
            var series = await _seriesRepository.GetSeries(id);
            if (series == null)
            {
                return NotFound();
            }
            return series;
        }

        [HttpPost]
        public async Task<ActionResult<Series>> PostSeries(Series series)
        {
            var addedSeries = await _seriesRepository.PostSeries(series);
            return CreatedAtAction(nameof(GetSeries), new { id = addedSeries.Id }, addedSeries);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeries(int id, Series series)
        {
            if (id != series.Id)
            {
                return BadRequest();
            }

            var updateSuccessful = await _seriesRepository.PutSeries(id, series);

            if (!updateSuccessful)
            {
                if (!await _seriesRepository.GetSeries(id).ContinueWith(t => t.Result != null))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeries(int id)
        {
            var deletionSuccessful = await _seriesRepository.DeleteSeries(id);

            if (deletionSuccessful == null)
            {
                return NotFound($"Series with Id = {id} not found");
            }

            return NoContent();
        }
    }
}
