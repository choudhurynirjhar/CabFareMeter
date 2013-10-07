using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CabFareMeter.Models;
using CabFareMeter.Controllers;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Net;
using CabFareMeter.BL;
using CabFareMeter.Contracts;

namespace CabFareMeter.Tests.Controllers
{
    /// <summary>
    /// Summary description for FareControllerTest
    /// </summary>
    [TestClass]
    public class FareControllerTest
    {
        [TestMethod]
        public void Post()
        {
            var input = new FareInput()
            {
                Date = DateTime.Parse("10-08-2010"),
                Time = DateTime.Parse("5:50 PM"),
                MilesBelow6mph = 2,
                MinutesAbove6mph = 5
            };

            var mockCalculator = new Mock<ICalculator<FareInput>>();
            mockCalculator.Setup(m => m.Calculate(input)).Returns(() => 9.75);          
            
            var controller = new FareController(mockCalculator.Object);

            Setup.SetupApiController(controller);

            var returnVal = controller.Post(input);
            Assert.AreEqual(HttpStatusCode.OK, returnVal.StatusCode);
            Assert.AreEqual(9.75, ((ObjectContent)(returnVal.Content)).Value);
        }

        [TestMethod]
        public void Post_InvalidMiles()
        {
            var input = new FareInput()
            {
                Date = DateTime.Parse("10-08-2010"),
                Time = DateTime.Parse("5:50 PM"),
                MilesBelow6mph = -1,
                MinutesAbove6mph = 5
            };

            var mockCalculator = new Mock<ICalculator<FareInput>>();
            mockCalculator.Setup(m => m.Calculate(input)).Returns(() => 9.75);

            var controller = new FareController(mockCalculator.Object);

            Setup.SetupApiController(controller);

            try
            {
                var returnVal = controller.Post(input);
            }
            catch (HttpResponseException exc)
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, exc.Response.StatusCode);
            }
        }

        [TestMethod]
        public void Post_InvalidMinutes()
        {
            var input = new FareInput()
            {
                Date = DateTime.Parse("10-08-2010"),
                Time = DateTime.Parse("5:50 PM"),
                MilesBelow6mph = 2,
                MinutesAbove6mph = 0
            };

            var mockCalculator = new Mock<ICalculator<FareInput>>();
            mockCalculator.Setup(m => m.Calculate(input)).Returns(() => 9.75);

            var controller = new FareController(mockCalculator.Object);

            Setup.SetupApiController(controller);

            try
            {
                var returnVal = controller.Post(input);
            }
            catch (HttpResponseException exc)
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, exc.Response.StatusCode);
            }
        }

        [TestMethod]
        public void Get()
        {
            var input = new FareInput()
            {
                Date = DateTime.Parse("10-08-2010"),
                Time = DateTime.Parse("5:50 PM"),
                MilesBelow6mph = -1,
                MinutesAbove6mph = 5
            };

            var mockCalculator = new Mock<ICalculator<FareInput>>();
            mockCalculator.Setup(m => m.Calculate(input)).Returns(() => 9.75);

            var controller = new FareController(mockCalculator.Object);

            Setup.SetupApiController(controller);

            try
            {
                var returnVal = controller.Get(1);
            }
            catch (HttpResponseException exc)
            {
                Assert.AreEqual(HttpStatusCode.MethodNotAllowed, exc.Response.StatusCode);
            }
        }

        [TestMethod]
        public void GetAll()
        {
            var input = new FareInput()
            {
                Date = DateTime.Parse("10-08-2010"),
                Time = DateTime.Parse("5:50 PM"),
                MilesBelow6mph = -1,
                MinutesAbove6mph = 5
            };

            var mockCalculator = new Mock<ICalculator<FareInput>>();
            mockCalculator.Setup(m => m.Calculate(input)).Returns(() => 9.75);

            var controller = new FareController(mockCalculator.Object);

            Setup.SetupApiController(controller);

            try
            {
                var returnVal = controller.Get();
            }
            catch (HttpResponseException exc)
            {
                Assert.AreEqual(HttpStatusCode.MethodNotAllowed, exc.Response.StatusCode);
            }
        }

        [TestMethod]
        public void Put()
        {
            var input = new FareInput()
            {
                Date = DateTime.Parse("10-08-2010"),
                Time = DateTime.Parse("5:50 PM"),
                MilesBelow6mph = -1,
                MinutesAbove6mph = 5
            };

            var mockCalculator = new Mock<ICalculator<FareInput>>();
            mockCalculator.Setup(m => m.Calculate(input)).Returns(() => 9.75);

            var controller = new FareController(mockCalculator.Object);

            Setup.SetupApiController(controller);

            try
            {
                controller.Put(1, input);
            }
            catch (HttpResponseException exc)
            {
                Assert.AreEqual(HttpStatusCode.MethodNotAllowed, exc.Response.StatusCode);
            }
        }

        [TestMethod]
        public void Delete()
        {
            var input = new FareInput()
            {
                Date = DateTime.Parse("10-08-2010"),
                Time = DateTime.Parse("5:50 PM"),
                MilesBelow6mph = -1,
                MinutesAbove6mph = 5
            };

            var mockCalculator = new Mock<ICalculator<FareInput>>();
            mockCalculator.Setup(m => m.Calculate(input)).Returns(() => 9.75);

            var controller = new FareController(mockCalculator.Object);

            Setup.SetupApiController(controller);

            try
            {
                controller.Delete(1);
            }
            catch (HttpResponseException exc)
            {
                Assert.AreEqual(HttpStatusCode.MethodNotAllowed, exc.Response.StatusCode);
            }
        }
    }
}
