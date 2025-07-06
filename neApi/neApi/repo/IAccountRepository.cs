using Microsoft.AspNetCore.Identity;
using neApi.model;

namespace neApi.repo
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUp signUp);
        Task<string> SignInAsync(SignIn signIn);
    }
}
