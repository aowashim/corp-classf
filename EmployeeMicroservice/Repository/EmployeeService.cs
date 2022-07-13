using EmployeeMicroservice.Database;
using EmployeeMicroservice.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Repository
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _context;
        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<Employee>> ViewProfile(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<List<EmployeeOffer>> ViewEmployeeOffers(int id)
        {
            var emp = _context.Employees.FindAsync(id);
            var offers = await _context.Offers.Where(x => x.Emp_Id == id).Select(o => new EmployeeOffer()
            {
                id = o.Id,
                title = o.Title,
                description = o.Description,
                empName = emp.Result.EmpName,
                likes = o.N_Likes
            }).ToListAsync();
            return offers;
        }

        public async Task<List<EmployeeOffer>> ViewMostLikedOffers()
        {
            var top3offers = await _context.Offers.OrderByDescending(x => x.N_Likes).Take(3)
                .Join(_context.Employees, o => o.Emp_Id, e => e.EmpId, (o, e) => new EmployeeOffer
                {
                    id = o.Emp_Id,
                    title = o.Title,
                    description = o.Description,
                    empName = e.EmpName,
                    likes = o.N_Likes
                }).ToListAsync();
            return top3offers;
        }
    }
}
