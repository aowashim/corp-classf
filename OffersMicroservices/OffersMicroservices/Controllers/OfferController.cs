using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OffersMicroservices.Database;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OffersMicroservices.Controllers
{
    [Route("api")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly DatabaseContext db;
        public OfferController()
        {
            db = new DatabaseContext();
        }

        // GET: api/<offer>
        // API to get all the offers 
        [Route("Offer")]
        [HttpGet]
        public IEnumerable<Offer> Offer()
        {
            return db.Offers.ToList();
        }

        // GET: api/<getOfferDetails>/5
        // API to fetch data on the basis on offerID
        [Route("getOfferDetails/{id}")]
        [HttpGet]
        public Offer GetOfferDetails(int id)
        {
            return db.Offers.Find(id);
        }

        // GET: api/<getOfferDetailsByCategory>/5
        // API to fetch filtered data on the basis of category
        [Route("getOfferDetailsByCategory/{id}")]
        [HttpGet]
        public IEnumerable<Offer> GetOfferDetailsByCategory(int id)
        {
            return db.Offers.Where(offer => offer.Category_Id == id);
        }

        // GET: api/<offer>
        // API to get all the offers sorted by no of likes
        [Route("getOfferByTopLikes")]
        [HttpGet]
        public ActionResult<IEnumerable<Offer>> GetOfferByTopLikes()
        {
            try
            {
                return db.Offers.OrderByDescending(o => o.N_Likes).ToList();

            }
            catch (Exception e)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
                return BadRequest(e.Message);
            }
        }


        // GET: api/<offer>
        // API to get all the offers sorted by no of likes
        [Route("getOfferByPostedDate")]
        [HttpGet]
        public IEnumerable<Offer> GetOfferByPostedDate()
        {
            try
            {
                IEnumerable<Offer> result = db.Offers.OrderByDescending(o => o.Start_Date).ToList();

                if (result == null)
                {
                    return (IEnumerable<Offer>)NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return (IEnumerable<Offer>)StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }

        }


        // POST api/<OfferController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OfferController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OfferController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
