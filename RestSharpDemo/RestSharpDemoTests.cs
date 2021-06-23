using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace RestSharpDemo
{
    [TestFixture]
    class RestSharpDemoTests
    {
        private RestClient _client;

        [OneTimeSetUp]
        public void SetUpEnvironment()
        {
            _client = new RestClient("https://reqres.in/");
        }
        [Test]
        public void GetTest()
        {
            RestRequest restRequest = new RestRequest("/api/users/2", DataFormat.Json);

            IRestResponse restResponse = _client.Execute(restRequest, Method.GET);

            Assert.That((restResponse.StatusCode.ToString()).ToLower().Contains("ok"));
        }
        [Test]
        public void CreateTest()
        {
            RestRequest restRequest = new RestRequest("/api/users", DataFormat.Json);

            string jsonString = "{\"name\": \"morpheus\",\"job\": \"leader\" }" ;
            JObject requestBody = JObject.Parse(jsonString);

            restRequest.AddJsonBody(requestBody);

            IRestResponse restResponse = _client.Execute(restRequest, Method.POST);

            Assert.That((restResponse.StatusCode.ToString()).ToLower().Contains("created"));
        }
        [Test]
        public void DeleteTest()
        {
            RestRequest restRequest = new RestRequest("/api/users/2", DataFormat.Json);

            IRestResponse restResponse = _client.Execute(restRequest, Method.DELETE);

            Assert.That((restResponse.StatusCode.ToString()).ToLower().Contains("nocontent"));
        }
    }
}
