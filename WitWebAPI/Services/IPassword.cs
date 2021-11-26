using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WitWebAPI.Services
{
    public interface IPassword
    {
        string Hash(string password);

        bool Check(string hash, string password);
    }
}
