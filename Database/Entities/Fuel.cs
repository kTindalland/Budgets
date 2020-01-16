using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entities
{
    public class Fuel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public long Milage { get; set; }
        public decimal Price { get; set; }
        public decimal PricePerLitre { get; set; }
    }
}
