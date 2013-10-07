using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CabFareMeter.Models
{
    public class Config
    {
        public double BaseFare { get; set; }
        public double UnitFare { get; set; }
        public double MileUnit { get; set; }
        public double MinuteUnit { get; set; }
        public double NightSurcharge { get; set; }
        public double PeakHourWeekdaySurcharge { get; set; }
        public double NewYorkStateTaxSurcharge { get; set; }
    }
}