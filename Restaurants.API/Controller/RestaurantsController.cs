using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantsById;

namespace Restaurants.API.Controller;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(
    IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(restaurants);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(
        [FromRoute] int id)
    {
        var restaurants = await mediator.Send(new GetRestaurantByIdQuery()
        {
            Id = id
        });

        if(restaurants == null)
        {
            return NotFound();
        }

        return Ok(restaurants);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRestaurantCommand createRestaurantCommand)
    {
        var id = await mediator.Send(createRestaurantCommand);
        return CreatedAtAction(nameof(Get), new {id}, null);
    }
}
