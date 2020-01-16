using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Entities;

namespace Database.Entities
{
    public class User : IUser
    {
        /*
         * 
         * PayDay works differently depending on if IsMonthly is true or not.
         * If IsMonthly is true it means they use monthly budgets and therefore payday is the physical day of the month
         * if they use weekly budgets then PayDay refers to the day of the week with 0 being Monday and 6 being Sunday
         * 
         */

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int PayDay { get; set; }
        public bool IsMonthly { get; set; }
    }
}
