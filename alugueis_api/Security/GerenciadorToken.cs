using Alugueis_API.Interfaces.Security;
using Alugueis_API.Models;
using Alugueis_API.Models.DTOs.Request;
using Alugueis_API.Models.DTOs.Response;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Alugueis_API.Security
{
    public class GerenciadorToken : IGerenciadorToken
    {
        private readonly AuthConfig _authConfig;
        public GerenciadorToken(IOptions<AuthConfig> authConfig)
        {
            _authConfig = authConfig.Value;
        }

        public Task<GetAuthDTO> GenerateTokenAsync(Usuario usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authConfig.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var date = DateTime.UtcNow;
            var expire = date.AddHours(_authConfig.ExpireInHours);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Email),
                new Claim("role", "admin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "meusistema",
                audience: "meusistema",
                claims: claims,
                expires: expire,
                signingCredentials: creds
            );
            var response = new GetAuthDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpireIn = _authConfig.ExpireInHours,
                Type = "Bearer"
            };

            return Task.FromResult(response);
        }
    }
}
