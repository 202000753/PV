using ESTeSoccer.Controllers;
using ESTeSoccer.Data;
using ESTeSoccerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ESTeSoccerTest
{
    public class TeamsControllerTest : IClassFixture<ApplicationDbContextFixture>
    {
        private ESTeSoccerContext _context;

        public TeamsControllerTest(ApplicationDbContextFixture context)
        {
            _context = context.DbContext;
        }

        [Fact]
        public async Task Index_CanLoadFromContext()
        {
            var controller = new TeamsController(_context);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Team>>(
                viewResult.ViewData.Model);
            Assert.Equal(9, model.Count());
        }

        [Fact]
        public void CreateGet_ReturnsViewResult()
        {
            var controller = new TeamsController(_context);

            var result = controller.Create();

            var viewResult = Assert.IsType<ViewResult>(result);
            
        }

        [Fact]
        public void CreateGet_SetLeagueIdInViewData()
        {
            var controller = new TeamsController(_context);

            var result = controller.Create();

            var viewData = controller.ViewData["LeagueId"];
            Assert.NotNull(viewData);
            Assert.IsType<SelectList>(viewData);
            Assert.True((viewData as SelectList).Count() > 0);
            var viewResult = Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public async Task CreatePost_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            var controller = new TeamsController(_context);
            controller.ModelState.AddModelError("Erro", "Erro adicionado para teste");
            Team scb = new Team { TeamId = (_context.Team.First(t => t.Name.Contains("Sporting"))).TeamId, LeagueId = 1, Name = "Sporting Clube Braga", Initials = "SCB", FoundingDate = new DateTime(1921, 01, 19), MainColor = "Red", NumberOfTitles = 5 };

            var result = await controller.Create(scb);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task CreatePost_ReturnsRediretionToActionResult_WhenModelStateValid()
        {
            var controller = new TeamsController(_context);
            Team scb = new Team { TeamId = 10, LeagueId = 1, Name = "Sporting Clube Braga", Initials = "SCB", FoundingDate = new DateTime(1921, 01, 19), MainColor = "Red", NumberOfTitles = 5 };

            var result = await controller.Create(scb);

            Assert.IsType<RedirectToActionResult>(result);
            var delete = controller.DeleteConfirmed(10);
        }
        
        [Fact]
        public async Task CreatePost_SetsLeagueIdInViewData_WhenModelStateInValid()
        {
            var controller = new TeamsController(_context);
            controller.ModelState.AddModelError("Erro", "Erro adicionado para teste");
            Team scb = new Team { TeamId = (_context.Team.First(t => t.Name.Contains("Sporting"))).TeamId, LeagueId = 1, Name = "Sporting Clube Braga", Initials = "SCB", FoundingDate = new DateTime(1921, 01, 19), MainColor = "Red", NumberOfTitles = 5 };

            var result = await controller.Create(scb);

            var viewdata = controller.ViewData["LeagueId"];
            Assert.NotNull(viewdata);
            Assert.IsType<SelectList>(viewdata);
        }

    }
}
