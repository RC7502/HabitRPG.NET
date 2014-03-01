using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace HabitRPG.NET.Models
{
    public class History
    {

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }
    }
}
