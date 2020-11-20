using ForumDocument.Helpers;
using ForumDocument.Interfaces;
using ForumDocument.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ForumDocument.Services
{
    public class AuthService : IAuthService
    {
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor _httpContext;
        private readonly AppSettings _appSettings;
        public AuthService(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContext, IOptions<AppSettings> appSettings)
        {
            _httpContext = httpContext;
            _appSettings = appSettings.Value;
        }

        public UserLoginInfo GetUserInfor()
        {
            string jsonPayload = GetAuthPayloadString();
            UserLoginInfo user =  Converter.Deserialize<UserLoginInfo>(jsonPayload);
            user.StringeeToken = GenerateJwtStringee(_appSettings.IsUser, _appSettings.Secret, user.UserID.ToString());
            return user;
        }

        public string GetAuthPayloadString()
        {
            string authHeader = GetHeaderByName("Authorization");
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCIsImN0eSI6InN0cmluZ2VlLWFwaTt2PTEifQ.eyJqdGkiOiJTS0d6Qm5xRWJzb0RFT3FzTEpxZWZ0d2k1Y0Y2RXEwUUVpLTE2MDQ1ODU1MTMiLCJpc3MiOiJTS0d6Qm5xRWJzb0RFT3FzTEpxZWZ0d2k1Y0Y2RXEwUUVpIiwiZXhwIjoxNjA1MTkwMzEzLCJ1c2VySWQiOiI2NGE1OWEyNS0yNDg4LTU0YjAtZjZiNC1jOGFmMDhhNTBjYmYiLCJmdWxsTmFtZSI6Ilh1w6JuIETFqW5nIiwiZW1haWwiOiJkdW5nMUB2bnUuZWR1LnZuIiwicGhvbmUiOiIwOTc1MjU1NjUwIiwicGFzc3dvcmRVcGRhdGVUaW1lIjoiMjAyMC0xMC0yNVQwOToxMTo1OC4wMTlaIiwiaWF0IjoxNjA0NTg1NTEzfQ.7AyBMDYDMDv95YkmGSYVP6cVrn61eRSWESzPjDz1_D0";
            //string token = "";
            if (!string.IsNullOrWhiteSpace(authHeader))
            {
                token = authHeader.Split(new char[] { ' ' })[1];
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);
            return jsonToken.Payload.SerializeToJson();
        }

        public string GetHeaderByName(string headerName)
        {
            return _httpContext?.HttpContext?.Request?.Headers[headerName] + "";
        }

        /// <summary>
        /// Hàm tạo token
        /// </summary>
        /// <param name="keyID">Key ID stringee</param>
        /// <param name="keySecret">key Secret của stringee</param>
        /// <param name="id">id user</param>
        /// <param name="email">email user</param>
        /// <param name="avatar">avatar user</param>
        /// <param name="fullName">username</param>
        /// <returns></returns>
        private string GenerateJwtStringee(string keyID, string keySecret, string id)
        {
            // tạo token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(keySecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                   new Claim("userId", id)
                }),
                Issuer = keyID,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
