using Microsoft.AspNetCore.Mvc;
using PointsMicroservices.Database;
using PointsMicroservices.Database.Entities;
using PointsMicroservices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PointsMicroservices.Controllers
{
    [Route("api")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IPointService _pointService;

        public PointController(IPointService service)
        {
            _pointService=service;

        }
        // POST: api/<refreshPointsOfEmployee>
        [Route("refreshPointsOfEmployee")]
        [HttpPost]
        public async Task<ActionResult> PointsCalculations(Offer offer)
        {
            try
            {
                await _pointService.UpdateAsync(offer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<getPointsOfEmployee>/5
        [Route("getPointsOfEmployee/{id}")]
        [HttpGet]
        public async Task<ActionResult> FetchPoints(int id)
        {
            try
            {
                var Emp =await _pointService.FetchPoints(id);
                if (Emp==null)
                {
                    return NotFound();
                }
                return Ok(Emp.Points_Gained);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //return Emp.First().Points_Gained;
        }
    }
}
