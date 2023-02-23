using MediESTeca.Areas.Identity.Data;
using MediESTeca.Controllers;
using MediESTeca.Data;
using MediESTeca.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MediESTecaTest
{
    public class GestaoUtentesControllerTest : IClassFixture<IdentityMediatecaEstContextFixture>
    {
        private MediESTecaComIdentityContext _context;

        public GestaoUtentesControllerTest(IdentityMediatecaEstContextFixture contextFixture)
        {
            _context = contextFixture.DbContext;
        }

        [Fact]
        public async Task Edit_ReturnsNotFound_WhenUserDontExist()
        {
            var mockUserManager = new Mock<UserManager<Utente>>(new Mock<IUserStore<Utente>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<Utente>>().Object,
                new IUserValidator<Utente>[0],
                new IPasswordValidator<Utente>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<Utente>>>().Object);


            mockUserManager.Setup(u => u.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync((string userId) => null);

            var controller = new GestaoUtentesController(_context, mockUserManager.Object);

            var result = await controller.Edit("12");

            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public async Task Edit_ReturnsViewResult_WhenUserExist()
        {
            var mockUserManager = new Mock<UserManager<Utente>>(new Mock<IUserStore<Utente>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<Utente>>().Object,
                new IUserValidator<Utente>[0],
                new IPasswordValidator<Utente>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<Utente>>>().Object);


            mockUserManager.Setup(u => u.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync((string userId) => new Utente
                {
                    Id = Guid.NewGuid().ToString(),
                    Nome = "Joao",
                    Email = "joao@ip.pt",
                    Telefone = 123456789
                });

            var controller = new GestaoUtentesController(_context, mockUserManager.Object);

            var result = await controller.Edit("12");

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<UtenteEditViewModel>(
                viewResult.ViewData.Model);
            Assert.NotNull(model);

        }
    }
}
