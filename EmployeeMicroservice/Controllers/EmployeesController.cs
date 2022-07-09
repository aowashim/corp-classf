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
using EmployeeMicroservice.Database;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeMicroservice.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /* --------[SETUP]-------- */

        private readonly EmployeeContext _context;

        public EmployeesController(EmployeeContext context)
        {
            _context = context;
        }

        /* --------[GET REQUESTS]-------- */

        // GET: api/Employees/viewProfile/5
        // API to fetch Employee Profile based on given Employee Id
        [HttpGet("ViewProfile/{id}")]
        public async Task<ActionResult<Employee>> ViewProfile(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET: api/Employees/viewEmployeeOffers/5
        // API to fetch Offers data based on given Employee Id
        [HttpGet("ViewEmployeeOffers/{id}")]
        public async Task<ActionResult<Offer>> ViewEmployeeOffers(int id)
        {
            try
            {
                var emp = await _context.Employees.FindAsync(id);
                var offers = await _context.Offers.Where(x => x.Emp_Id == id).Select(o => new
                {
                    id = o.Id,
                    title = o.Title,
                    description = o.Description,
                    empName = emp.EmpName,
                    likes = o.N_Likes
                }).ToListAsync();

                if (offers == null)
                {
                    return NotFound();
                }
                //var json = JsonSerializer.Serialize(offers);

                return Ok(offers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET: api/Employees/viewEmployeeOffers
        // API to fetch sorted top 3 data on the basis of likes
        [HttpGet("ViewMostLikedOffers")]
        public async Task<ActionResult<Offer>> ViewMostLikedOffers()
        {
            try
            {
                //var top3offers = await _context.Offers.OrderByDescending(x => x.N_Likes).Take(3).ToListAsync();

                var top3offers = await _context.Offers.OrderByDescending(_ => _.N_Likes).Take(3)
                    .Join(_context.Employees, O => O.Emp_Id, e => e.EmpId, (o, e) => new
                    {
                        id = o.Id,
                        title = o.Title,
                        description = o.Description,
                        empName = e.EmpName,
                        likes = o.N_Likes
                    }).ToListAsync();


                if (top3offers == null)
                {
                    return NotFound();
                }
                //var json = JsonSerializer.Serialize(offers);

                return Ok(top3offers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
