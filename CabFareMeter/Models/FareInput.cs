using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CabFareMeter.Models
{
    public enum State
    {
        NY,
        NJ
    }

    public class FareInput
    {
        public double MinutesAbove6mph { get; set; }
        public double MilesBelow6mph { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public State State { get; set; }
    }
}