using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabitRPG.NET.Models
{
    public class ExportHistory
    {
        public string TaskName { get; set; }
        public string TaskID { get; set; }
        public string TaskType { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}
