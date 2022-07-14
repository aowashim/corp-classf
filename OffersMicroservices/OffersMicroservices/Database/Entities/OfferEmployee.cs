using System;

namespace OffersMicroservices.Database.Entities
{
    public class OfferEmployee
    {
        public Offer offer{ get; set; }
        public string empName { get; set; }
    }
}
