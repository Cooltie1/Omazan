using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omazan.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext _context;
        public EFPurchaseRepository(BookstoreContext tmp)
        {
            _context = tmp;
        }
        public IQueryable<Purchase> Purchases => _context.Purchases.Include(x => x.Lines).ThenInclude(x => x.book);

        public void SavePurchase(Purchase purchase)
        {
            _context.AttachRange(purchase.Lines.Select(x => x.book));

            if (purchase.PurchaseId == 0)
            {
                _context.Purchases.Add(purchase);
            }
            _context.SaveChanges();
        }
    }
}
