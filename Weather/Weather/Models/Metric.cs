using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    public class Metric
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }
}
