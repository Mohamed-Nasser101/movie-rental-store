using AutoMapper;
using System;
using System.Linq;
using System.Web.Http;
using vidly.Dtos;
using vidly.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<MoviesDTO> GetMovies(string query = null)
        {
            var movieQuery = _context.Movies.Include(m => m.Genre).Where(m =>m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(m => m.Name.Contains(query));

            var movies = movieQuery.ToList().Select(Mapper.Map<Movie, MoviesDTO>);

            return movies;
        }

        public IHttpActionResult GetMovie(int id)
        {
            var mov =_context.Movies.SingleOrDefault(m => m.Id == id);

            if (mov == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MoviesDTO>(mov));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDTO movDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var mov = Mapper.Map<MoviesDTO, Movie>(movDto);

            _context.Movies.Add(mov);
            _context.SaveChanges();

            movDto.Id = mov.Id;

            return Created(new Uri(Request.RequestUri + "/" + mov.Id), movDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id ,MoviesDTO movDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var mov = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (mov == null)
                return NotFound();

            Mapper.Map(movDto, mov);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var mov = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (mov == null)
                return NotFound();

            _context.Movies.Remove(mov);
            _context.SaveChanges();

            return Ok();
        }
    }
}
