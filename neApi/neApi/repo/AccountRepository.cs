using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using neApi.model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace neApi.repo
{
    public class AccountRepository:IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManger;
        private readonly IConfiguration configuration;

        public AccountRepository(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,SignInManager<ApplicationUser> signInManger,IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManger = signInManger;
            this.configuration = configuration;
        }


        public async Task<IdentityResult>  SignUpAsync(SignUp signUp)
        {
            var user=new ApplicationUser() { FirstName=signUp.FirstName,
                LastName=signUp.LastName,
                Email=signUp.Email,
                UserName=signUp.Email };


           return await userManager.CreateAsync(user,signUp.Password);

        }

        public async Task<string> SignInAsync(SignIn signIn)
        {
            var result = await signInManger.PasswordSignInAsync(signIn.Email, signIn.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
                
            }
            var authClaim = new List<Claim>
            {
                new Claim(ClaimTypes.Name,signIn.Email), 
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()), 

            };
            var authSigninkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires:DateTime.Now.AddDays(1),
                claims: authClaim,
                signingCredentials:new SigningCredentials(authSigninkey,SecurityAlgorithms.HmacSha256Signature)
                );

        return    new JwtSecurityTokenHandler().WriteToken(token);


        }



    }
}
