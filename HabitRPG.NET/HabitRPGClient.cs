using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using HabitRPG.NET.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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

        public void AddTask(Task newTask)
        {
            try
            {
                var addedTask = new AddedTask
                    {
                        type = newTask.Type,
                        text = newTask.Text,
                        date = newTask.Date
                    };

                var request = new RestRequest("/user/tasks", Method.POST);
                request.AddHeader("x-api-key", _apiToken);
                request.AddHeader("x-api-user", _apiUser);
                //var jsonObj = JsonConvert.SerializeObject(addedTask);            
                request.RequestFormat = DataFormat.Json;
                request.AddBody(addedTask);

                var response = _restClient.Execute(request);
                var error = response.ErrorMessage;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }

        public void ScoreTask(Guid id, string direction)
        {
            try
            {
                var path = string.Format("/user/tasks/{0}/{1}", id, direction);

                var request = new RestRequest(path, Method.POST);
                request.AddHeader("x-api-key", _apiToken);
                request.AddHeader("x-api-user", _apiUser);

                var response = _restClient.Execute(request);
                var error = response.ErrorMessage;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }

        public List<ExportHistory> GetExportHistory()
        {
            var request = new RestRequest("/export/history", Method.GET);
            request.AddHeader("x-api-key", _apiToken);
            request.AddHeader("x-api-user", _apiUser);

            var response = _restClient.Execute(request);

            //this is messy, eventually switch to a CSV parser
            var rows = response.Content.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var list = new List<ExportHistory>();
            foreach (var row in rows)
            {             
                var split = Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                var fields = new List<string>();
                foreach (var item  in split)
                {
                    fields.Add(item.Replace("\"",""));
                }
                DateTime histDate;
                if (fields.Count == 5 && DateTime.TryParse(fields[3], out histDate))
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
