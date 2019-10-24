using System;
using System.Collections.Generic;
using System.Linq;
using latinosenlouisville.core;

namespace latinosenlouisville.data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {

        public List<Restaurant> Restaurants { get; set; }

        public InMemoryRestaurantData()
        {
            Restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 0, Name = "Juanitas", Location = "Broadway", Cuisine = CuisineType.Cuban },
                new Restaurant { Id = 2, Name = "Coquitos", Location = "Baxters",  Cuisine = CuisineType.Boricua },
            };    
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in Restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
