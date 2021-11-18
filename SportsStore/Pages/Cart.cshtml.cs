using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Infrastructure;
using SportsStore.Models;

namespace SportsStore.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository repository;
        public CartModel(IStoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public string Message { get; set; }
        public void OnGet(string returnUrl, string message)
        {
            Message = message;
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJSon<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long Id, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ID == Id);
            Cart.AddItem(product, 1);
            return RedirectToPage(new { returnUrl = returnUrl, message = "Added"});
            //Cart = HttpContext.Session.GetJSon<Cart>("cart") ?? new Cart();
            //Cart.AddItem(product, 1);
            //HttpContext.Session.SetJson("cart", Cart);
            //return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long Id, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ID == Id).Product);
            return RedirectToPage(new { returnUrl = returnUrl, message = "Removed" });
        }
    }
}
