using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application
{
    public interface IRestaurantsService
    {
        Task<IEnumerable<RestaurantDto>> GetRestaurants();
        Task<RestaurantDto>? GetRestaurantById(int id);
    }
}