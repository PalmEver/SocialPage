using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace API
{

public class JwtService
{
	private string secureKey="this is a very secure key i promise";
	public string GenerateJwtToken(int id)
	{
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
		var Credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
		var header = new JwtHeader(Credentials);

		var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Today.AddDays(1));
        var securityToken = new JwtSecurityToken(header, payload);

		return new JwtSecurityTokenHandler().WriteToken(securityToken);
	}
    
   public JwtSecurityToken VerifyJwtToken(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secureKey);
            tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken) validatedToken;
        }

}

}