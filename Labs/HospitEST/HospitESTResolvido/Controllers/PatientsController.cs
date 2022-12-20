using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitEST.Data;
using HospitEST.Models;
using HospitEST.Utils;

namespace HospitEST.Controllers
{
    //Nivel 1
    public class PatientsController : Controller
    {
        private readonly HospitESTContext _context;
        private readonly int _pageSize = 5;

        public PatientsController(HospitESTContext context)
        {
            _context = context;
        }

        //Nivel 5
        // GET: Patients
        public async Task<IActionResult> Index(string? sortOrder, int? pageNumber, Guid? id)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DoctorSortParm"] = String.IsNullOrEmpty(sortOrder) ? "doc_name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "date" ? "date_desc" : "date";

            IQueryable<Patient> PatientList;
            if (id != null) PatientList = _context.Patient.Include(p => p.Doctor).Where(p => p.DoctorId == id);
            else PatientList = _context.Patient.Include(p => p.Doctor).Select(p => p);
            
            switch (sortOrder)
            {
                case "doc_name_desc":
                    PatientList = PatientList.OrderByDescending(p => p.Doctor.Name);
                    break;
                case "date":
                    PatientList = PatientList.OrderBy(p => p.DateOfBirth);
                    break;
                case "date_desc":
                    PatientList = PatientList.OrderByDescending(p => p.DateOfBirth);
                    break;
                default:
                    PatientList = PatientList.OrderBy(p => p.Doctor.Name);
                    break;
            }

            //return View(PatientList);

            return View(await PaginatedList<Patient>.CreateAsync(PatientList.AsNoTracking(), pageNumber?? 1, _pageSize));
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Patient == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Id");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DoctorId,Name,DateOfBirth,Pathology")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                patient.Id = Guid.NewGuid();
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Id", patient.DoctorId);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Patient == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Id", patient.DoctorId);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DoctorId,Name,DateOfBirth,Pathology")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Id", patient.DoctorId);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Patient == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Patient == null)
            {
                return Problem("Entity set 'HospitESTContext.Patient'  is null.");
            }
            var patient = await _context.Patient.FindAsync(id);
            if (patient != null)
            {
                _context.Patient.Remove(patient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(Guid id)
        {
          return _context.Patient.Any(e => e.Id == id);
        }
    }
}
