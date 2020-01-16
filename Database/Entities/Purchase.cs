using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public string FriendlyName { get; set; }
        public decimal Price { get; set; }
    }
}
