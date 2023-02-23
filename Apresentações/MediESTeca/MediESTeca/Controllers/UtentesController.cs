using MediESTeca.Areas.Identity.Data;
using MediESTeca.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediESTeca.Controllers
{

    [Authorize]
    public class UtentesController : Controller
    {
        private readonly MediESTecaComIdentityContext _context;
        private readonly UserManager<Utente> _userManager;

        public UtentesController(MediESTecaComIdentityContext context,
            UserManager<Utente> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Usa o UserManager para obter a lista de utentes
            return View(await _userManager.Users.ToListAsync());

            // return View(await _context.Users.ToListAsync());
        }
    }

}
