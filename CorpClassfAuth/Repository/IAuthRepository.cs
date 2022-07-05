using CorpClassfAuth.Data.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CorpClassfAuth.Repository
{
    public interface IAuthRepository
    {
        Task<IdentityResult> SignUpAsync(SignUp signUpModel);
        //Task<string> LoginAsync(SignIn signModel);
    }
}
