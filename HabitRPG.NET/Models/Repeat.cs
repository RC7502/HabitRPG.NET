using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace HabitRPG.NET.Models
{
    public class Repeat
    {

        [JsonProperty("su")]
        public bool Su { get; set; }

        [JsonProperty("s")]
        public bool S { get; set; }

        [JsonProperty("f")]
        public bool F { get; set; }

        [JsonProperty("th")]
        public bool Th { get; set; }

        [JsonProperty("w")]
        public bool W { get; set; }

        [JsonProperty("t")]
        public bool T { get; set; }

        [JsonProperty("m")]
        public bool M { get; set; }
    }
}
