using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using proyectoPrueba.Models;
using proyectoPrueba.Helpers;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace proyectoPrueba.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AppDBContext _context;
        // GET api/values

        public AuthController(AppDBContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Users value)
        {
            try
            {

                Users UserResult = this._context.Users.Where(
                   user => user.username == value.username).First();

                Console.WriteLine(UserResult.password + "-->" + Encrypt.GetMD5(value.password));

                if (UserResult.password == Encrypt.GetMD5(value.password))
                //if (UserResult.password == value.password)
                {
                    //var jsonResult = new { Id = "23", Name = "Scott" };
                    //return Ok(jsonResult);
                    return Ok("Respuesta"+value);
                }
                else
                {
                    return Unauthorized();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();

            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public ActionResult BuildToken()
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, "Alfonso"),
                new Claim("mi valor", "lo que yo quiera"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) 
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("pass"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "geekhubs.com",
                audience: "geekhubs.com",
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            Console.WriteLine("Token creado--->" + token);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            });
        }
    }
}
