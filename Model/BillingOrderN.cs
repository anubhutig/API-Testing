using API_july2021.Utility;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace API_july2021.Model
{
    public class BillingOrderN
    {
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("AddressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("AddressLine2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("Comment")]
        public string Comment { get; set; }

        [JsonProperty("ZipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        public BillingOrderN(string firstName=null, string lastName=null, string email=null, string addressLine1=null, string addressLine2=null, string phoneNumber=null, string comment=null, string zipCode=null)
        {
            FirstName = firstName ?? DataGenerator.FullName;
            LastName = lastName ?? DataGenerator.GetRandomString(10);
            Email = email ?? DataGenerator.GetRandomString();
            AddressLine1 = addressLine1 ?? DataGenerator.GetRandomString(15);
            AddressLine2 = addressLine2 ?? DataGenerator.GetRandomString();
            PhoneNumber = phoneNumber ?? DataGenerator.GetRandomString();
            Comment = comment ?? DataGenerator.GetRandomString();
            ZipCode = zipCode ?? DataGenerator.GetRandomString();
            //Id = id;
        }
    }
}
