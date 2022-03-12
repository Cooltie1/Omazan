using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omazan.Models
{
    public interface IOmazanRepository
    {
        IQueryable<Books> Books { get; }
        public void SaveBook(Books book);
        public void CreateBook(Books book);
        public void DeleteBook(Books book);
    }
}
