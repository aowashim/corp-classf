using System;
using System.Collections.Generic;
using System.Text;
using EmployeeMicroservice.Database.Entities;

namespace EmployeeMicroserviceUnitTest.MockData
{
    public static class EmployeeMockData
    {
        public static List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    EmpId = 325671,
                    EmpName = "James",
                    Email = "james@cognizant.com",
                    Points_Gained = 10,
                    Designation = "Senior Consultant",
                    Office_Location = "Noida"
                },
                new Employee()
                {
                    EmpId = 271921,
                    EmpName = "Dino",
                    Email = "dino@cognizant.com",
                    Points_Gained = 0,
                    Designation = "Senior Analyst",
                    Office_Location = "Kolkata"
                },
                new Employee()
                {
                    EmpId = 182012,
                    EmpName = "Reshma",
                    Email = "reshma@cognizant.com",
                    Points_Gained = 5,
                    Designation = "HR",
                    Office_Location = "Mumbai"
                }
            };
        }
    }
}
