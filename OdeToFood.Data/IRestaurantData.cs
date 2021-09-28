using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        public IEnumerable<Restaurant> GetAll();
        public IEnumerable<Restaurant> GetByName(string name);
        public Restaurant GetById(int Id);
        public Restaurant updateResurant(Restaurant Id);
        public Restaurant AddResurant(Restaurant Newrestaurant);
         public Restaurant DeleteRestaurant(int id);
        public int GetRestaurantCount();

        public int Commit();

    }
}
