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
        // POST: api/<getpoints>
        [Route("getpoints")]
        [HttpPost]
        public ActionResult PointsCalculations(Offer offer)
        {
            try
            {
                int rewards = 0;
                int Emp_id = offer.Emp_Id;
                IEnumerable<Point> list_point = _context.Points.Where(x => x.Emp_Id == Emp_id);

                Point point = new Point();
                if (list_point.Any())
                {
                    point = list_point.First();
                    rewards = point.Emp_Point;
                }
                int diff_date = (DateTime.Now - offer.Start_Date).Days;
                int engage_diif_date = (offer.Engaged_Date - offer.Start_Date).Days;
                int n_likes = (int)offer.N_Likes;
                if (n_likes > 50 && diff_date <= 2)
                {
                    rewards += 10;
                }
                if (n_likes > 100 && diff_date <= 2)
                {
                    rewards += 50;
                }
                if (engage_diif_date <= 2)
                {
                    rewards += 100;
                }
                if (list_point.Any())
                {
                    point.Emp_Id = Emp_id;
                    point.Emp_Point = rewards;
                    _context.Points.Update(point);
                }
                else
                {
                    Point temp = new Point();
                    temp.Emp_Id = Emp_id;
                    temp.Emp_Point = rewards;
                    _context.Points.Add(temp);
                }
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<points>/5
        [Route("points/{id}")]
        [HttpGet]
        public ActionResult FetchPoints(int id)
        {
            try
            {
                var Emp = _context.Points.Where(point => point.Emp_Id == id);
                if (!Emp.Any())
                {
                    return NotFound();
                }
                return Ok(Emp.First().Emp_Point);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
