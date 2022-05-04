using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood1.Core;
using OdeToFood1.Data;
using System.Collections.Generic;

namespace OdeToFood1.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant{ get; set; }
        public IEnumerable<SelectListItem> Cuisines{ get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            if (restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetRestaurantById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }


            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            
            if (Restaurant.Id > 0)
            {
                restaurantData.UpdateRestaurant(Restaurant);
            }
            else
            {
                restaurantData.CreateRestaurant(Restaurant);
            }
            
            restaurantData.Commit();
            TempData["Message"] = "Restaurant Saved!";
            return RedirectToPage("./Detail", new { restaurantid = Restaurant.Id });

        }
    }
}
