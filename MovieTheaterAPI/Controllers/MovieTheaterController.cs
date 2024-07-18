using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using MovieTheaterAPI.Entity;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MovieTheaterAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MovieTheaterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieTheaterController : ControllerBase
    {
        private readonly DataContext _context;

        public MovieTheaterController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movies>>> GetAllMovies()
        {
            var movies = await _context.MovieList.ToListAsync();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movies>> GetMovie(int id)
        {
            var movie = await _context.MovieList.FindAsync(id);
            if (movie is null)
                return NotFound("Movie not found.");

            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<List<Movies>>> AddMovie(Movies movie)
        {
            _context.MovieList.Add(movie);
            await _context.SaveChangesAsync();

            return Ok(await _context.MovieList.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Movies>>> UpdateMovie(Movies movie)
        {
            var dbMovie = await _context.MovieList.FindAsync(movie.ID);
            if (dbMovie is null)
                return NotFound("Movie not found.");

            dbMovie.ID = movie.ID;
            dbMovie.Title = movie.Title;
            dbMovie.ReleaseDate = movie.ReleaseDate;
            dbMovie.DirectorID = movie.DirectorID;
            dbMovie.GenreID = movie.GenreID;

            await _context.SaveChangesAsync();

            return Ok(await _context.MovieList.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Movies>>> DeleteMovie(int id)
        {
            var dbMovie = await _context.MovieList.FindAsync(id);
            if (dbMovie is null)
                return NotFound("Movie not found.");

            _context.MovieList.Remove(dbMovie);
            await _context.SaveChangesAsync();

            return Ok(await _context.MovieList.ToListAsync());
        }
    }
}
