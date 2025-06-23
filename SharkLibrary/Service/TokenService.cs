using Microsoft.IdentityModel.Tokens;
using SharkLibrary.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SharkLibrary.Service;
public class TokenService
{
    private IConfiguration _configuration;
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateToken(Usuario usuario)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("Username", usuario.UserName),
            new Claim("Id", usuario.Id),
            new Claim("Telefone", usuario.Telefone)
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurity"]));

        var signCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
                expires: DateTime.UtcNow.AddMinutes(10),
                claims: claims,
                signingCredentials: signCredentials
            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
