using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabFareMeter.Models;
using CabFareMeter.BL;

namespace CabFareMeter.Tests.BL
{
    [TestClass]
    public class FareCalculatorTest
    {
        [TestMethod]
        public void Calculate()
        {
            var input = new FareInput()
            {
                Date = DateTime.Parse("10-08-2010"),
                Time = DateTime.Parse("5:50 PM"),
                MilesBelow6mph = 2,
                MinutesAbove6mph = 5
            };

            var calculator = new FareCalculator(new Config()
            {
                BaseFare = 3,
                UnitFare = 0.35,
                MileUnit = 5,
                MinuteUnit = 1,
                NightSurcharge = 0.5,
                PeakHourWeekdaySurcharge = 1,
                NewYorkStateTaxSurcharge = 0.5
            });
            var result = calculator.Calculate(input);
            Assert.AreEqual(9.75, result);
        }
    }
}
