using Microsoft.AspNetCore.Mvc;
using Omazan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omazan.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository _repo { get; set; }
        private Basket _basket { get; set; }
        public PurchaseController(IPurchaseRepository tmp, Basket basket)
        {
            _repo = tmp;
            _basket = basket;
        }


        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }
        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (_basket.items.Count() == 0)
            {
                ModelState.AddModelError("", "Your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                purchase.Lines = _basket.items.ToArray();
                _repo.SavePurchase(purchase);
                _basket.ClearBasket();

                return RedirectToPage("/Confirmation");
            } 
            else
            {
                return View();
            }
        }
    }
}
