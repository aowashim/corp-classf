using OffersMicroservice.Repository;
using OffersMicroservices.Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersMicroservices.Repository
{
    public interface IOfferService
    {
        public Task<List<EmployeeOffer>> Offer();
        public Task<List<OfferEmployee>> GetOfferDetails(int id);
        public Task<List<EmployeeOffer>> GetOfferDetailsByCategory(int id);
        public Task<List<EmployeeOffer>> GetOfferByTopLikes();
        public Task<List<EmployeeOffer>> GetOfferByPostedDate();
        public Task EditAsync(int Id, Offer data);
        public Task CreateAsync(Offer offer);
        public Task EngageAsync(int Id, int Emp_Id);
        public Task<List<EmployeeOffer>> GetOfferDetailsByEmpId(int id);
        public Task<List<EmployeeComment>> GetComments(int id);
        public Task PostAsync(Comment comment);
    }
}
