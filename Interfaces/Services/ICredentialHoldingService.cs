using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Entities;

namespace Interfaces.Services
{
    public interface ICredentialHoldingService
    {
        void PopulateService(IUser user);

        void WipeService();

        bool LoggedIn { get; }

        bool IsAdmin { get; }

        string Username { get; }

        string Email { get; }
    }
}
