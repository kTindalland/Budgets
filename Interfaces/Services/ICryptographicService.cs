using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Services
{
    public interface ICryptographicService
    {
        string GenerateSalt();
        string Hash(string content);
    }
}
