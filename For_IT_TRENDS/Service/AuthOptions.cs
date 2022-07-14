using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace For_IT_TRENDS.Service
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer";
        public const string AUDIENCE = "MyAuthClient";
        const string KEY = "KeyFor_ITtrends!335";//Key for encrypt

        //Convert our KEY to byte array and return him 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}
