using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CabFareMeter.Models;
using CabFareMeter.Contracts;

namespace CabFareMeter.BL
{
    public class FareCalculator : ICalculator<FareInput>
    {
        private readonly Config _config;
        
        public FareCalculator(Config config)
        {
            _config = config;
        }

        public double Calculate(FareInput input)
        {
            double fare = _config.BaseFare;
            double unit = 0;
            double surcharge = 0;
            if (input.MilesBelow6mph > 0)
            {
                unit = input.MilesBelow6mph * _config.MileUnit;
            }
            if (input.MinutesAbove6mph > 0)
            {
                unit += input.MinutesAbove6mph * _config.MinuteUnit;
            }
            if (input.Time.Hour > 20 && input.Time.Hour < 6)
            {
                surcharge = _config.NightSurcharge;
            }
            if ((input.Date.DayOfWeek >= DayOfWeek.Monday && input.Date.DayOfWeek <= DayOfWeek.Friday)
                && (input.Time.Hour > 16 && input.Time.Hour < 20))
            {
                surcharge += _config.PeakHourWeekdaySurcharge;
            }
            if (input.State == State.NY)
            {
                surcharge += _config.NewYorkStateTaxSurcharge;
            }

            fare += surcharge + unit * _config.UnitFare;

            return fare;
        }
    }
}