using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Demo.Api.Utils
{
    public class TokenUtility
    {
        public static string CreateToken(IdentityUser user)
        {
            var claims = new Claim[]
            {
               new Claim(JwtRegisteredClaimNames.Sub, user.Id)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret word"));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(signingCredentials: signingCredentials, claims: claims);
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}