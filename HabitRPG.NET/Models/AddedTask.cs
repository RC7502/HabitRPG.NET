using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace HabitRPG.NET.Models
{
    public class AddedTask
    {
        [JsonProperty("text")]
        public string text { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }
    }
}
