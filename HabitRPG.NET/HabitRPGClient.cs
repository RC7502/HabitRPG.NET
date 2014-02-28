using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HabitRPG.NET.Models;
using Newtonsoft.Json;
using RestSharp;

namespace HabitRPG.NET
{
    public class HabitRPGClient
    {
        private string _baseUrl;
        private readonly string _apiUser;
        private readonly string _apiToken;
        private readonly IRestClient _restClient;

        public HabitRPGClient(string baseurl, string apiuser, string apitoken)
        {
            _baseUrl = baseurl;
            _apiUser = apiuser;
            _apiToken = apitoken;
            _restClient = new RestClient(baseurl);
        }

        public List<Task> GetTasks()
        {
            var request = new RestRequest("/user/tasks", Method.GET);
            request.AddHeader("x-api-key", _apiToken);
            request.AddHeader("x-api-user", _apiUser);

            var response = _restClient.Execute<List<Task>>(request);

            return JsonConvert.DeserializeObject<List<Task>>(response.Content);
        }

    }
}
