namespace OffersMicroservices.Database.Entities
{
    public class EmployeeComment
    {
        public int id { get; set; }
        public int offer_Id { get; set; }
        public string content { get; set; }
        public string emp_Name { get; set; }
    }
}
