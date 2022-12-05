using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SMDP.SMDPModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SMDP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static Userr user = new Userr();
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Userr>> Register(UserDto request)
        {
            using (SmdpContext db = new())
            {
                CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.UserName = request.UserName;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                User usr = new User();
                {
                    usr.UserName = user.UserName; 
                    usr.PasswordHash = user.PasswordHash;
                    usr.PasswordSalt = user.PasswordSalt;
                }
                db.Users.Add(usr);
                db.SaveChanges();               
            }
            return Ok(user);

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            Userr userlogin = new Userr();
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            userlogin.UserName = request.UserName;
            userlogin.PasswordHash = passwordHash;
            userlogin.PasswordSalt = passwordSalt;
            
            SmdpContext db = new SmdpContext();          
            var usertable = db.Users.Where(i =>
               i.UserName== userlogin.UserName).FirstOrDefault();
                                 
            if (usertable == null)
            {
                return BadRequest("User not found.");
            }

            if (!VerifyPasswordHash(request.Password, usertable.PasswordHash, usertable.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }
            string token = CreateToken(userlogin);
            return Ok(token);
        }

        private string CreateToken(Userr user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };
                      
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,               
                expires: DateTime.UtcNow.AddDays(1),
                issuer : _configuration.GetSection("AppSettings").GetSection("Issuer").Value,
                audience:_configuration.GetSection("AppSettings").GetSection("Audience").Value,
                signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
   
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        private bool  VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt) )
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash); 
            }
        }

    }
}