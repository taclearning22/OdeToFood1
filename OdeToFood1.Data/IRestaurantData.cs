﻿using OdeToFood1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood1.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name = "Spicy", Location="Houston", Cuisine=CuisineType.Mexican },
                new Restaurant{Id = 2, Name = "Tikka", Location="New York", Cuisine=CuisineType.Indian },
                new Restaurant{Id = 3, Name = "Ciao", Location = "Alabama", Cuisine=CuisineType.Italian }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
