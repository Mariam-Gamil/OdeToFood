using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponant
{
    public class RestaurantCountViewComponant: Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly IRestaurantData restaurantData;
        public RestaurantCountViewComponant(IRestaurantData restaurantData)
        { 
            this.restaurantData = restaurantData;
        }
        public IViewComponentResult Invoke()
        {
            var Count = restaurantData.GetRestaurantCount();
            return View(Count);
        }
    }
}
