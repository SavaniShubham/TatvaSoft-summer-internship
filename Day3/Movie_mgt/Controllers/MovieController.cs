using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Services.Services;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
using Movies.DataAccess.Models;

namespace Movie_mgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public readonly MovieServices _movieServices;

        public MovieController(MovieServices movieservices)
        {
            _movieServices = movieservices;
        }

        [HttpGet("GetallMovies")]
        public ActionResult<List<movie>> GetAllMovies()
        {
            List<movie> movies = _movieServices.GetAllMovies();
            if (movies == null || movies.Count == 0)
            {
                return NotFound("No movies found.");
            }
            return Ok(movies);
        }
        [HttpGet("GetMovie")]
        public ActionResult<movie> GetMovie(int id)
        {
            movie m = _movieServices.GetMovieById(id);
            if (m == null)
            {
                return NotFound("Movie  not found.");
            }
            return Ok(m);
        }
        [HttpPost]

        public ActionResult AddMovie(movie m)
        {

            _movieServices.AddMovie(m);
            return Ok("Movie added successfully.");
        }

        [HttpPut]
        public ActionResult UpdateMovie(movie m)
        {
            int movieUpdateStatus = _movieServices.UpdateMovie(m);
            if (movieUpdateStatus == -1)
            {

                return NotFound("Movie not found for update.");
            }
            else if (movieUpdateStatus == 1)
            {
                return Ok("Movie updated successfully.");
            }
            else
            {
                return BadRequest("Movie update failed.");
            }
        }

        [HttpDelete]
        public ActionResult DeleteMovie(int id)
        {
            int deleteStatus = _movieServices.DeleteMovie(id);
            if (deleteStatus == -1)
            {
                return NotFound("Movie not found for deletion.");
            }
            else if (deleteStatus == 1)
            {
                return Ok("Movie deleted successfully.");
            }
            else
            {
                return BadRequest("Movie deletion failed.");
            }

        }
        [HttpGet("GetFilterMovies")]
        public ActionResult<List<movie>> GetFilterMovies(String genre)
        {
            List<movie> FilterMovies = _movieServices.GetFilterMovies(genre);

            if (FilterMovies == null || FilterMovies.Count == 0)
            {
                return NotFound("No movies found.");
            }
            return Ok(FilterMovies);
        }

    }
}

