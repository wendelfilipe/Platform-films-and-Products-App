using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste.Application.DTOs;
using Teste.Application.Interfaces;

namespace Teste.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMovieServices movieServices;
        public UserController(
            IUserService userService,
            IMovieServices movieServices
        )
        {
            this.userService = userService;
            this.movieServices = movieServices;
        }

        [HttpGet("GetUsersByMovieId/{id}")]
        public async Task<IActionResult> GetUsersByMovieId(int id)
        {
            try
            {
                 var users = await userService.GetUsersByMovieId(id);

                if(users == null)
                    throw new Exception("Error when searching for user");

                return Ok(users);
            }
            catch(Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            try
            {
                await userService.CreateUser(userDTO);

                var users = await userService.GetUsersByMovieId(userDTO.MovieId);

                if(users == null)
                    throw new Exception("Entity users can not be found");

                double? totalClassification = 0;
                int? i = 0;
                double? mediaClassification = 0;
                
                foreach(var user in users)
                {
                    totalClassification += user.Classification;
                    i++;
                }
                
                mediaClassification = totalClassification / i;

                double valueToRound = mediaClassification ?? 0;
                var roundedMedia = Math.Round(valueToRound, MidpointRounding.AwayFromZero);

                var movie = await movieServices.GetMovieByIdAsync(userDTO.MovieId);
                
                if(movie == null)
                    throw new Exception("Entity movie can not be found");

                var movieInstance = new MovieDTO
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Gender = movie.Gender,
                    Classification = (int?)roundedMedia,
                    Date = movie.Date,
                    Comment = movie.Comment,
                    Image = movie.Image,
                };

                await movieServices.UpdateMovieAsync(movieInstance);

                return Ok("Success");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return Ok(e.Message);
            }
        }
    }
}