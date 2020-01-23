using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Entities;

namespace BudgetApp.Models
{
    public class MainPageViewModel
    {
        public List<Budget> ActiveBudgets { get; set; }
        public List<Income> RecentIncomeRecords { get; set; }
        public List<Purchase> RecentPurchases { get; set; }
        public List<Fuel> RecentFuel { get; set; }
        public bool IsMonthly { get; set; }
        public int PayDay { get; set; }

        public MainPageViewModel()
        {
            ActiveBudgets = new List<Budget>();
            RecentIncomeRecords = new List<Income>();
            RecentPurchases = new List<Purchase>();
            RecentFuel = new List<Fuel>();
            IsMonthly = true;
            PayDay = 0;
        }

    }
}
