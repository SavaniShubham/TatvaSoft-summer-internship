using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_mgt.Services;
using Movie_mgt.Models;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;

namespace Movie_mgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public readonly Movieservices _movieservices;

        public MovieController(Movieservices movieservices)
        {
            _movieservices = movieservices;
        }

        [HttpGet("GetallMovies")]
        public ActionResult<List<movie>> GetAllMovies()
        {
            List<movie> movies = _movieservices.GetAllMovies();
            if (movies == null || movies.Count == 0)
            {
                return NotFound("No movies found.");
            }
            return Ok(movies);
        }
        [HttpGet("GetMovie")]
        public ActionResult<movie> GetMovie(int id)
        {
            movie m = _movieservices.GetMovieById(id);
            if (m == null)
            {
                return NotFound("Movie  not found.");
            }
            return Ok(m);
        }
        [HttpPost]

        public ActionResult AddMovie(movie m)
        {

            _movieservices.AddMovie(m);
            return Ok("Movie added successfully.");
        }

        [HttpPut]
        public ActionResult UpdateMovie(movie m)
        {
            int movieUpdateStatus = _movieservices.UpdateMovie(m);
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
            int deleteStatus = _movieservices.DeleteMovie(id);
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
    }
}

