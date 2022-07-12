using Microsoft.AspNetCore.Mvc;
using PointsMicroservices.Controllers;
using PointsMicroservices.Database.Entities;
using System;
using System.Threading.Tasks;

namespace PointsMicroservices.Repository
{
    public interface IPointService
    {
        public Task<Employee> FetchPoints(int id);
        public Task UpdateAsync(Offer offer);
    }
}
