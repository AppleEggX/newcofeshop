using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BasketItemDTO
    {
        public int Id { get; set; }
        public string CoffeeName { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
