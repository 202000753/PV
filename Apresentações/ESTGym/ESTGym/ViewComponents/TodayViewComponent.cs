using ESTGym.Services;
using Microsoft.AspNetCore.Mvc;

namespace ESTGym.ViewComponents
{
    public class TodayViewComponent : ViewComponent
    {
        private IToday _today;

        public TodayViewComponent(IToday today)
        {
            _today = today;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_today);
        }
    }
}
