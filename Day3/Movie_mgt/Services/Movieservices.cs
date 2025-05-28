using Movie_mgt.Models;

namespace Movie_mgt.Services
{
    public class Movieservices
    {

        private  List<movie> movies ;
            public Movieservices()
        {
            movies = new List<movie>();

            movies.Add(new movie()
            {
                Id = 1, 
                Title = "Inception", 
                Director = "Christopher Nolan", 
                Genre = "Sci-Fi", 
                Rating = 8.8m, 
                Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO."
            });

            movies.Add(new movie()
            {
                Id = 2, 
                Title = "The Godfather", 
                Director = "Francis Ford Coppola", 
                Genre = "Crime", 
                Rating = 9.2m, 
                Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
            });

            movies.Add(new movie()
            {
                Id = 3, 
                Title = "The Dark Knight", 
                Director = "Christopher Nolan", 
                Genre = "Action", 
                Rating = 9.0m, 
                Description = "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham."
            });

        }

        public List<movie> GetAllMovies()
        {
            return movies;
        }
        public movie GetMovieById(int id)
        {
            movie m =   movies.FirstOrDefault(m => m.Id == id);
            if (m == null)
            {
                return null;
            }
            return m;
        }
        public void AddMovie(movie movie)
        {
            int id = movies.Count > 0 ? movies.Max(m => m.Id) + 1 : 0;
            movie.Id = id;
            movies.Add(movie);
        }
        public int  UpdateMovie(movie m)
        {
            movie  existingMovie = GetMovieById(m.Id);
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
                return 1; 
            }
        }
        public int  DeleteMovie(int id)
        {
            movie movieToDelete = GetMovieById(id);
            if (movieToDelete == null)
            {
                 return -1;
            }
            else
            {
                movies.Remove(movieToDelete);
                return 1;
            }
        }
    }
}
