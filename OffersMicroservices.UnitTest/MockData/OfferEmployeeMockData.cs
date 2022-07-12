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
                    id = 1,
                    title = "Samsung E10",
                    description = "Smartphone Good quality,  good condition",
                    n_Likes = 50,
                    start_Date = DateTime.Parse("2022-07-10 00:00:00.0000000"),
                    end_Date = DateTime.Parse("2022-07-16 00:00:00.0000000"),
                    engaged_Date = null,
                    category_Id = 1,
                    emp_Id = 325671,
                    empName="Anuj"
                },
                new OfferEmployee()
                {
                    id = 2,
                    title = "MSI NoteBook",
                    description = "8GB RAM, 1 TB SSD",
                    n_Likes = 10,
                    start_Date = DateTime.Parse("2022-07-12 00:00:00.0000000"),
                    end_Date = DateTime.Parse("2022-07-16 00:00:00.0000000"),
                    engaged_Date = null,
                    category_Id = 1,
                    emp_Id = 325674,
                    empName="Raktim"
                },
                new OfferEmployee()
                {
                    id = 3,
                    title = "DSA Book",
                    description = "Author: Reema Thereja",
                    n_Likes = 70,
                    start_Date = DateTime.Parse("2022-07-09 00:00:00.0000000"),
                    end_Date = DateTime.Parse("2022-07-14 00:00:00.0000000"),
                    engaged_Date = null,
                    category_Id = 1,
                    emp_Id = 325674,
                    empName="Raktim"
                }
            };
        }
    }
}
