using OffersMicroservices.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OffersMicroservices.UnitTest.MockData
{
    public class EmployeeCommentMockData
    {
        public static List<EmployeeComment> GetEmployeeComments()
        {
            return new List<EmployeeComment>()
            {
                new EmployeeComment()
                {
                    id = 1,
                    offer_Id = 1,
                    content = "Good Condition",
                    emp_Name = "James"
                },
                new EmployeeComment()
                {
                    id = 2,
                    offer_Id = 1,
                    content ="Impressive",
                    emp_Name ="Dino"
                },
                new EmployeeComment()
                {
                    id = 3,
                    offer_Id=2,
                    content ="Good",
                    emp_Name ="Reshma"
                }
            };
        }
    }
}
