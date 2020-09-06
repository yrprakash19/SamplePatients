using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamplePatients.Models;

namespace SamplePatients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientContext _context;

        public PatientsController(PatientContext context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(string id)
        {
            var patient = await _context.TodoItems.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }
        //// GET: api/Patients/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Patient>> GetPatient(string id)
        //{
        //    var patient = await _context.TodoItems.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    return patient;
        //}

        // PUT: api/Patients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(string id, Patient patient)
        {
            if (id != patient.PatientId)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
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

        // POST: api/Patients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            _context.TodoItems.Add(patient);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PatientExists(patient.PatientId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPatient", new { id = patient.PatientId }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> DeletePatient(string id)
        {
            var patient = await _context.TodoItems.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        //private bool PatientExists(long id)
        //{
        //    return _context.TodoItems.Any(e => e.AutoId == id);
        //}

        private bool PatientExists(string id)
        {
            return _context.TodoItems.Any(e => e.PatientId == id);
        }
    }
}
