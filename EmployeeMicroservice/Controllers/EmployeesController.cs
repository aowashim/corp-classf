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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeMicroservice.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /* --------[SETUP]-------- */
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet("test")]
        public IActionResult Get() => Ok("Working.....");

        /* --------[GET REQUESTS]-------- */

        // GET: api/ViewProfile/5
        // API to fetch Employee Profile based on given Employee Id
        [HttpGet("ViewProfile/{id}")]
        public async Task<ActionResult<Employee>> ViewProfile(int id)
        {
            try 
            {
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
