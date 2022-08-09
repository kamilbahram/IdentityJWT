using IdentityJWT.Data;
using IdentityJWT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Web.Services3.Security.Utility;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace IdentityJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController1 : ControllerBase
    {
        private UserManager<AplicationUser> userManager;

        public AuthController1(UserManager<AplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName); 
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var claims = new List<Claim>() {
                    
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())                
                };

                var singinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AspNetCoreEgitim"));

                var token = new JwtSecurityToken(
                    issuer : "https://localhost:44312",
                    audience : "https://localhost:44312",
                    expires : DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc).AddHours(1),
                    claims : claims,
                    signingCredentials : new SigningCredentials(singinKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    message = "Giriş başarılı."

                });
            }
            else
            {
                return BadRequest(new
                {
                    message = "Kullanıcı adı yada parola hatalı."
                });
            }
        }
    }
}
