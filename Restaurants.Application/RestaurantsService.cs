﻿using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application;

public class RestaurantsService(IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantsService> logger) : IRestaurantsService
{

    public async Task<IEnumerable<Restaurant>> GetRestaurants()
    {
        logger.LogInformation("Getting all restaurants");

        var restaurants = await restaurantsRepository.GetAllAsync();
        return restaurants;
    }

    public async Task<Restaurant>? GetRestaurantById(int id)
    {
        logger.LogInformation("Getting the restaurant");

        var restaurant = await restaurantsRepository.GetByIdAsync(id);
        return restaurant;
    }
}
