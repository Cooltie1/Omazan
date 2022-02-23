using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Omazan.Models;
using Omazan.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Omazan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IOmazanRepository _repository;



        public HomeController(ILogger<HomeController> logger, IOmazanRepository tmp)
        {
            _logger = logger;
            _repository = tmp;
        }

        public IActionResult Index(string category, int pagenum = 1)
        {
            int pageSize = 5;

            var viewModel = new BooksViewModel
            {
                books = _repository.Books
                .OrderBy(b => b.Title)
                .Where(b => b.Category == category || category == null)
                .Skip((pagenum - 1) * pageSize)
                .Take(pageSize),
                pageInfo = new PageInfo
                {
                    totalBooks = (category == null ? _repository.Books.Count() : _repository.Books.Where(x => x.Category == category).Count()),
                    booksPerPage = pageSize,
                    currPage = pagenum
                }
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
