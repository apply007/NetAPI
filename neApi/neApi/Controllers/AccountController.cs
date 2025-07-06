using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neApi.model;
using neApi.repo;

namespace neApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUp signUp)
        {
          var result=  await accountRepository.SignUpAsync(signUp);
            if (result.Succeeded)
            {
                 return Ok("Success");
            }
            return Unauthorized();
        } 
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignIn signIn)
        {
          var result=  await accountRepository.SignInAsync(signIn);
            if (string.IsNullOrEmpty(result))
            {
                 return Unauthorized();
            }
            return Ok(result);
        }




    }
}
