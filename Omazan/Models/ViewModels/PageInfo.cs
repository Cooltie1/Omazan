using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omazan.Models.ViewModels
{
    public class PageInfo
    {
        public int totalBooks { get; set; }
        public int booksPerPage { get; set; }
        public int currPage { get; set; }
        public int totPages => (int) Math.Ceiling((double) totalBooks / booksPerPage);
    }
}
