using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserDBContext _context;
        private IOptions<Audience> _settings;
        
        public AuthController(UserDBContext context, IOptions<Audience> settings)
        {
            this._context = context;
            this._settings = settings;
        }

        [HttpGet("{name}/{pwd}")]
        public async Task<ActionResult<object>> Get(string name, string pwd)
        {
            try
            {
                //just hard code here.  
                var User = _context.users.FirstOrDefault(a => a.Username == name && a.Password == pwd);
                if (User != null)
                {
                    var now = DateTime.UtcNow;

                    var claims = new Claim[]
                    {
            new Claim(JwtRegisteredClaimNames.Sub, name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64)
                    };

                    var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.Value.Secret));
                    var tokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,
                        ValidateIssuer = true,
                        ValidIssuer = _settings.Value.Iss,
                        ValidateAudience = true,
                        ValidAudience = _settings.Value.Aud,
                        ValidateLifetime = true                       

                    };

                    var jwt = new JwtSecurityToken(
                        issuer: _settings.Value.Iss,
                        audience: _settings.Value.Aud,
                        claims: claims,
                        notBefore: now,
                        expires: now.Add(TimeSpan.FromMinutes(100)),
                        signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                    );
                    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                    var responseJson = new
                    {
                        access_token = encodedJwt,
                        expires_in = (int)TimeSpan.FromMinutes(100).TotalSeconds
                    };

                    return responseJson;
                }
                else
                {
                    return NoContent();
                }
            }
            catch(Exception ex)
            {
                return NoContent();
            }
            return NoContent();
        }
    }
}
