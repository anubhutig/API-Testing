using API_july2021.Model;
using API_july2021.API;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using ApprovalTests.Reporters;

namespace API_july2021
{
    [UseReporter(typeof(VisualStudioReporter))]
    public class Tests
    {
        BillingOrder billingOrder;
        [SetUp]

        public void Setup()
        {
            billingOrder = new BillingOrder();
        }

        [TestCaseSource(nameof(BillingOrderTestCaseData))]
        public void CreateOrderTestCase(BillingOrderN expectedorder)
        {
            // Data Object

            string jsonBody = JsonConvert.SerializeObject(expectedorder);
            IRestResponse response = billingOrder.PostOrder(jsonBody);
            BillingOrderBase actualorder = JsonConvert.DeserializeObject<BillingOrderBase>(response.Content);
            expectedorder.Should().BeEquivalentTo(actualorder.Data, options => options.Excluding(o => o.Id));

        }

        public static IEnumerable BillingOrderTestCaseData
        {
            get
            {
                yield return new TestCaseData(new BillingOrderN
                {
                    FirstName = "Anu",
                    LastName = "Gupta",
                    Email = "AnuG@gmail.com",
                    AddressLine1 = "albert ave",
                    AddressLine2 = "qld",
                    PhoneNumber = "7798120487",
                    Comment = "Test123",
                    ZipCode = "445577"
                }).SetName("Create Billing Order Test Case");

                yield return new TestCaseData(new BillingOrderN()).SetName("Default Test Data");
                yield return new TestCaseData(new BillingOrderN(email: "123")).SetName("Email validation with default data");

            }
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
            // Data Object

            var expectedorder = new BillingOrderN
            {
                FirstName = "Anu",
                LastName = "Gupta",
                Email = "AnuG@gmail.com",
                AddressLine1 = "albert ave",
                AddressLine2 = "qld",
                PhoneNumber = "7798120487",
                Comment = "Test123",
                ZipCode = "445577"
            };
            string jsonBody = JsonConvert.SerializeObject(expectedorder);


            BillingOrder billingorder = new BillingOrder();
            IRestResponse response = billingorder.PostOrder(jsonBody);

            // Log
            Console.WriteLine(response.Content);

            // Assertions
            BillingOrderBase actualorder = JsonConvert.DeserializeObject<BillingOrderBase>(response.Content);
            Id = actualorder.Data.Id + "";

            Assert.AreEqual(expectedorder.FirstName, actualorder.Data.FirstName);

            //Hack
            // expectedorder.Id = actualorder.Data.Id;

            expectedorder.Should().BeEquivalentTo(actualorder.Data, options => options.Excluding(o => o.Id));



        }

        string Id = null;
        [TearDown]
        public void CleanUp()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                BillingOrder billingorder = new BillingOrder();
                billingorder.DeleteOrderById(Id);
                Id = null;
            }
        }

        IWebDriver driver = new ChromeDriver();

        // Data Object

        BillingOrderN expectedorder = new BillingOrderN
        {
            FirstName = "Anu",
            LastName = "Gupta",
            Email = "AnuG@gmail.com",
            PhoneNumber = "7798120487",
            AddressLine1 = "albert ave",
            AddressLine2 = "qld",
            Comment = "Test123",
            ZipCode = "445577"
        };



        [Test]
        public void TC_UI_Test()
        {

            BillingSubmissionFormTest orderpage = new BillingSubmissionFormTest(driver);

            orderpage.BillingSubmissionForm(expectedorder);


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

        [TestCaseSource(nameof(BillingOrderCSVTestCaseData))]
        public void CreateOrderCSVTestCase(BillingOrderN expectedorder)
        {
            // Data Object

            string jsonBody = JsonConvert.SerializeObject(expectedorder);
            IRestResponse response = billingOrder.PostOrder(jsonBody);
            BillingOrderBase actualorder = JsonConvert.DeserializeObject<BillingOrderBase>(response.Content);
            expectedorder.Should().BeEquivalentTo(actualorder.Data, options => options.Excluding(o => o.Id));

        }


        public static IEnumerable BillingOrderCSVTestCaseData()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"TestData\BillingOrderData.csv";
            using (var csv = new CsvReader(new StreamReader(Path.Combine(path)), true))
            {
                while (csv.ReadNextRecord())
            {
                    // Test Data
                string description = csv["description"];
                 BillingOrderN order = new BillingOrderN(
                     firstName: csv["firstname"],
                     lastName: csv["lastname"],
                     email: csv["email"],
                     addressLine1: csv["addressline1"],
                     addressLine2: csv["addressline2"],
                     phoneNumber: csv["phone"],
                     comment: csv["comment"],                                         
                     zipCode: csv["zipcode"]
                     );
                 yield return new TestCaseData(order).SetName(description);
              }
                
            }
        }

        [Test]
        public void CreateOrderTestSnapShot()
        {
            

            BillingOrderN expectedorder = new BillingOrderN
            {
                FirstName = "Anu",
                LastName = "Gupta",
                Email = "AnuG@gmail.com",
                AddressLine1 = "albert ave",
                AddressLine2 = "qld",
                PhoneNumber = "7798120487",
                Comment = "Test123",
                ZipCode = "445577"
            };
            string jsonBody = JsonConvert.SerializeObject(expectedorder);


            BillingOrder billingorder = new BillingOrder();
            IRestResponse response = billingorder.PostOrder(jsonBody);

            // Log
            Console.WriteLine(response.Content);

           BillingOrderBase actualorder = JsonConvert.DeserializeObject<BillingOrderBase>(response.Content);
         
            ApprovalTests.Approvals.VerifyJson(response.Content);



        }

    }
}