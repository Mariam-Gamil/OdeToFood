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
    public class DeleteModel : PageModel
    {
      
            public readonly IRestaurantData IRestaurantData;
            public Restaurant Restaurant { get; set; }
            public DeleteModel(IRestaurantData restaurantData)
            {

                this.IRestaurantData = restaurantData;
            }
            public IActionResult OnGet(int restaurantId)
            {
               
                    Restaurant = IRestaurantData.GetById(restaurantId);
              

                if (Restaurant == null)
                    RedirectToPage("./NonFound");
                return Page();
            }

            public IActionResult OnPost(int restaurantId)
            {
                Restaurant restaurant = IRestaurantData.DeleteRestaurant(restaurantId);
                IRestaurantData.Commit();
                if (restaurant == null)
                {
                    RedirectToPage("./NONFound.cshtml");
                }

                TempData["Message"] = restaurant.Name + " deleted!!";
                return RedirectToPage("./List");
            }
        }
    }

