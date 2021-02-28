using System;
using System.Collections.Generic;
using System.Text;

namespace Misis2.Model
{
    public class Discipline
    {
        public string Name { get; set; }
    }
    public class TestModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public decimal Ask { get; set; }
        public decimal Bid { get; set; }
    }
}
