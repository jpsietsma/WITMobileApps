using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WitWebAPI.Services
{
    public class DatabaseStore : IDBStore
    {
        public string TestString { get; set; }


        public DatabaseStore()
        {
            TestString = "Woo this is a test";
        }

        public string GetTestString()
        {
            return TestString;
        }
    }
}
