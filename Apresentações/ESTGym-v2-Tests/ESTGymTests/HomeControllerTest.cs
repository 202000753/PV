using ESTGym.Controllers;
using ESTGym.Data;
using ESTGym.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ESTGymTests
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            var mockLogger = new Mock<ILogger<HomeController>>();

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ESTGymContext>()
                .UseSqlite(connection)
                .Options;

            using (var context = new ESTGymContext(options))
            {
                context.Database.EnsureCreated();
                context.Person.Add(new Person()
                {
                    Name = "Joao",
                    Age = 17,
                    Weight = 67,
                    Height = 180
                });

                context.Person.Add(new Person()
                {
                    Name = "Ana",
                    Age = 22,
                    Weight = 60,
                    Height = 165
                });

                context.Person.Add(new Person()
                {
                    Name = "Elsa",
                    Age = 18,
                    Weight = 56,
                    Height = 168
                });

                context.SaveChanges();
            }

            using (var context = new ESTGymContext(options))
            {
                var hc = new HomeController(mockLogger.Object, context);

                var result = hc.Index();

                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<Person>>(
                    viewResult.ViewData.Model);
                Assert.NotNull(model);
                Assert.Equal(2, model.Count());
            }
        }


        [Fact]
        public void Privacy_ReturnsViewResult()
        {
            var hc = new HomeController(null, null);

            var result = hc.Privacy();

            Assert.IsType<ViewResult>(result);
        }
              

        [Fact]
        public void Error_ReturnsViewResult()
        {
            var mockLogger = new Mock<ILogger<HomeController>>();
            var hc = new HomeController(mockLogger.Object, null);

            var mockHttpContext = new Mock<Microsoft.AspNetCore.Http.HttpContext>();
            mockHttpContext.Setup(h => h.TraceIdentifier).Returns("Test");
            hc.ControllerContext = new ControllerContext();
            hc.ControllerContext.HttpContext = mockHttpContext.Object;    

            var result = hc.Error();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ErrorViewModel>(
                viewResult.ViewData.Model);
            Assert.NotNull(model);           
        }

        [Theory]
        [InlineData(18, true)]
        [InlineData(17, false)]
        [InlineData(19, true)]
        [InlineData(0, false)]
        [InlineData(1, false)]
        public void IsAdult_CheckResult(int age, bool expected)
        {
            var p = new Person { Age = age };

            var result = HomeController.IsAdult(p);

            Assert.Equal(expected, result);
        }
    }
}
