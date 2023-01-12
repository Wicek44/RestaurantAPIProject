using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
            
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast food",
                    Description =
                        "KFC (Short for Kentucky Fried Chicken) is American fast food restaurant chain headquartered.",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = "10.30",
                        },

                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = "5.30",
                        },
                    },
                    Address = new Address()
                    {
                         City = "Kraków",
                         Street = "Długa 5",
                         PostalCode = "30-001"
                    }
                },

                new Restaurant()
                {
                    Name = "McDonald",
                    Category = "Fast food",
                    Description =
                        "McDonald's Corporation (McDonald's) is an American multinational fast food chain.",
                    ContactEmail = "contact@mcdonalds.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "BigMac",
                            Price = "15.30",
                        },

                        new Dish()
                        {
                            Name = "McChicken",
                            Price = "6.70",
                        },
                    },
                    Address = new Address()
                    {
                         City = "Gdansk",
                         Street = "Krótka 7",
                         PostalCode = "30-002"
                    }
                }
            };

            return restaurants;
        }
    }
}
