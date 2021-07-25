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
            FirstName = firstName ?? TestContext.CurrentContext.Random.GetString(10, "abcdefghijklmnopqrstuvwxyz");
            LastName = lastName ?? TestContext.CurrentContext.Random.GetString(); 
            Email = email ?? TestContext.CurrentContext.Random.GetString() + "@yahoo.com";
            AddressLine1 = addressLine1 ?? TestContext.CurrentContext.Random.GetString();
            AddressLine2 = addressLine2 ?? TestContext.CurrentContext.Random.GetString();
            PhoneNumber = phoneNumber ?? TestContext.CurrentContext.Random.GetString(); 
            Comment = comment ?? TestContext.CurrentContext.Random.GetString(); 
            ZipCode = zipCode ?? TestContext.CurrentContext.Random.GetString();
            //Id = id;
        }
    }
}
