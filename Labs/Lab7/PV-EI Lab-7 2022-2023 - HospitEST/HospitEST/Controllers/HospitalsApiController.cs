using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitEST.Data;
using HospitEST.Models;

namespace HospitEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsApiController : ControllerBase
    {
        private readonly HospitESTContext _context;

        public HospitalsApiController(HospitESTContext context)
        {
            _context = context;
        }

        // GET: api/HospitalsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospital>>> GetHospital()
        {
            return await _context.Hospital.ToListAsync();
        }

        // GET: api/HospitalsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hospital>> GetHospital(Guid id)
        {
            var hospital = await _context.Hospital.FindAsync(id);

            if (hospital == null)
            {
                return NotFound();
            }

            return hospital;
        }

        // PUT: api/HospitalsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospital(Guid id, Hospital hospital)
        {
            if (id != hospital.Id)
            {
                return BadRequest();
            }

            _context.Entry(hospital).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HospitalsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hospital>> PostHospital(Hospital hospital)
        {
            _context.Hospital.Add(hospital);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospital", new { id = hospital.Id }, hospital);
        }

        // DELETE: api/HospitalsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospital(Guid id)
        {
            var hospital = await _context.Hospital.FindAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }

            _context.Hospital.Remove(hospital);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HospitalExists(Guid id)
        {
            return _context.Hospital.Any(e => e.Id == id);
        }

        //Nivel 5
        // GET: api/HospitalsApi/5
        [HttpGet("HospitalDoctors/{id}")]
        public async Task<ActionResult<object>> GetHospitalAndDoctors(Guid id)
        {
            var hospital = await _context.Hospital.Include(h => h.Doctors)
                .Select(hospital => new
                {
                    Id = hospital.Id,
                    Name = hospital.Name,
                    Doctors = hospital.Doctors.Select(d => new
                    {
                        Name = d.Name,
                        Practice = d.Practice

                    })
                })
                .FirstOrDefaultAsync(h => Guid.Equals(h.Id, id));

            if (hospital == null)
            {
                return NotFound();
            }


            return hospital;
        }
    }
}
