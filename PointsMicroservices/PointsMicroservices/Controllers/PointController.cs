using Microsoft.AspNetCore.Mvc;
using PointsMicroservices.Database;
using PointsMicroservices.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PointsMicroservices.Controllers
{
    [Route("api")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly DatabaseContext db;

        public PointController()
        {
            db = new DatabaseContext();
        }
        // GET: api/<PointController>
        [Route("getpoints")]
        [HttpPost]
        public void PointsCalculations(Offer offer)
        {
            int rewards = 0;
            int Emp_id = offer.Emp_Id;
            IEnumerable<Point> list_point = db.Points.Where(x => x.Emp_Id == Emp_id);

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
                db.Points.Update(point);
            }
            else
            {
                Point temp = new Point();
                temp.Emp_Id = Emp_id;
                temp.Emp_Point = rewards;
                db.Points.Add(temp);
            }
            db.SaveChanges();
            //return Ok();
            //return (offer.End_Date-offer.Start_Date).Days;
        }

        // GET api/<PointController>/5
        [Route("points/{id}")]
        [HttpGet]
        public int FetchPoints(int id)
        {
            IEnumerable<Point> Emp=db.Points.Where(point=>point.Emp_Id==id);
            return (Emp.First().Emp_Point);

        }
    }
}
