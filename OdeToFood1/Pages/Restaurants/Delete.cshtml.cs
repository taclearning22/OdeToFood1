using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood1.Core;
using OdeToFood1.Data;

namespace OdeToFood1.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetRestaurantById(restaurantId);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = restaurantData.DeleteRestaurant(restaurantId);
            restaurantData.Commit();
            TempData["Message"] = "Restaurant Deleted successfully!";
            /*if(restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }*/
            return RedirectToPage("./List");
        }
    }
}
