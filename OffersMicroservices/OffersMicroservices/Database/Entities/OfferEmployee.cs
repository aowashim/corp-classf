using System;

namespace OffersMicroservices.Database.Entities
{
    public class OfferEmployee
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int n_Likes { get; set; }
        public DateTime start_Date { get; set; }
        public DateTime end_Date { get; set; }
        public DateTime? engaged_Date { get; set; }
        public int category_Id { get; set; }
        public int emp_Id { get; set; }
        public string empName { get; set; }
    }
}
