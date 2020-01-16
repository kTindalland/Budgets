using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FriendlyName { get; set; }
        public decimal Amount { get; set; }
    }
}
