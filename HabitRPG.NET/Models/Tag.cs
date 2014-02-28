using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace HabitRPG.NET.Models
{
    public class Tag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class TaskTag
    {
        [JsonProperty("id")]
        public string Id { get; set; }       
        public bool Attached { get; set; }
    }
}
