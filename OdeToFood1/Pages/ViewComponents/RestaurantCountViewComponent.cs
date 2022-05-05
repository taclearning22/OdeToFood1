using Microsoft.AspNetCore.Mvc;
using OdeToFood1.Data;

namespace OdeToFood1.Pages.ViewComponents
{
    public class RestaurantCountViewComponent: ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCountOfRestaurants();
            return View(count);
        }
    }
}
