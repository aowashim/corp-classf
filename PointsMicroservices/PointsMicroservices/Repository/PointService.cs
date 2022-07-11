using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointsMicroservices.Controllers;
using PointsMicroservices.Database;
using PointsMicroservices.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsMicroservices.Repository
{
    public class PointService:IPointService
    {
        private readonly DatabaseContext _context;
        public PointService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Employee> FetchPoints(int id)
        {
            return await _context.Employees.FindAsync(id); 
        }
        public async Task UpdateAsync(Offer offer)
        {
            int Emp_id = offer.Emp_Id;
            var List_point = _context.Employees.Where(x => x.EmpId == Emp_id);
            Employee emp = List_point.FirstOrDefault();
            int rewards = emp.Points_Gained;
            int diff_date = (DateTime.Now - offer.Start_Date).Days;
            int engage_diif_date = (offer.Engaged_Date - offer.Start_Date).Days;
            int n_likes = (int)offer.N_Likes;
            if (n_likes <= 100)
            {
                if (n_likes % 100 == 0 && diff_date <= 2)
                {
                    rewards += 50;
                }
                else if (n_likes % 50 == 0 && diff_date <= 2)
                {
                    rewards += 10;
                }
            }
            if (engage_diif_date <= 2)
            {
                rewards += 100;
            }
            emp.Points_Gained = rewards;
            _context.Employees.Update(emp);
            await _context.SaveChangesAsync();
        }
    }
}
