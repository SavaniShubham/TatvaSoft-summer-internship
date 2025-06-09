using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies.DataAccess.Models;
using Movies.DataAccess.Repositories;

namespace Movies.Services.Services
{
    public class MovieServices
    {
        private readonly MovieRepository _movieRepository;
        public MovieServices(MovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public List<movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }
        public movie GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }
        public void AddMovie(movie movie)
        {
            _movieRepository.AddMovie(movie);
        }
        public int UpdateMovie(movie m)
        {
            return _movieRepository.UpdateMovie(m);
        }
        public int DeleteMovie(int id)
        {
            return _movieRepository.DeleteMovie(id);
        }
        public List<movie> GetFilterMovies(string genre)
        {
            return _movieRepository.GetFilterMovies(genre);
        }
    }
}
