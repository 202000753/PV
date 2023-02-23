using ESTeSoccer.Controllers;
using ESTeSoccer.Data;
using ESTeSoccerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ESTeSoccerTest
{
    public class PlayersControllerTest : IClassFixture<ApplicationDbContextFixture>
    {
        private ESTeSoccerContext _context;

        public PlayersControllerTest(ApplicationDbContextFixture context)
        {
            _context = context.DbContext;
        }
        //Nivel 4
        [Fact]
        public async Task Index_CanLoadFromContext()
        {
            var controller = new PlayersController(_context);

            var result = await controller.Index("Date", null);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Player>>(
                viewResult.ViewData.Model);

            // Fazer o assert para 5 embora existem mais de 5 jogadores porque o controlador apenas
            // envia 5 para a view com base no limite de jogadores por página, para efeitos de validação pode-se alterar o 
            // limite de jogadores por página no PlayersController
            Assert.Equal(5, model.Count());
        }

        [Fact]
        public async Task Index_LastPlayerPageLoaded_WhenLoadsFromContext()
        {
            var controller = new PlayersController(_context);

            var LastPlayerPage = (int)Math.Ceiling((decimal)_context.Player.Count()/5);

            var result = await controller.Index("Date", LastPlayerPage);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Player>>(
                viewResult.ViewData.Model);
            // Assert de 4 pois a página 3 é a ultima página e não irá ter o máximo que é 5 presentes na lista
            Assert.Equal(4, model.Count());
        }
        
        [Fact]
        public void PlayerExists_ReturnsTrue_WhenItExists()
        {
            var controller = new PlayersController(_context);

            var result = controller.PlayerExists(1);

            Assert.True(result);
        }

        [Fact]
        public void PlayerExists_ReturnsFalse_WhenItDoesntExist()
        {
            var controller = new PlayersController(_context);

            var result = controller.PlayerExists(0);

            Assert.False(result);
        }

        //Nivel 5
        [Fact]
        public async Task Delete_ReturnsNotFoundResult_WhenIdIsNull()
        {
            var controller = new PlayersController(_context);

            var result = await controller.Delete(null);

            var viewResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNotFoundResult_WhenPlayerDoesntExist()
        {
            var controller = new PlayersController(_context);

            var result = await controller.Delete(0);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsViewResult_WhenPlayerExist()
        {
            var controller = new PlayersController(_context);

            var result = await controller.Delete(3);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Player>(viewResult.ViewData.Model);
            Assert.NotNull(model);
            Assert.Equal(3, model.PlayerId);

        }

        [Fact]
        public async Task DeleteConfirmed_ReturnsRedirectToActionResult()
        {
            var controller = new PlayersController(_context);

            var result = await controller.DeleteConfirmed(1);

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task EditGet_ReturnsNotFoundResult_WhenIdIsNull()
        {
            var controller = new PlayersController(_context);

            var result = await controller.Edit(null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditGet_ReturnsNotFoundResult_WhenPlayerDoesntExist()
        {
            var controller = new PlayersController(_context);

            var result = await controller.Edit(0);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditGet_ReturnsViewResult_WhenPlayerExists()
        {
            var controller = new PlayersController(_context);

            var result = await controller.Edit(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Player>(
                viewResult.ViewData.Model);
            Assert.NotNull(model);

        }

        [Fact]
        public async Task EditPost_ReturnsNotFoundResult_WhenIdDoesntMatchPlayerId()
        {
            var controller = new PlayersController(_context);
            Player player = _context.Player.FirstOrDefault(p => p.PlayerId == 1);

            var result = await controller.Edit(2, player);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditPost_ReturnsNotFoundResult_WhenPlayerDoesntExist()
        {
            var controller = new PlayersController(_context);

            var result = await controller.Edit(6, new Player { PlayerId = 16 });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditPost_ReturnsViewResult_WhenModelStateIsInValid()
        {
            var controller = new PlayersController(_context);
            Player player = _context.Player.FirstOrDefault(p => p.PlayerId == 1);
            controller.ModelState.AddModelError("Erro", "Erro adicionado para teste");

            var result = await controller.Edit(1, player);

            Assert.IsType<ViewResult>(result);

        }
        
        [Fact]
        public async Task EditPost_ReturnsRedirectToActionResult_WhenPlayerIsUpdated()
        {
            var controller = new PlayersController(_context);
            Player player = _context.Player.FirstOrDefault(p => p.PlayerId == 5);
            player.MarketValue += 50000;

            var result = await controller.Edit(5, player);

            Assert.IsType<RedirectToActionResult>(result);
            Player playerUpdated = _context.Player.FirstOrDefault(p => p.PlayerId == 5);
            Assert.Equal(player.MarketValue, playerUpdated.MarketValue);
        }
        
    }
}
