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
        private IOmazanRepository _repository { get; set; }

        public CartModel (IOmazanRepository tmp)
        {
            _repository = tmp;
        }


        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();

            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            Books book = _repository.Books.FirstOrDefault(x => x.BookId == BookId);

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(book, 1);

            HttpContext.Session.SetJson("basket", basket);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
