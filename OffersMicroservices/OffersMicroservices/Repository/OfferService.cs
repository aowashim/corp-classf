using Microsoft.EntityFrameworkCore;
using OffersMicroservice.Repository;
using OffersMicroservices.Database;
using OffersMicroservices.Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersMicroservices.Repository
{
    public class OfferService : IOfferService
    {
        private readonly DatabaseContext _context;
        public OfferService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeOffer>> Offer()
        {
            // performing join between offers and employees table to get employee name
            var result = await _context.Offers.Include(o => o.Offer_Category)
                .Join(_context.Employees, o => o.Emp_Id, e => e.EmpId, (o, e) => new EmployeeOffer
                {
                    id = o.Id,
                    title = o.Title,
                    description = o.Description,
                    empName = e.EmpName,
                    likes = o.N_Likes
                }).ToListAsync();
            return result;
        }
        public async Task<List<OfferEmployee>> GetOfferDetails(int id)
        {
            var result = await _context.Offers.Where(o => o.Id == id).Include(o => o.Offer_Category)
                    .Join(_context.Employees, O => O.Emp_Id, e => e.EmpId, (ofr, e) => new OfferEmployee { o = ofr, empName = e.EmpName }).ToListAsync();


            return result;
        }
        public async Task<List<EmployeeOffer>> GetOfferDetailsByCategory(int id)
        {
            // performing join between offers and employees table to get employee name
            var result = await _context.Offers.Where(o => o.Category_Id == id).Include(o => o.Offer_Category)
                .Join(_context.Employees, o => o.Emp_Id, e => e.EmpId, (o, e) => new EmployeeOffer
                {
                    id = o.Id,
                    title = o.Title,
                    description = o.Description,
                    empName = e.EmpName,
                    likes = o.N_Likes
                }).ToListAsync();
            return result;
        }
        public async Task<List<EmployeeOffer>> GetOfferByTopLikes()
        {
            // performing join between offers and employees table to get employee name
            var result = await _context.Offers.Include(o => o.Offer_Category)
               .Join(_context.Employees, o => o.Emp_Id, e => e.EmpId, (o, e) => new EmployeeOffer
               {
                   id = o.Id,
                   title = o.Title,
                   description = o.Description,
                   empName = e.EmpName,
                   likes = o.N_Likes
               }).OrderByDescending(o => o.likes).ToListAsync();
            return result;
        }
        public async Task<List<EmployeeOffer>> GetOfferByPostedDate()
        {
            // performing join between offers and employees table to get employee name
            var result = await _context.Offers.OrderByDescending(o => o.Start_Date)
                .Join(_context.Employees, o => o.Emp_Id, e => e.EmpId, (o, e) => new EmployeeOffer
                {
                    id = o.Id,
                    title = o.Title,
                    description = o.Description,
                    empName = e.EmpName,
                    likes = o.N_Likes
                }).ToListAsync();
            return result;
        }
        public async Task<int> EditAsync(int Id, Offer data)
        {
            Offer temp = await _context.Offers.FindAsync(Id);
            temp.Title = data.Title;
            temp.Description = data.Description;
            temp.Start_Date = data.Start_Date;
            temp.End_Date = data.End_Date;
            temp.Category_Id = data.Category_Id;

            var result = _context.Offers.Update(temp);
            _context.SaveChanges();

            return result.Entity.Id;
        }
        public async Task<int> CreateAsync(Offer offer)
        {
            var result = await _context.Offers.AddAsync(offer);

            _context.SaveChanges();

            return result.Entity.Id;
        }
        public async Task EngageAsync(int Id, int Emp_Id)
        {
            Offer temp = await _context.Offers.FindAsync(Id);
            //temp.Emp_Id = Emp_Id;
            temp.N_Likes += 1;
            temp.Engaged_Date = System.DateTime.Now;
            _context.Offers.Update(temp);
            _context.SaveChanges();
        }
        public async Task<List<EmployeeOffer>> GetOfferDetailsByEmpId(int id)
        {
            var emp = _context.Employees.FindAsync(id);
            // performing join between offers and employees table to get employee name
            var offers = await _context.Offers.Where(x => x.Emp_Id == id)
                .Join(_context.Employees, o => o.Emp_Id, e => e.EmpId, (o, e) => new EmployeeOffer()
                {
                    id = o.Id,
                    title = o.Title,
                    description = o.Description,
                    empName = emp.Result.EmpName,
                    likes = o.N_Likes
                }).ToListAsync();
            return offers;
        }

        public async Task<List<EmployeeComment>> GetComments(int id)
        {
            var comments = await _context.Comment.Where(x => x.Offer_Id == id)
                .Join(_context.Employees, c => c.User_Id, e => e.EmpId, (c, e) => new EmployeeComment
                {
                    id = c.Id,
                    content = c.Content,
                    emp_Name = e.EmpName,
                    offer_Id = c.Offer_Id,
                }).ToListAsync();
            return comments;
        }
        public async Task PostAsync(Comment comment)
        {
            await _context.Comment.AddAsync(comment);

            await _context.SaveChangesAsync();
        }
    }
}
