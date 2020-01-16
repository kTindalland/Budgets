using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Services;
using Database;
using Database.Entities;

namespace BudgetApp.Services
{
    public class LoginService : ILoginService
    {
        private readonly BudgetContext _context;
        private readonly ICryptographicService _crypto;

        public LoginService(BudgetContext context, ICryptographicService crypto)
        {
            _context = context;
            _crypto = crypto;
        }

        public bool AuthenticateLogin(string username, string password)
        {
            //TESTING START

            //var salt = _crypto.GenerateSalt();
            //var hash = _crypto.Hash(password + salt);

            //var newUser = new User()
            //{
            //    Username = username,
            //    Password = hash,
            //    Salt = salt,
            //    PayDay = 15,
            //    IsMonthly = false
            //};

            //_context.Users.Add(newUser);
            //_context.SaveChanges();

            //return true;

            //TESTING END

            if (!_context.Users.Any(r => r.Username == username))
                return false;

            var user = _context.Users.First(r => r.Username == username);

            var saltedPassword = password + user.Salt;
            var hash = _crypto.Hash(saltedPassword);

            if (hash != user.Password)
                return false;

            return true;
        }
    }
}
