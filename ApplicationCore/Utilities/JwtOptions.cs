using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApplicationCore.Utilities
{
	public class JwtOptions
	{
		public string Issuer { get; set; }
		public string Key { get; set; }
		public int Lifetime { get; set; } // minutes
		public SymmetricSecurityKey GetSymmetricSecurityKey() =>
		new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
	}
}
