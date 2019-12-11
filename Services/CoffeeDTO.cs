using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CoffeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Type { get; set; }
        public double Rating { get; set; }
        public string TastingNote { get; set; }
        public string Story { get; set; }
        public int Storage { get; set; }
        public decimal Price { get; set; }
    }
}
