using alugueis_api.Interfaces.Security;
using alugueis_api.Models;
using alugueis_api.Models.DTOs.Request;
using alugueis_api.Models.DTOs.Response;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace alugueis_api.Security
{
    public class GerenciadorToken : IGerenciadorToken
    {
        private readonly AuthConfig _authConfig;
        public GerenciadorToken(AuthConfig authConfig)
        {
            _authConfig = authConfig;
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
