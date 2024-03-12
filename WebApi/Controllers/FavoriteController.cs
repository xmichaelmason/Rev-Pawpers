using BusinessLogic;
using Serilog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteBL favoriteRepository;
        public FavoriteController(IFavoriteBL context)
        {
            favoriteRepository = context;

        }

        [HttpGet("GetAll")]
        public IActionResult GetAllFavorites()
        {
            return Ok(favoriteRepository.GetAll());
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(favoriteRepository.GetByPrimaryKey(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        [HttpGet("SearchByDog/{id}")]
        public IActionResult SearchByDog(int id)
        {
            try
            {
                return Ok(favoriteRepository.SearchByDogId(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid ID");
            }
        }

        [HttpGet("SearchByProfile/{id}")]
        public IActionResult SearchByProfile(int id)
        {

            try
            {
                return Ok(favoriteRepository.SearchByProfileId(id));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest("Not a valid Id");

            }
        }

        // POST <FavoriteController>
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Favorite p_favorite)
        {
            favoriteRepository.Create(p_favorite);
            favoriteRepository.Save();
            return Created("Favorite/Add", p_favorite);
        }

        // PUT <FavoriteController>/5
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Favorite p_favorite)
        {
            var fav = favoriteRepository.GetByPrimaryKey(id);
            if (fav != null)

            {
                fav.DogId = p_favorite.DogId;
                fav.ProfileId = p_favorite.ProfileId;
                fav.IsAvailable = p_favorite.IsAvailable;

                favoriteRepository.Update(fav);
                favoriteRepository.Save();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE <FavoriteController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var favorite = favoriteRepository.GetByPrimaryKey(id);
                favoriteRepository.Delete(favorite);
                favoriteRepository.Save();
                return Ok();
            }
            catch (Exception e)
            {

                Log.Error(e.Message);
                return BadRequest("Not a valid Id");
            }
        }
    }
}
