using System;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestSharpDemo
{
    class Program
    {
        public static void ExecuteAsyncMethod()
        {
            RestClient client = new RestClient("https://reqres.in/");

            RestRequest request = new RestRequest("api/register", Method.POST);

            string resposnseBody = "{\"email\": \"sydney@fife\"}";
            request.AddJsonBody(resposnseBody);

            var restResponse = client.Execute<RestResposeBody>(request);

            Console.WriteLine("Hi");

            Console.WriteLine(restResponse.StatusCode);
        }
        static void Main(string[] args)
        {
            RestClient restClient = new RestClient();
            restClient.BaseUrl = new Uri("https://reqres.in/");
        
            RestRequest request = new RestRequest("/api/register", Method.POST);


            string resposnseBody = "{\"email\": \"eve.holt@reqres.in\", \"password\": \"pistol\"}";
            request.AddJsonBody(resposnseBody);

            var restResponse = restClient.Execute(request);

            Console.WriteLine((int)restResponse.StatusCode);
            Console.WriteLine(restResponse.Content);
        }
    }
}
