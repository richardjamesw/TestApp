using System;

namespace TestApp1.Models
{
    public class TestModel
    {
        public long id { get; set; }
        public string MachineName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
