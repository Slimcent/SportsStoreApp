using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Web.Infrastructure;
using SportsStore.Models;
using SportsStore.Repository.Interfaces;
using SportsStore.Models.Entities;
using System.Linq;

namespace SportsStore.Web.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository repository;

        public Cart? Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public CartModel(IStoreRepository repo)
        {
            repository = repo;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product? product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
