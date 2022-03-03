using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Omazan.Infrastructure;
using Omazan.Models;

namespace Omazan.Pages
{
    public class CartModel : PageModel
    {
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        private IOmazanRepository _repository { get; set; }

        public CartModel (IOmazanRepository tmp, Basket basket)
        {
            _repository = tmp;
            this.basket = basket;
        }


        

        public void OnGet(string returnUrl)
        {
            basket = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();

            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            Books book = _repository.Books.FirstOrDefault(x => x.BookId == BookId);

            basket = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();
            basket.AddItem(book, 1);

            HttpContext.Session.SetJson("Basket", basket);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
            
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.items.FirstOrDefault(x => x.book.BookId == bookId).book);
            return RedirectToPage(new { ReturnUrl = returnUrl });

        }
    }
}
