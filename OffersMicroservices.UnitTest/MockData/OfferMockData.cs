using OffersMicroservices.Controllers;
using OffersMicroservices.Database;
using OffersMicroservices.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeMicroserviceUnitTest.MockData
{
    public static class OfferMockData
    {
        public static List<Offer> GetOffers()
        {
            return new List<Offer>()
            {
                new Offer()
                {
                    Id = 1,
                    Title = "Samsung E10",
                    Description = "Smartphone Good quality,  good condition",
                    N_Likes = 5,
                    Start_Date = DateTime.Parse("2022-07-03 00:00:00.0000000"),
                    End_Date = DateTime.Parse("2022-07-05 00:00:00.0000000"),
                    Engaged_Date = DateTime.Parse("2022-07-05 00:00:00.0000000"),
                    Category_Id = 1,
                    Emp_Id = 325671
                },
                new Offer()
                {
                    Id = 2,
                    Title = "Poco F1",
                    Description = "Smartphone Good quality,  good condition",
                    N_Likes = 10,
                    Start_Date = DateTime.Parse("2022-07-03 00:00:00.0000000"),
                    End_Date = DateTime.Parse("2022-07-05 00:00:00.0000000"),
                    Engaged_Date = DateTime.Parse("2022-07-05 00:00:00.0000000"),
                    Category_Id = 2,
                    Emp_Id = 182012
                },
                new Offer()
                {
                    Id = 3,
                    Title = "Poco F3",
                    Description = "Smartphone Good quality,  good condition",
                    N_Likes = 15,
                    Start_Date = DateTime.Parse("2022-07-03 00:00:00.0000000"),
                    End_Date = DateTime.Parse("2022-07-05 00:00:00.0000000"),
                    Engaged_Date = DateTime.Parse("2022-07-05 00:00:00.0000000"),
                    Category_Id = 1,
                    Emp_Id = 182012
                }
            };
        }

    }
}