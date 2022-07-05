using Microsoft.AspNetCore.Mvc;
using OffersMicroservices.Database;
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
        // Api to get all the offers 
        [Route("Offer")]
        [HttpGet]
        public IEnumerable<Offer> Offer()
        {
            return db.Offers.ToList();
        }

        // GET: api/<getOfferDetails>/5
        [Route("getOfferDetails/{id}")]
        [HttpGet]
        public Offer GetOfferDetails(int id)
        {
            return db.Offers.Find(id);
        }

        // GET: api/<getOfferDetailsByCategory>/5
        [Route("getOfferDetailsByCategory/{id}")]
        [HttpGet]
        public List<Offer> GetOfferDetailsByCategory(int id)
        {
            List<Offer> filtered = new List<Offer>();

            foreach (Offer offer in db.Offers)
            {
                if (offer.Category_Id == id)
                {
                    filtered.Add(offer);
                }
            }
            return filtered;
        }



        //[HttpGet("{id}")]
        //public Offer Get(int id)
        //{
        //    return db.Offers.Find(id);
        //}

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
