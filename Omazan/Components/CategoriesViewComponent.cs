using Microsoft.AspNetCore.Mvc;
using Omazan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omazan.Components
{
    public class CategoriesViewComponent : ViewComponent 
    {
        private IOmazanRepository _repo { get; set; }

        public CategoriesViewComponent (IOmazanRepository tmp)
        {
            _repo = tmp;
        }

        public IViewComponentResult Invoke()
        {

            ViewBag.Selected = RouteData?.Values["category"];
            var categories = _repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
