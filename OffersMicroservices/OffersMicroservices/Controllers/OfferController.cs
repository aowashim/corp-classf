using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OffersMicroservice.Repository;
using OffersMicroservices.Database;
using OffersMicroservices.Database.Entities;
using OffersMicroservices.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OffersMicroservices.Controllers
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class OfferController : ControllerBase
    {
        /* --------[SETUP]-------- */

        private DateTime def_date = new DateTime(2001, 01, 01);
        private readonly IOfferService _offerService;
        private readonly DatabaseContext _context;
        public OfferController(IOfferService service)
        {
            _offerService = service;
        }


        /* --------[GET REQUESTS]-------- */


        /*   GET: GET: api/offer
             API to get all the offers     */
        [Route("Offer")]
        [HttpGet]
        public async Task<ActionResult> Offer()
        {
            try
            {
                var result = await _offerService.Offer();

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
        public async Task<ActionResult> GetOfferDetails(int id)
        {
            try
            {
                var result = await _offerService.GetOfferDetails(id);

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


        //        /*   GET: api/getOfferDetailsByCategory/<category_id>
        //             API to fetch filtered data on the basis of category    */
        [Route("getOfferDetailsByCategory/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetOfferDetailsByCategory(int id)
        {
            try
            {
                var result = await _offerService.GetOfferDetailsByCategory(id);

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


        //        /*   GET: api/getofferbytoplikes
        //             API to fetch sorted data on the basis of likes    */
        [Route("getOfferByTopLikes")]
        [HttpGet]
        public async Task<ActionResult> GetOfferByTopLikes()
        {
            try
            {

                var result = await _offerService.GetOfferByTopLikes();

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result.FirstOrDefault());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //        /*   GET: api/getOfferByPostedDate>
        //             API to fetch sorted data on the basis of posted date    */
        [Route("getOfferByPostedDate")]
        [HttpGet]
        public async Task<ActionResult> GetOfferByPostedDate()
        {
            try
            {

                var result = await _offerService.GetOfferByPostedDate();

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


        //        /* --------[POST REQUESTS]-------- */

        //        /*   POST: api/AddOffer
        //             API to take an object of offer and store it in database    */
        [Route("addOffer")]
        [HttpPost]
        public async Task<ActionResult> CreateOffer(Offer offer)
        {
            try
            {
                var id = await _offerService.CreateAsync(offer);
                return Ok(id);
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
        public async Task<ActionResult> EditOffer(int Id, Offer data)
        {
            try
            {
                var id = await _offerService.EditAsync(Id, data);
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //        /*   POST: api/engageOffer
        //             API fix engage_date of a specific offer_id to current date and time   */
        [Route("engageOffer")]
        [HttpPost]
        public async Task<ActionResult> EngageOffer(int Id, int Emp_Id)
        {
            try
            {
                await _offerService.EngageAsync(Id, Emp_Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //        /* --------[POINTS UTILITY METHODS]-------- */

        //        /*   GET: api/getOfferDetailsByCategory/<EMP_id>
        //             API to fetch filtered data on the basis of EMP_ID    */
        [Route("getOfferDetailsByEmpID/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetOfferDetailsByEmpId(int id)
        {
            try
            {
                var result = await _offerService.GetOfferDetailsByEmpId(id);

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

        //        // ------------------------
        //        // For comments

        //        // GET: api/comments/5
        //        // API to fetch all comments of a offer based on offer Id
        [HttpGet("comments/{id}")]
        public async Task<ActionResult> GetComments(int id)
        {
            try
            {
                var comments = await _offerService.GetComments(id);
                if (comments == null)
                {
                    return NotFound();
                }

                return Ok(comments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //        // POST: api/comment
        //        // API to post a comment
        [HttpPost("comment")]
        public async Task<ActionResult> PostComment(Comment comment)
        {
            try
            {
                await _offerService.PostAsync(comment);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}