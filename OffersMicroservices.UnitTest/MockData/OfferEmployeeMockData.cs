using OffersMicroservice.Repository;
using OffersMicroservices.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeMicroserviceUnitTest.MockData
{
    public static class OfferEmployeeMockData
    {
        public static List<OfferEmployee> GetOfferEmployee()
        {
            return new List<OfferEmployee>()
            {
                new OfferEmployee()
                {
                    offer = new Offer
                    {
                        Id = 1,
                        Title = "Samsung E10",
                        Description = "Smartphone Good quality,  good condition",
                        N_Likes = 50,
                        Start_Date = DateTime.Parse("2022-07-10 00:00:00.0000000"),
                        End_Date = DateTime.Parse("2022-07-16 00:00:00.0000000"),
                        Engaged_Date = null,
                        Category_Id = 1,
                        Emp_Id = 325671,
                    },
                    empName="Anuj"
                },
                new OfferEmployee()
                {
                    offer= new Offer{
                        Id = 2,
                        Title = "MSI NoteBook",
                        Description = "8GB RAM, 1 TB SSD",
                        N_Likes = 10,
                        Start_Date = DateTime.Parse("2022-07-12 00:00:00.0000000"),
                        End_Date = DateTime.Parse("2022-07-16 00:00:00.0000000"),
                        Engaged_Date = null,
                        Category_Id = 1,
                        Emp_Id = 325674,
                    },
                    empName="Raktim"
                },
                new OfferEmployee()
                {
                    offer=new Offer{
                        Id = 3,
                        Title = "DSA Book",
                        Description = "Author: Reema Thereja",
                        N_Likes = 70,
                        Start_Date = DateTime.Parse("2022-07-09 00:00:00.0000000"),
                        End_Date = DateTime.Parse("2022-07-14 00:00:00.0000000"),
                        Engaged_Date = null,
                        Category_Id = 1,
                        Emp_Id = 325674,
                    },
                    empName="Raktim"
                }
            };
        }
    }
}
