using Microsoft.AspNetCore.Mvc;
using Restaurants.Application;

namespace Restaurants.API.Controller;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await restaurantsService.GetRestaurants();
        return Ok(restaurants);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(
        [FromRoute] int id)
    {
        var restaurants = await restaurantsService.GetRestaurantById(id);
        if(restaurants == null)
        {
            return NotFound();
        }

        return Ok(restaurants);
    }
}
