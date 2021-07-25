using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_july2021.Utility
{
    class DataGenerator
    {
        public string GetRandomString()
        {
            return TestContext.CurrentContext.Random.GetString(10, "abcdefghijklmnopqrstuvwxyz");
        }
    }
}
