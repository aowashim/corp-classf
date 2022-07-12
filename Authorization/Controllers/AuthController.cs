using CorpClassfAuth.Data.Model;
using CorpClassfAuth.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CorpClassfAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /* --------[SETUP]-------- */

        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        /* --------[SIGNUP]-------- */

        // POST: api/Auth/signup
        // API to register Employee Profile into the database
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUp signUpModel)
        {
            var result = await _authRepository.SignUpAsync(signUpModel);

            if (result.Succeeded) return Ok(result);
            else return BadRequest(result);

            //return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        /* --------[LOGIN]-------- */

        // POST: api/Auth/login
        // API to login into the portal to access features as an Authorized user
        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] SignIn signInModel)
        {
            var result = await _authRepository.LoginAsync(signInModel);

            if (result == null) return Unauthorized(result);
            else return Ok(result);

            //return result == null ? Unauthorized(result) : Ok(result);
        }
    }
}
