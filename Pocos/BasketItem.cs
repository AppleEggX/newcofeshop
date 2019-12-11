using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }

        //A BasketItem is kind of coffee
        public virtual Coffee Coffee { get; set; }
        //A BasketItem is located into a basket
        public virtual Basket Basket { get; set; }
    }
}
