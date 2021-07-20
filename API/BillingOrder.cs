using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_july2021.BillingOrderAPI
{
    class BillingOrder
    {
        private readonly string baseURL = "http://api.qaauto.co.nz/api/v1/billingOrders";
        public IRestResponse GetOrderById(string id)
        {
            var client = new RestClient($"{baseURL}/{id}");
            var request = new RestRequest(Method.GET);

            // Execute
            IRestResponse response = client.Execute(request);

            return response;

        }

        public IRestResponse PostOrder(string body)
        {
            var client = new RestClient($"{baseURL}");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            // Execute
            IRestResponse response = client.Execute(request);

            return response;

        }

        public IRestResponse DeleteOrderById(string id)
        {
            var client = new RestClient($"{baseURL}/{id}");
            var request = new RestRequest(Method.DELETE);

            // Execute
            IRestResponse response = client.Execute(request);

            return response;

        }

        public IRestResponse GetAllOrders()
        {
            var client = new RestClient($"{baseURL}");
            var request = new RestRequest(Method.GET);

            // Execute
            IRestResponse response = client.Execute(request);

            return response;

        }

        public IRestResponse PutOrder(string id, string body)
        {
            var client = new RestClient($"{baseURL}/{id}");
            var request = new RestRequest(Method.PUT);

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            // Execute
            IRestResponse response = client.Execute(request);

            return response;

        }
    }
}
