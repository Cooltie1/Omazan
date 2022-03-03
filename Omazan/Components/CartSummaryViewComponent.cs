using Microsoft.AspNetCore.Mvc;
using Omazan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omazan.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket _basket;
        public CartSummaryViewComponent (Basket cartService)
        {
            _basket = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_basket);
        }
    }
}
