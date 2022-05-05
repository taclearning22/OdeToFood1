using OdeToFood1.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood1.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant UpdateRestaurant(Restaurant updatedRestaurant);
        Restaurant CreateRestaurant(Restaurant newRestaurant);
        Restaurant DeleteRestaurant(int id);
        int GetCountOfRestaurants();
        int Commit();
    }
}
