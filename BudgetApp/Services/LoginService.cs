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
        private readonly ICredentialHoldingService _creds;

        public LoginService(BudgetContext context, ICryptographicService crypto, ICredentialHoldingService creds)
        {
            _context = context;
            _crypto = crypto;
            _creds = creds;
        }

        public bool AuthenticateLogin(string username, string password)
        {
            if (!_context.Users.Any(r => r.Username == username))
                return false;

            var user = _context.Users.First(r => r.Username == username);

            var saltedPassword = password + user.Salt;
            var hash = _crypto.Hash(saltedPassword);

            if (hash != user.Password)
                return false;

            // Logged in

            _creds.PopulateService(user);

            return true;
        }
    }
}
