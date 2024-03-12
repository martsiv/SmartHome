using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ApplicationCore.Interfaces
{
	public interface IJwtService
	{
		// ------- Access Token
		IEnumerable<Claim> GetClaims(IdentityUser user);
		IEnumerable<Claim> GetClaims(SensorDto sensorDto);
		string CreateToken(IEnumerable<Claim> claims);

		// ------- Refresh Token
		//string CreateRefreshToken();
		//IEnumerable<Claim> GetClaimsFromExpiredToken(string token);
	}
}
