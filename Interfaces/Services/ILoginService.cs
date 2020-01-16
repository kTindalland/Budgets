using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Services
{
    public interface ILoginService
    {
        bool AuthenticateLogin(string username, string password);
    }
}
