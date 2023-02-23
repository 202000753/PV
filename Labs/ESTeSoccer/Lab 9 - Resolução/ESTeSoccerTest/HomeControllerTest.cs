using ESTeSoccer.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ESTeSoccerTest
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            var controller = new HomeController(null);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Privacy_ReturnsViewResult()
        {
            var controller = new HomeController(null);

            var result = controller.Privacy();

            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}