using System;
using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        public readonly OdeToFoodDBContext db;
        public SqlRestaurantData(OdeToFoodDBContext db)
        { this.db = db; }
        public Restaurant AddResurant(Restaurant Newrestaurant)
        {
            db.Add(Newrestaurant);
            return Newrestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
      
        public Restaurant DeleteRestaurant(int id)
        {
            Restaurant restaurant = GetById(id);
            if (restaurant != null)
            { db.Remove(restaurant); }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants;
        }

        public Restaurant GetById(int Id)
        {
            return db.Restaurants.Find(Id);
        }

        public IEnumerable<Restaurant> GetByName(string name)
        {
            var ListOfResturant = from r in db.Restaurants
                                  where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                                  orderby name
                                  select r;

                                return ListOfResturant;
        }

        public int GetRestaurantCount()
        {
            return db.Restaurants.Count();
        }

        public Restaurant updateResurant(Restaurant Id)
        {
         var entity=   db.Restaurants.Attach(Id);
            entity.State = EntityState.Modified;
            return Id;
        }
    }
}
