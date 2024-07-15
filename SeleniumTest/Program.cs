// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium.Chrome;
using System.Text.Json.Serialization;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using NUnit.Framework;
using FluentAssertions;
using RestSharp;
using System.Net;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using Nest;
using Actions = OpenQA.Selenium.Interactions.Actions;
using System.Xml.Linq;
using SeleniumTest;
using OpenQA.Selenium.DevTools.V108.Browser;
using OpenQA.Selenium.Chromium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeleniumExtras;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata;

namespace TestNamespace
{
    class TestProgram
    {
        WebDriver driver;
        

        [SetUp]
        public void startBrowser()
        {
             driver = new EdgeDriver(Paths.pathToDriver);
        }
        [Test]
        public void Dropdown() {
            Console.WriteLine("Test started");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Methods method = new Methods(driver);
            method.Dropdown();
            
            method.returnDriver();
        }
        [Test]
        public void CSSPractice()
        {
            Console.WriteLine("Test started");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Methods method = new Methods(driver);
            method.CSSPractice();

            method.returnDriver();
        }

        [Test]
        public void Test_one()
        {

            Console.WriteLine("Test started");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Methods method = new Methods(driver);

            driver.Navigate().GoToUrl(Paths.WebSitePath);
            method.Expand();
            method.CheckLogo();
            method.CountFooterLinks();
            method.returnDriver();
            //driver.Quit();
        }

        [Test]
        public void Navigate()
        {
            
            Console.WriteLine("Test started");
            Methods method = new Methods(driver);
            driver.Navigate().GoToUrl(Paths.LambdaSitePath);
            method.Expand();
            method.Platform();
            method.Back();
            
            method.returnDriver();
            
            //if (driver != null) {
            //    driver.Close();
            //}
            //driver.Quit();
        }
        [Test]
        public void AlertHandle()
        {

            Console.WriteLine("Test started for Alert");
            Methods method = new Methods(driver);
            method.Alert();

            method.returnDriver();
        }
        [Test]
        public void TitleHandle()
        {

            Console.WriteLine("Test started for Alert");
            Methods method = new Methods(driver);
            method.Title();
            method.returnDriver();

        }
        [Test]
        public void Test_two()
        {
            Console.WriteLine("Test two started");
        }
        public RestResponse GetApiRequest()
        {
            var baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books";
            RestClient client = new RestClient(baseUrl);
            RestRequest restRequest = new RestRequest(baseUrl, Method.Get);
            RestResponse restResponse = client.Execute(restRequest);

            return restResponse;
        }
        public static FakeApiEntities BuildBodyRequest()
        {
            return new FakeApiEntities
            {
                Id = 222,
                Title = "Test Book",
                Description = "Dragan Description",
                Excerpt = "uem num gosta di mim que vai caçá sua turmis!",
                PageCount = 100,
                PublishDate = "2023-09-03T13:50:32.6884665+00:00"
            };
        }
        public RestResponse PostApiRequest()
        {
            var baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books";
            RestClient client = new RestClient(baseUrl);
            var body = BuildBodyRequest();
            RestRequest restRequest = new RestRequest(baseUrl, Method.Post);
            restRequest.AddBody(body, ContentType.Json);

            RestResponse restResponse = client.Execute(restRequest);

            return restResponse;
        }
        public RestResponse GetFApiRequest()
        {
            var baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books";
            RestClient client = new RestClient(baseUrl);
            var body = BuildBodyRequest();
            RestRequest restRequest = new RestRequest(baseUrl, Method.Get);
            //restRequest.AddBody(body, ContentType.Json);

            RestResponse restResponse = client.Execute(restRequest);
            Console.WriteLine("get content and title: " + restResponse.ToString());
            return restResponse;
        }
       
        [Test]
        
        public void CreateABook()
        {
            RestResponse response = PostApiRequest();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
            var bodyContent = JsonSerializer.Deserialize<FakeApiEntities>(response.Content);
            bodyContent.Id.Should().NotBeNull();
            bodyContent.Description.Should().NotBeNull();
            bodyContent.Title.Should().NotBeNull();
            Console.WriteLine("body id, description and title: " + bodyContent.Id +" "+ bodyContent.Title+ " " + bodyContent.Description);
        }
        [Test]
        public void SearchBooks()
        {
            RestResponse response = GetApiRequest();
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //Console.WriteLine("body content and title: " + response.Content);
            Console.WriteLine(JToken.Parse(response.Content).ToString());
            string s = JToken.Parse(response.Content).ToString();
            //"title": "Book 1",
            Assert.Multiple(() =>
            {
                
                Assert.That(s.Contains("\"id\": 1,\r\n    \"title\": \"Book 1\""));
                Assert.That(s.Contains("\"title\": \"Book 2\","));
                //Assert.That(s.Contains("\"title\": \"Book x\","));
            });



        }
        public static FakeApiEntities BuildBodyRequest(int? id = null)
        {
            return new FakeApiEntities
            {
                Id = id ?? 100,
                Title = "Dragan",
                Description = "Mussum Ipsum, cacilds vidis litro abertis.  Quem num gosta di mim que vai caçá sua turmis!",
                Excerpt = "uem num gosta di mim que vai caçá sua turmis!",
                PageCount = 100,
                PublishDate = "2023-09-03T13:50:32.6884665+00:00"
            };
        }
        public RestResponse PutFakeApiRequest(int id)
        {
            var baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books";
            RestClient client = new RestClient(baseUrl);
            var body = BuildBodyRequest(id);
            RestRequest restRequest = new RestRequest($"{baseUrl}/{id}", Method.Put);
            restRequest.AddBody(body, ContentType.Json);

            RestResponse restResponse = client.Execute(restRequest);

            return restResponse;
        }
        [Test]
        public void UpdateABook()
        {
            RestResponse response = PutFakeApiRequest(15);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
            var bodyContent = JsonSerializer.Deserialize<FakeApiEntities>(response.Content);
            bodyContent.Id.Should().NotBeNull();
            bodyContent.Id.Should().Be(15);
            bodyContent.Description.Should().NotBeNull();
            bodyContent.Title.Should().NotBeNull();
        }
        public RestResponse DeleteFakeApiRequest(int id)
        {
            var baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books";
            RestClient client = new RestClient(baseUrl);
            var body = BuildBodyRequest(id);
            RestRequest restRequest = new RestRequest($"{baseUrl}/{id}", Method.Delete);
            restRequest.AddBody(body, ContentType.Json);

            RestResponse restResponse = client.Execute(restRequest);

            return restResponse;
        }
        [Test]
        public void DeleteABook()
        {
            RestResponse response = DeleteFakeApiRequest(15);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
        }
        [Test]
        public void Apiget_test()
        {
            var baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books";
            RestClient client = new RestClient(baseUrl);
            RestRequest restRequest = new RestRequest(baseUrl, Method.Get);
            RestResponse restResponse = client.Execute(restRequest);
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // Example: GET request



        }
        [Test]
        public void Apiget() {
            var baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books";
            RestClient client = new RestClient(baseUrl);
            RestRequest restRequest = new RestRequest(baseUrl, Method.Get);
            RestResponse restResponse = client.Execute(restRequest);
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // Example: GET request

            

        }
        
        [TearDown]
        public void closeBrowser()
        {
            // driver.Close();
            driver.Quit();
        }
    }
}



















