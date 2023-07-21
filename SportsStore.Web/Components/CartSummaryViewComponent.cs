using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Web.Services.Implementation;

namespace SportsStore.Web.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
