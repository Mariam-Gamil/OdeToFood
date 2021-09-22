using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Core;

namespace OdeToFood.Data
{
   public interface IRestaurantData
    {
        public IEnumerable<Restaurant> GetAll();
        public IEnumerable<Restaurant> GetByName(string name);
    }


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
        public IEnumerable<Restaurant> GetByName(string name=null)
        {
            return from r in listOfRestaurant
                   where string.IsNullOrEmpty(name)|| r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

    }
}
