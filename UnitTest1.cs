using API_july2021.BillingOrderAPI;
using NUnit.Framework;
using RestSharp;
using System;

namespace API_july2021
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TC_GetOrder()
        {
            BillingOrder billingorder = new BillingOrder();
            IRestResponse response = billingorder.GetOrderById("1362");

            // Log
            Console.WriteLine(response.Content);
            Assert.Pass();
        }

        [Test]
        public void TC_PostOrder()
        {
            for (int i = 0; i <= 4; i++)
            {
                string body = $"{{\"id\":0,\"FirstName\":\"AnuA{i}\",\"LastName\":\"Gupta{i}\",\"Email\":\"Anug@ghm.com\",\"AddressLine1\":\"abcd\",\"AddressLine2\":\"dfg St\",\"PhoneNumber\":\"1234567899\",\"Comment\":\"Test API\",\"ZipCode\":\"4566778\"}}";
                BillingOrder billingorder = new BillingOrder();
                IRestResponse response = billingorder.PostOrder(body);

                // Log
                Console.WriteLine(response.Content);
            }

        }

        [Test]
        public void TC_DeleteOrder()
        {
            BillingOrder billingorder = new BillingOrder();
            IRestResponse response = billingorder.DeleteOrderById("1362");

            // Log
            Console.WriteLine(response.Content);
            Assert.Pass();

        }

        [Test]
        public void TC_GetAllOrders()
        {
            BillingOrder billingorder = new BillingOrder();
            IRestResponse response = billingorder.GetAllOrders();

            // Log
            Console.WriteLine(response.Content);
            Assert.Pass();
        }

        [Test]
        public void TC_PutOrder()
        {
           
                string body = $"{{\"id\":0,\"FirstName\":\"Anubhuti\",\"LastName\":\"Gupta\",\"Email\":\"Anug@ghm.com\",\"AddressLine1\":\"abcd\",\"AddressLine2\":\"dfg St\",\"PhoneNumber\":\"1234567899\",\"Comment\":\"Test API\",\"ZipCode\":\"4566778\"}}";
                BillingOrder billingorder = new BillingOrder();
                IRestResponse response = billingorder.PutOrder("1381", body);

                // Log
                Console.WriteLine(response.Content);
           

        }

    }
}