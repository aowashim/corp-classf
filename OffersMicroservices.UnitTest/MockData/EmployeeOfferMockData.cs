using OffersMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OffersMicroserviceUnitTest.MockData
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
                },
                new EmployeeOffer()
                {
                    id = 2,
                    title = "MSI Notebook",
                    description = "8GB RAM, 1TB SSD",
                    empName = "Raktim",
                    likes = 0
                },
                new EmployeeOffer()
                {
                    id = 3,
                    title = "DSA Book",
                    description = "Author: Reema Thereja",
                    empName = "Raktim",
                    likes = 0
                }
            };
        }
    }
}