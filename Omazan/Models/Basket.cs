using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Omazan.Models
{
    public class Basket
    {
        public List<BasketLineItem> items { get; set; } = new List<BasketLineItem>();
            
        public virtual void AddItem (Books book, int quantity)
        {
            BasketLineItem lineItem = items
                .Where(p => p.book.BookId == book.BookId)
                .FirstOrDefault();

            if (lineItem == null) 
            {
                items.Add(new BasketLineItem
                {
                    book = book,
                    quantity = quantity
                });
            }
            else
            {
                lineItem.quantity += quantity;
            }
        }

        public double CalcTotal()
        {
            double sum = items.Sum(x => x.quantity * x.book.Price);

            return sum;
        }
        public virtual void RemoveItem (Books book)
        {
            items.RemoveAll(x => x.book.BookId == book.BookId);
        }

        public virtual void ClearBasket()
        {
            items.Clear();
        }
    }

    public class BasketLineItem
    {
        [Key]
        public int lineID { get; set; }
        public Books book { get; set; }
        public int quantity { get; set; }
    }
}
