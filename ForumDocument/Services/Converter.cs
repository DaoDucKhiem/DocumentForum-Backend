using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace ForumDocument.Services
{
    internal class Converter
    {
        public static T Deserialize<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                throw;
            }
        }

       public static string JWTDecode(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(jwt);
            var value = Serialize(jsonToken.Payload);
            return value;
        }

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string DecodeBase64(string base64Text)
        {
            if (string.IsNullOrWhiteSpace(base64Text))
            {
                return string.Empty;
            }

            return System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(base64Text));
        }
    }
}