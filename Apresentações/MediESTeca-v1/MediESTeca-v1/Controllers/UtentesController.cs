using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediESTeca_v1.Data;
using MediESTeca_v1.Models;

namespace MediESTeca_v1.Controllers
{
    public class UtentesController : Controller
    {
        private readonly MediESTecaContext _context;

        public UtentesController(MediESTecaContext context)
        {
            _context = context;
        }

        // GET: Utentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utente.ToListAsync());
        }
    }
}
