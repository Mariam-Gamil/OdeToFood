using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        public readonly IRestaurantData IRestaurantData;
        public readonly IHtmlHelper IHtmlhelper;
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlhelper)
        {
            this.IHtmlhelper = htmlhelper;
            this.IRestaurantData = restaurantData;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = IHtmlhelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                Restaurant = IRestaurantData.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant restaurant = new Restaurant();
               
            }

            if (Restaurant == null)
                RedirectToPage("./NonFound");
            return Page();
        }


        public IActionResult OnPost(int restaurantId)
        {
            //if (!ModelState.IsValid)
            //{
                //Cuisines = IHtmlhelper.GetEnumSelectList<CuisineType>();
                //return Page();
               
            //}
            if (restaurantId > 0)
            {
                Restaurant = IRestaurantData.updateResurant(Restaurant);
            }
            else
            { 
                Restaurant = IRestaurantData.AddResurant(Restaurant); }
            
            IRestaurantData.Commit();
           return RedirectToPage("./Details", new { restaurantid = Restaurant.Id });
        }
    }
}
