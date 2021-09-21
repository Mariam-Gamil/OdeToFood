using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
   public interface IRestaurantData
    {
        public IEnumerable<Restaurant> GetAll();
    }


    public class IMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> listOfRestaurant;
        public IMemoryRestaurantData()
        {
            listOfRestaurant = new List<Restaurant>() {
                new Restaurant{ Id=1,Name="Pizza Hut",Location="Egypt",CuisineType=CuisineType.Italin},
                new Restaurant{ Id=2,Name="La casta",Location="Egypt",CuisineType=CuisineType.Mexican},
                new Restaurant{ Id=3,Name="Mahraga",Location="Egypt",CuisineType=CuisineType.India},

                };


        }
        public IEnumerable<Restaurant> GetAll() {
            return from r in listOfRestaurant
                   orderby r.Name
                   select r;
        }

    }
}
