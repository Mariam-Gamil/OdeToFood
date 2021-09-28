using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class IMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> listOfRestaurant;
        public IMemoryRestaurantData()
        {
            listOfRestaurant = new List<Restaurant>() {
                new Restaurant{ Id=1,Name="Pizza Hut",Location="Egypt",Cuisine=CuisineType.Italin},
                new Restaurant{ Id=2,Name="La casta",Location="Italy",Cuisine=CuisineType.Mexican},
                new Restaurant{ Id=3,Name="Mahraga",Location="Greek",Cuisine=CuisineType.India},

                };


        }
        public IEnumerable<Restaurant> GetAll() {
            return from r in listOfRestaurant
                   orderby r.Name
                   select r;
        }
        public int GetRestaurantCount()
        {
            return listOfRestaurant.Count();
        }
        public IEnumerable<Restaurant> GetByName(string name=null)
        {
            return from r in listOfRestaurant
                   where string.IsNullOrEmpty(name)|| r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
        public Restaurant GetById(int Id)
        {
            return listOfRestaurant.SingleOrDefault(x=>x.Id==Id);
        }
        public Restaurant updateResurant(Restaurant _restaurant)
        {
            var restaurant= listOfRestaurant.SingleOrDefault(x => x.Id == _restaurant.Id);
            if (restaurant != null)
            { restaurant.Name = _restaurant.Name;
                restaurant.Location = _restaurant.Location;
                restaurant.Cuisine = _restaurant.Cuisine;
            }
            return restaurant;
        }

       

        public int Commit()
        {
            return 0;
        }

        public Restaurant AddResurant(Restaurant Newrestaurant)
        {
            listOfRestaurant.Add(Newrestaurant);
            Newrestaurant.Id = listOfRestaurant.Max(s => s.Id + 1);
            return Newrestaurant;
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var restaurant = listOfRestaurant.SingleOrDefault(x => x.Id ==id);
            if (restaurant != null)
            {
                listOfRestaurant.Remove(restaurant);
               
            }
            return restaurant;
        }
    }
}
