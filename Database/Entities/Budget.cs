using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entities
{
    public class Budget
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FriendlyName { get; set; }
        public decimal BudgetedAmount { get; set; }
        public decimal CurrentSpent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }
        public bool Active { get; set; }
    }
}
