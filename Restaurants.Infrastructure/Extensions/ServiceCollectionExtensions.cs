﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Persistance;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration conf)
    {
        var connectionString = conf.GetConnectionString("RestaurantDb");

        services.AddDbContext<RestaurantsDbContext>(
            options => options.UseSqlServer(connectionString));

        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
    }
}
