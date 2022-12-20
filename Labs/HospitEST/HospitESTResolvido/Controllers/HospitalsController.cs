using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitEST.Data;
using HospitEST.Models;

namespace HospitEST.Controllers
{
    //Nivel 2
    public class HospitalsController : Controller
    {
        private readonly HospitESTContext _context;

        public HospitalsController(HospitESTContext context)
        {
            _context = context;
        }

        // GET: Hospitals
        public async Task<IActionResult> Index()
        {
              return View(await _context.Hospital.ToListAsync());
        }

        // GET: Hospitals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }

            var hospital = await _context.Hospital
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospital == null)
            {
                return NotFound();
            }
            //Nivel 3
            hospital.Doctors = _context.Doctor.Where(d => d.HospitalId == id).ToList();

            return View(hospital);
        }

        private bool HospitalExists(Guid id)
        {
          return _context.Hospital.Any(e => e.Id == id);
        }
    }
}
