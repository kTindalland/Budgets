using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Entities
{
    public interface IUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int PayDay { get; set; }
        public bool IsMonthly { get; set; }
    }
}
