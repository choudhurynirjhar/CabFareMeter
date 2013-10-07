using System.Web.Http;
using Microsoft.Practices.Unity;
using CabFareMeter.Contracts;
using CabFareMeter.Models;
using CabFareMeter.BL;
using System.Configuration;
using System;

namespace CabFareMeter
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterInstance<ICalculator<FareInput>>(new FareCalculator(new Config()
            {
                BaseFare = Convert.ToDouble(ConfigurationManager.AppSettings["BaseFare"]),
                UnitFare = Convert.ToDouble(ConfigurationManager.AppSettings["UnitFare"]),
                MileUnit = Convert.ToDouble(ConfigurationManager.AppSettings["MileUnit"]),
                MinuteUnit = Convert.ToDouble(ConfigurationManager.AppSettings["MinuteUnit"]),
                NightSurcharge = Convert.ToDouble(ConfigurationManager.AppSettings["NightSurcharge"]),
                PeakHourWeekdaySurcharge = Convert.ToDouble(ConfigurationManager.AppSettings["PeakHourWeekdaySurcharge"]),
                NewYorkStateTaxSurcharge = Convert.ToDouble(ConfigurationManager.AppSettings["NewYorkStateTaxSurcharge"]),
            }));

            return container;
        }
    }
}