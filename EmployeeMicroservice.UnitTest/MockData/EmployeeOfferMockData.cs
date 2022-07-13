using EmployeeMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeMicroserviceUnitTest.MockData
{
    public static class EmployeeOfferMockData
    {
        public static List<EmployeeOffer> GetEmployeeOffers()
        {
            return new List<EmployeeOffer>()
            {
                new EmployeeOffer()
                {
                    Id = 1,
                    Title = "Samsung E10",
                    Description = "Smartphone Good quality,  good condition",
                    EmpName = "James",
                    Likes = 0
                }
            };
        }

        public static List<EmployeeOffer> Get3MostLikedEmployeeOffers()
        {
            return new List<EmployeeOffer>()
            {
                new EmployeeOffer()
                {
                    Id = 3,
                    Title = "Poco F3",
                    Description = "Smartphone Good quality,  good condition",
                    EmpName = "Reshma",
                    Likes = 15
                },
                new EmployeeOffer()
                {
                    Id = 2,
                    Title = "Poco F1",
                    Description = "Smartphone Good quality,  good condition",
                    EmpName = "Reshma",
                    Likes = 10
                },
                new EmployeeOffer()
                {
                    Id = 1,
                    Title = "Samsung E10",
                    Description = "Smartphone Good quality,  good condition",
                    EmpName = "James",
                    Likes = 5
                }
            };
        }
    }
}
