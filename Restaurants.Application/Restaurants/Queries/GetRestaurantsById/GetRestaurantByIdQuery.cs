using MediatR;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantsById;

public class GetRestaurantByIdQuery : IRequest<RestaurantDto>
{
    public int Id { get; init; }
}
