using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omazan.Models
{
    public class EFOmazanRepository : IOmazanRepository
    {
        private BookstoreContext _context { get; set; }

        public EFOmazanRepository (BookstoreContext tmp)
        {
            _context = tmp;
        }

        public IQueryable<Books> Books => _context.Books;
    }
}
