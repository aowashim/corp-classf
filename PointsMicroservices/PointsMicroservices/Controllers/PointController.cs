using Microsoft.AspNetCore.Mvc;
using PointsMicroservices.Database;
using PointsMicroservices.Database.Entities;
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

        public PointController()
        {
            _context = new DatabaseContext();
        }
        // POST: api/<refreshPointsOfEmployee>
        [Route("refreshPointsOfEmployee")]
        [HttpPost]
        public ActionResult PointsCalculations(Offer offer)
        {
            try
            {
                int Emp_id = offer.Emp_Id;
                IEnumerable<Employee> list_point = _context.Employees.Where(x => x.EmpId == Emp_id);
                Employee emp = list_point.FirstOrDefault();
                int rewards = emp.Points_Gained;
                int diff_date = (DateTime.Now - offer.Start_Date).Days;
                int engage_diif_date = (offer.Engaged_Date - offer.Start_Date).Days;
                int n_likes = (int)offer.N_Likes;
                if (n_likes % 100==0 && diff_date <= 2)
                {
                    rewards += 50;
                }
                else if (n_likes % 50==0 && diff_date <= 2)
                {
                    rewards += 10;
                }
                if (engage_diif_date <= 2)
                {
                    rewards += 100;
                }
                emp.Points_Gained = rewards;
                _context.Employees.Update(emp);
                _context.SaveChanges();
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
        public ActionResult FetchPoints(int id)
        {
            try
            {
                var Emp = _context.Employees.Where(point => point.EmpId == id);
                if (!Emp.Any())
                {
                    return NotFound();
                }
                return Ok(Emp.First().Points_Gained);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
