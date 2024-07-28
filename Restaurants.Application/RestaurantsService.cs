using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application;

public class RestaurantsService(
    IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantsService> logger,
    IMapper mapper) : IRestaurantsService
{

    public async Task<IEnumerable<RestaurantDto>> GetRestaurants()
    {
        logger.LogInformation("Getting all restaurants");

        var restaurants = await restaurantsRepository.GetAllAsync();

        var restaurantDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        return restaurantDtos;
    }

    public async Task<RestaurantDto?> GetRestaurantById(int id)
    {
        logger.LogInformation("Getting the restaurant");

        var restaurant = await restaurantsRepository.GetByIdAsync(id);

        if (restaurant != null) {
            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
            return restaurantDto;
        }

        return null;
    }

    public async Task<int> Create(CreateRestaurantDto dto)
    {
        var restaurant = mapper.Map<Restaurant>(dto);
        var id = await restaurantsRepository.Create(restaurant);

        return id;
    }
}
