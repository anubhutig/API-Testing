using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_july2021.Utility
{
    class DataGenerator
    {
        static string a1 = "abcdefghijklmnopqrstuvwxyz";
        static string a2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string num = "0123456789";
        public static string GetRandomString(int len = 15)
        {
            return TestContext.CurrentContext.Random.GetString(len, $"{a1}{a2}");
        }

        public static string GetRandomInt(int len = 10)
        {
            return TestContext.CurrentContext.Random.GetString(len, $"{num}");
        }

        public static string FullName => Faker.Name.FullName();
        
    }
}
