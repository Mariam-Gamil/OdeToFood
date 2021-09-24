using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        public readonly IRestaurantData IRestaurantData;
        public Restaurant Restaurant { get; set; }

        public DetailsModel(IRestaurantData restaurantData)
        { this.IRestaurantData = restaurantData;
        }
        public void OnGet(int restaurantId)
        {
            Restaurant = IRestaurantData.GetById(restaurantId);
        }
    }
}
