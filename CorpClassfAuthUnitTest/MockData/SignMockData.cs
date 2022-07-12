using CorpClassfAuth.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorpClassfAuthUnitTest.MockData
{
    public static class SignMockData
    {
        public static List<SignUp> GetSignUpDetails()
        {
            return new List<SignUp>()
            {
                new SignUp()
                {
                    Name = "Jena",
                    EmpId = 123456,
                    Email = "jena@cognizant.com",
                    Password = "#Jena123",
                    ConfirmPassword = "#Jena123",
                    Designation = "Assistant Manager",
                    OfficeLocation = "Hyderabad"
                },
                new SignUp()
                {
                    Name = "Jena",
                    EmpId = 123456,
                    Email = "jena@cognizant.com",
                    Password = "#Jena113",
                    ConfirmPassword = "#Jena3",
                    Designation = "Assistant Manager",
                    OfficeLocation = "Hyderabad"
                }
            };
        }

        public static List<SignIn> GetSignInDetails()
        {
            return new List<SignIn>()
            {
                new SignIn()
                {
                    EmpId = 123456,
                    Password = "#Jena123"
                },
                new SignIn()
                {
                    EmpId = 213452,
                    Password = "#Jena123"
                }
            };
        }
    }
}
