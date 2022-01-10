using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using PPT.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PPT.Services.Common.Helpers
{
    public class JWTHelper
    {
        public static string GenerateToken(PPT.Interfaces.Entities.User user, DateTime expires, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                            new Claim("id", user.ID.ToString())
                    }
                ),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            string sToken = tokenHandler.WriteToken(token);

            return sToken;
        }

        public static string GetAuthToken(HttpRequest request)
        {
            var token = request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            return token;
        }

        public static PPT.Interfaces.Entities.User GetUserFromToken(string token, string secret, PPT.Services.Dal.IUserDal dalUser)
        {
            PPT.Interfaces.Entities.User user = null;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                var expClaim = jwtToken.Claims.First(x => x.Type == "exp").Value;

                user = dalUser.Get(userId);
            }
            catch
            {
                user = null;
            }

            return user;
        }
    }
}
