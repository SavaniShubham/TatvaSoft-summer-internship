using Movies.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess.Repositories
{
    public class MovieRepository
    {
        private readonly MovieDbContext _context;
        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public List<movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }
        public movie GetMovieById(int id)
        {
            movie m = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (m == null)
            {
                return null;
            }
            return m;
        }
        public void AddMovie(movie movie)
        {
    
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
        public int UpdateMovie(movie m)
        {
            movie existingMovie = GetMovieById(m.Id);
            if (existingMovie == null)
            {
                return -1;
            }
            else
            {
                existingMovie.Title = m.Title;
                existingMovie.Director = m.Director;
                existingMovie.Genre = m.Genre;
                existingMovie.Rating = m.Rating;
                existingMovie.Description = m.Description;
                _context.SaveChanges();
                return 1;
            }
        }
        public int DeleteMovie(int id)
        {
            movie movieToDelete = GetMovieById(id);
            if (movieToDelete == null)
            {
                return -1;
            }
            else
            {
                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();
                return 1;
            }
        }
        public List<movie> GetFilterMovies(string genre)
        {
            List<movie> movies = _context.Movies.Where(m => m.Genre.Equals(genre)).ToList();
            return movies;
        }
    }
}
