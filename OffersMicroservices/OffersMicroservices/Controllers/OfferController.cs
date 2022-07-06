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
        /* --------[SETUP]-------- */

        private DateTime def_date = new DateTime(2001, 01, 01);
        private readonly DatabaseContext db;
        public OfferController()
        {
            db = new DatabaseContext();
        }


        /* --------[GET REQUESTS]-------- */


        /*   GET: GET: api/offer
             API to get all the offers     */
        [Route("Offer")]
        [HttpGet]
        public IEnumerable<Offer> Offer()
        {
            return db.Offers.ToList();
        }


        /*   GET: api/getOfferDetails/<offer_id>
             API to fetch data on the basis on offerID    */
        [Route("getOfferDetails/{id}")]
        [HttpGet]
        public ActionResult<Offer> GetOfferDetails(int id)
        {
            try
            {
                return db.Offers.Find(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /*   GET: api/getOfferDetailsByCategory/<category_id>
             API to fetch filtered data on the basis of category    */
        [Route("getOfferDetailsByCategory/{id}")]
        [HttpGet]
        public ActionResult<IEnumerable<Offer>> GetOfferDetailsByCategory(int id)
        {
            try
            {
                return db.Offers.Where(offer => offer.Category_Id == id).ToList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /*   GET: api/getofferbytoplikes
             API to fetch sorted data on the basis of likes    */
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
                return BadRequest(e.Message);
            }
        }


        /*   GET: api/getOfferByPostedDate>
             API to fetch sorted data on the basis of posted date    */
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


        /* --------[POST REQUESTS]-------- */

        /*   POST: api/AddOffer
             API to take an object of offer and store it in database    */
        [Route("addOffer")]
        [HttpPost]
        public void CreateOffer(Offer offer)
        {
            var result = db.Offers.AddAsync(offer);
            db.SaveChanges();
        }


        /*   POST: api/editOffer
             API to edit offer data   */
        [Route("editOffer")]
        [HttpPost]
        public void Edit(int Id, Offer data)
        {

            Offer temp = db.Offers.Find(Id);
            if (temp.Title != null)
            {
                temp.Title = data.Title;
            }
            if (temp.Description != null)
            {
                temp.Description = data.Description;
            }
            if (temp.Start_Date != null)
            {
                temp.Start_Date = data.Start_Date;
            }
            if (temp.End_Date != null)
            {
                temp.End_Date = data.End_Date;
            }
            temp.Engaged_Date = def_date;
            db.Offers.Update(temp);
            db.SaveChanges();
        }


        /*   POST: api/engageOffer
             API fix engage_date of a specific offer_id to current date and time   */
        [Route("engageOffer")]
        [HttpPost]
        public void Engage(int Id, int Emp_Id)
        {
            Offer temp = db.Offers.Find(Id);
            temp.Emp_Id = Emp_Id;
            temp.Engaged_Date = System.DateTime.Now;
            db.Offers.Update(temp);
            db.SaveChanges();

        }

        /* --------[POINTS UTILITY METHODS]-------- */

        /*   GET: api/getOfferDetailsByCategory/<EMP_id>
             API to fetch filtered data on the basis of EMP_ID    */
        [Route("getOfferDetailsByEmpID/{id}")]
        [HttpGet]
        public ActionResult<IEnumerable<Offer>> GetOfferDetailsByEmpId(int id)
        {
            try
            {
                return db.Offers.Where(offer => offer.Emp_Id == id).ToList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}
