using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OffersMicroservices.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult<Offer>> Offer()
        {
            try
            {
                //var result = await db.Offers.ToListAsync();

                // performing join between offers and employees table to get employee name
                var result = from o in db.Offers
                             from e in db.Employees
                             where o.Emp_Id == e.EmpId
                             select new
                             {
                                 id = o.Id,
                                 title = o.Title,
                                 description = o.Description,
                                 empName = e.EmpName,
                                 likes = o.N_Likes
                             };

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /*   GET: api/getOfferDetails/<offer_id>
             API to fetch data on the basis on offerID    */
        [Route("getOfferDetails/{id}")]
        [HttpGet]
        public async Task<ActionResult<Offer>> GetOfferDetails(int id)
        {
            try
            {
                //var result = await db.Offers.FindAsync(id);

                // performing join between offers and employees table to get employee name
                //var result = from o in db.Offers
                //             from e in db.Employees
                //             where o.Emp_Id == e.EmpId && o.Id == id
                //             select new
                //             {
                //                 o,
                //                 e.EmpName
                //             };

                var result = db.Offers.Where(o => o.Id == id).Include(o => o.Offer_Category)
                    .Join(db.Employees, O => O.Emp_Id, e => e.EmpId, (o, e) => new { o, e.EmpName });

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /*   GET: api/getOfferDetailsByCategory/<category_id>
             API to fetch filtered data on the basis of category    */
        [Route("getOfferDetailsByCategory/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOfferDetailsByCategory(int id)
        {
            try
            {
                //var result = db.Offers.Where(offer => offer.Category_Id == id).ToList();

                // performing join between offers and employees table to get employee name
                var result = from o in db.Offers
                             from e in db.Employees
                             where o.Emp_Id == e.EmpId && o.Category_Id == id
                             select new
                             {
                                 id = o.Id,
                                 title = o.Title,
                                 description = o.Description,
                                 empName = e.EmpName,
                                 likes = o.N_Likes
                             };

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
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
        public async Task<ActionResult<IEnumerable<Offer>>> GetOfferByTopLikes()
        {
            try
            {
                //var result = db.Offers.OrderByDescending(o => o.N_Likes).ToList();

                // performing join between offers and employees table to get employee name
                var result = from o in db.Offers
                             from e in db.Employees
                             where o.Emp_Id == e.EmpId
                             orderby o.N_Likes descending
                             select new
                             {
                                 id = o.Id,
                                 title = o.Title,
                                 description = o.Description,
                                 empName = e.EmpName,
                                 likes = o.N_Likes
                             };

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

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
        public async Task<ActionResult<Offer>> GetOfferByPostedDate()
        {
            try
            {
                //var result = db.Offers.OrderByDescending(o => o.Start_Date).ToList();

                // performing join between offers and employees table to get employee name
                var result = from o in db.Offers
                             from e in db.Employees
                             where o.Emp_Id == e.EmpId
                             orderby o.Start_Date descending
                             select new
                             {
                                 id = o.Id,
                                 title = o.Title,
                                 description = o.Description,
                                 empName = e.EmpName,
                                 likes = o.N_Likes
                             };

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /* --------[POST REQUESTS]-------- */

        /*   POST: api/AddOffer
             API to take an object of offer and store it in database    */
        [Route("addOffer")]
        [HttpPost]
        public async Task<ActionResult> CreateOffer(Offer offer)
        {
            try
            {
                var result = await db.Offers.AddAsync(offer);
                if (result == null)
                {
                    return NotFound();
                }
                await db.SaveChangesAsync();
                return Ok(result.Entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /*   POST: api/editOffer
             API to edit offer data   */
        [Route("editOffer")]
        [HttpPost]
        public async Task<ActionResult> Edit(int Id, Offer data)
        {
            try
            {
                Offer temp = await db.Offers.FindAsync(Id);
                if (temp == null)
                {
                    return NotFound();
                }
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
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }


        /*   POST: api/engageOffer
             API fix engage_date of a specific offer_id to current date and time   */
        [Route("engageOffer")]
        [HttpPost]
        public async Task<ActionResult> Engage(int Id, int Emp_Id)
        {
            try
            {
                Offer temp = await db.Offers.FindAsync(Id);
                if (temp == null)
                {
                    return NotFound();
                }
                temp.Emp_Id = Emp_Id;
                temp.Engaged_Date = System.DateTime.Now;
                db.Offers.Update(temp);
                db.SaveChanges();
                return Ok(temp);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }



        }

        /* --------[POINTS UTILITY METHODS]-------- */

        /*   GET: api/getOfferDetailsByCategory/<EMP_id>
             API to fetch filtered data on the basis of EMP_ID    */
        [Route("getOfferDetailsByEmpID/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOfferDetailsByEmpId(int id)
        {
            try
            {
                //var result = db.Offers.Where(offer => offer.Emp_Id == id).ToList();

                // performing join between offers and employees table to get employee name
                var result = from o in db.Offers
                             from e in db.Employees
                             where o.Emp_Id == e.EmpId && o.Emp_Id == id
                             select new
                             {
                                 id = o.Id,
                                 title = o.Title,
                                 description = o.Description,
                                 empName = e.EmpName,
                                 likes = o.N_Likes
                             };

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}
