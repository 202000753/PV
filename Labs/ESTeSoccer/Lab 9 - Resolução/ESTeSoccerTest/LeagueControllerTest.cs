using ESTeSoccer.Controllers;
using ESTeSoccer.Data;
using ESTeSoccerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ESTeSoccerTest
{
    public class LeagueControllerTest : IClassFixture<ApplicationDbContextFixture>
    {
        private ESTeSoccerContext _context;

        public LeagueControllerTest(ApplicationDbContextFixture context)
        {
            _context = context.DbContext;
        }

        [Fact]
        public async Task Index_CanLoadFromContext()
        {
            var controller = new LeaguesController(_context);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<League>>(
                viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public async Task Details_ReturnsNotFoundResult_WhenLeagueDoesntExist()
        {
            var controller = new LeaguesController(_context);
            
            var result = await controller.Details(7);

            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public async Task Details_ReturnsNotFoundResult_WhenIdIsNull()
        {
            
            var controller = new LeaguesController(_context);

            var result = await controller.Details(null);

            Assert.IsType<NotFoundResult>(result);
            
        }

        [Fact]
        public async Task Details_RetunrsViewResult_WhenLeagueExists()
        {
            
            var controller = new LeaguesController(_context);

            var result = await controller.Details(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<League>(viewResult.ViewData.Model);
            Assert.Equal(1, model.LeagueId);
            
        }
    }
}
