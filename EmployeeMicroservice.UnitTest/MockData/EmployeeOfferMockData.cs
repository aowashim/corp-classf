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
                    id = 1,
                    title = "Samsung E10",
                    description = "Smartphone Good quality,  good condition",
                    empName = "James",
                    likes = 0
                }
            };
        }

        public static List<EmployeeOffer> Get3MostLikedEmployeeOffers()
        {
            return new List<EmployeeOffer>()
            {
                new EmployeeOffer()
                {
                    id = 3,
                    title = "Poco F3",
                    description = "Smartphone Good quality,  good condition",
                    empName = "Reshma",
                    likes = 15
                },
                new EmployeeOffer()
                {
                    id = 2,
                    title = "Poco F1",
                    description = "Smartphone Good quality,  good condition",
                    empName = "Reshma",
                    likes = 10
                },
                new EmployeeOffer()
                {
                    id = 1,
                    title = "Samsung E10",
                    description = "Smartphone Good quality,  good condition",
                    empName = "James",
                    likes = 5
                }
            };
        }
    }
}
