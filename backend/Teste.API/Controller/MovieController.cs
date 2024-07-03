using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste.Application.DTOs;
using Teste.Application.Interfaces;
using Teste.Domain.Entites.Enums;

namespace Teste.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieServices movieServices;
        public MovieController(IMovieServices movieServices)
        {
            this.movieServices = movieServices;
        }
        [HttpGet("GetAllMovies")]
        public async Task<IActionResult> GetAllMoviesAsync()
        {
            try
            {
                var movies = await movieServices.GetAllMoviesAsync();
                
                if(!movies.Any())
                    throw new Exception("There are no films at the moment ");
                
                return Ok(movies);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }
        [HttpGet("GetMovieById/{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            try
            {
                var movie = await movieServices.GetMovieByIdAsync(id);

                if(movie == null)
                    throw new Exception("We couldn't find this film");

                return Ok(movie);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }
        [HttpGet("GetMovieByName/{name}")]
        public async Task<IActionResult> GetMovieByName(string name)
        {
                try
                {
                    var movies = await movieServices.GetMovieByNameAsync(name);

                    if(movies == null)
                        throw new Exception("We don't have that movie");

                    return Ok(movies);
                }
                catch(Exception e)
                {
                    return Ok(e.Message);
                }
        }

        [HttpGet("GetMoviesByGender/{gender}")]
        public async Task<IActionResult> GetMoviesByGender(Gender gender)
        {
            try
            {
                var movies = await movieServices.GetMoviesByGender(gender);

                if(movies == null)
                    throw new Exception("We don't found this movie");

                return Ok(movies);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpPost("CreateMovie")]
        public async Task<IActionResult> CreateMovie(MovieDTO movieDTO)
        {
            try
            {
                await movieServices.CreateMovieAsync(movieDTO);

                return Ok("Successfully created film");
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }
        [HttpPut("UpdateMovie")]
        public async Task<IActionResult> UpdateMovie(MovieDTO movieDTO)
        {
            try
            {
                await movieServices.UpdateMovieAsync(movieDTO);

                return Ok("Successfully Updated film");
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpDelete("DeleteMovie/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await movieServices.DeleteMovieAsync(id);

                return Ok("Successfully deleted film");
                
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}