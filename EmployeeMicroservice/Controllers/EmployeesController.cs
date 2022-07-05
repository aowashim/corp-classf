using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using OffersMicroservices.Database;
using System.Linq;
using System.Text.Json;
using EmployeeMicroservice.Database.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly EmployeeContext _context;

        public EmployeesController(EmployeeContext context)
        {
            _context = context;
        }


        // GET: api/Employees/viewProfile/5
        [HttpGet("ViewProfile/{id}")]
        public async Task<ActionResult<Employee>> ViewProfile(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // GET: api/Employees/viewEmployeeOffers/5
        [HttpGet("ViewEmployeeOffers/{id}")]
        public async Task<ActionResult<Offer>> ViewEmployeeOffers(int id)
        {
            var offers = await _context.Offers.Where(x => x.Emp_Id == id).ToListAsync();

            if (offers == null)
            {
                return NotFound();
            }
            //var json = JsonSerializer.Serialize(offers);

            return Ok(offers);
        }

        // GET: api/Employees/viewEmployeeOffers/5
        [HttpGet("ViewMostLikedOffers")]
        public async Task<ActionResult<Offer>> ViewMostLikedOffers()
        {
            var top3offers = await _context.Offers.OrderBy(x => x.N_Likes).Take(3).ToListAsync();

            if (top3offers == null)
            {
                return NotFound();
            }
            //var json = JsonSerializer.Serialize(offers);

            return Ok(top3offers);
        }
    }
}
