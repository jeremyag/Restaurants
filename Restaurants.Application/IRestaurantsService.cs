using Restaurants.Domain.Entities;

namespace Restaurants.Application
{
    public interface IRestaurantsService
    {
        Task<IEnumerable<Restaurant>> GetRestaurants();
        Task<Restaurant>? GetRestaurantById(int id);
    }
}