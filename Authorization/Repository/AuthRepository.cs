using CorpClassfAuth.Data;
using CorpClassfAuth.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CorpClassfAuth.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public AuthRepository(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IConfiguration configuration, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context;
        }

        public async Task<IdentityResult> SignUpAsync(SignUp signUpModel)
        {
            try
            {
                var employee = new Employee
                {
                    EmpName = signUpModel.Name,
                    Email = signUpModel.Email,
                    Designation = signUpModel.Designation,
                    Points_Gained = 0,
                    Office_Location = signUpModel.OfficeLocation,
                    EmpId = signUpModel.EmpId,
                };

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();

                var user = new IdentityUser
                {
                    Email = signUpModel.Email,
                    UserName = signUpModel.EmpId.ToString(),
                };

                return await _userManager.CreateAsync(user, signUpModel.Password);
            }
            catch (Exception)
            {
                return IdentityResult.Failed();
            }
        }

        public async Task<string> LoginAsync(SignIn signModel)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(signModel.EmpId.ToString(), signModel.Password, false, false);

                if (!result.Succeeded) return null;

                var authClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, signModel.EmpId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var authSignInKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256Signature)
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
