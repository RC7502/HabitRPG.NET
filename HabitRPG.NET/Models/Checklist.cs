using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace HabitRPG.NET.Models
{
    public class Checklist
    {

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }
}
