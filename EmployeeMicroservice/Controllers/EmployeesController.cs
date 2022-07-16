using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Linq;
using System.Text.Json;
using EmployeeMicroservice.Database.Entities;
using EmployeeMicroservice.Database;
using EmployeeMicroservice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeMicroservice.Controllers
{
    [Route("api")]
    [ApiController]
    //[Authorize]
    public class EmployeesController : ControllerBase
    {
        /* --------[SETUP]-------- */
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /* --------[GET REQUESTS]-------- */

        // GET: api/ViewProfile/5
        // API to fetch Employee Profile based on given Employee Id
        [HttpGet("ViewProfile/{id}")]
        public async Task<ActionResult<Employee>> ViewProfile(int id)
        {
            try 
            {
                if (id < 0) throw new Exception("Invalid ID"); // Throws Exception for Invalid ID.

                var employee = await _employeeService.ViewProfile(id);
                
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

        // GET: api/viewEmployeeOffers/5
        // API to fetch Offers data based on given Employee Id
        [HttpGet("ViewEmployeeOffers/{id}")]
        public async Task<ActionResult<Offer>> ViewEmployeeOffers(int id)
        {
            try
            {
                if (id < 0) throw new Exception("Invalid ID"); // Throws Exception for Invalid ID.

                var offers = await _employeeService.ViewEmployeeOffers(id);

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

        // GET: api/viewEmployeeOffers
        // API to fetch sorted top 3 data on the basis of likes
        [HttpGet("ViewMostLikedOffers")]
        public async Task<ActionResult<Offer>> ViewMostLikedOffers()
        {
            try
            {
                var top3offers = await _employeeService.ViewMostLikedOffers();

                if (top3offers == null)
                {
                    return NotFound();
                }

                else if (top3offers.Count > 3)      // Throwing error for fetching more than 3 offers
                    throw new Exception("Service is not working as intended");
                
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
