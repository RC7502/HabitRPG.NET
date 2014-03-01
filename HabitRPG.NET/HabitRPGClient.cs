using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            var taskList = JsonConvert.DeserializeObject<List<Task>>(response.Content);

            return taskList;
        }

        public List<ExportHistory> GetExportHistory()
        {
            var request = new RestRequest("/export/history", Method.GET);
            request.AddHeader("x-api-key", _apiToken);
            request.AddHeader("x-api-user", _apiUser);

            var response = _restClient.Execute(request);
            var rows = response.Content.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var list = new List<ExportHistory>();
            foreach (var row in rows)
            {             
                var fields = Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                DateTime histDate;
                if (DateTime.TryParse(fields[3].Remove(), out histDate))
                {
                    var history = new ExportHistory()
                        {
                            TaskName = fields[0],
                            TaskID = fields[1],
                            TaskType = fields[2],
                            Date = histDate,
                            Value = Convert.ToDouble(fields[4])
                        };
                    list.Add(history);
                }
            }

            return list;
        }

    }
}
