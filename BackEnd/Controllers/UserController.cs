using Microsoft.AspNetCore.Mvc;
using Proyecto1_Lenguajes.Models.Data;
using SmartParkingCR_Backend.Models;
using System.Security.Claims;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Proyecto1_Lenguajes.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;


namespace SmartParkingCR_Backend.Controllers
{
   // [ApiController]
   // [Route("api/User")]
    public class UserController : Controller
    {
     
        private readonly IConfiguration _configuration;
        UserDAO userDAO;

        public UserController(IConfiguration configuration)
        {
           
            _configuration = configuration;
            userDAO = new UserDAO(_configuration);
        }
        [HttpPost]
        [Route("api/user/[action]")]
        public async Task<IActionResult> Verify([FromBody] UserDto user)
        {
        //    UserDAO userDAOs = new UserDAO();
            var us = userDAO.Get(user.email, user.password);
            if (us.Email is null)
                return BadRequest(new { message = "credenciales malas." });
            // return Ok(new { token = "some value" });
            string jwtToken = GenerateToken(userDAO.Get(user.email, user.password));
            return Ok(new { token = jwtToken,usuario=us });
        }

        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
             //   new Claim(ClaimTypes.Role,user.Role.idRole),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var securityToken = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: creds);
            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
        [HttpGet]
        [Route("api/user/[action]")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok(userDAO.Get());
        }
        [Authorize]
        [HttpPost]
        [Route("api/user/[action]")]
        public IActionResult Insert([FromBody] User user)
        {

            if (userDAO.Get(user.Email, user.Password).Email == null)
            {
                int resultToReturn = userDAO.Insert(user);
                return Ok(resultToReturn);
            }
            else
            {
                return Error();
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/user/[action]")]
        public IActionResult GetAllUser()
        {
            try
            {
                return Ok(userDAO.Get());
            }
            catch (Exception)
            {
                return Error();
            }

        }

        [Authorize]
        [HttpGet]
        [Route("api/user/[action]")]
        public IActionResult GetClientUser()
        {
            try
            {
                return Ok(userDAO.GetClientUser());
            }
            catch (Exception)
            {
                return Error();
            }

        }

        [Authorize]
        [HttpGet]
        [Route("api/user/[action]")]
        public IActionResult GetByEmail(string email)
        {
            try
            {
                User user = userDAO.GetByEmail(email);
                return Ok(user);
            }
            catch (Exception)
            {
                return Error();
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/user/[action]")]
        public IActionResult GetById(int id)
        {
            try
            {
                User user = userDAO.getUserById(id);
                return Ok(user);
            }
            catch (Exception)
            {
                return Error();
            }
        }


        [Authorize]
        [HttpPut]
        [Route("api/user/[action]")]
        public IActionResult Update([FromBody] User user)
        {
            try
            {
                return Ok(userDAO.Update(user));
            }
            catch (Exception)
            {
                return Error();
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("api/user/[action]")]
        public IActionResult Delete(string email)
        {
            try
            {
                return Ok(userDAO.Delete(email));
            }
            catch (Exception)
            {
                return Error();
            }



        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
