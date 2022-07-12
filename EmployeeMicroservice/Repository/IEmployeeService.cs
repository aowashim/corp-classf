using EmployeeMicroservice.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Repository
{
    public interface IEmployeeService
    {
        public Task<ActionResult<Employee>> ViewProfile(int id);
        public Task<List<EmployeeOffer>> ViewEmployeeOffers(int id);
        public Task<List<EmployeeOffer>> ViewMostLikedOffers();

    }
}
