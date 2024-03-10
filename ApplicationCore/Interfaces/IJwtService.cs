using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
	public interface IJwtService
	{
		// ------- Access Token
		IEnumerable<Claim> GetClaims(User user);
		IEnumerable<Claim> GetClaims(SensorDto sensorDto);
		string CreateToken(IEnumerable<Claim> claims);

		// ------- Refresh Token
		//string CreateRefreshToken();
		//IEnumerable<Claim> GetClaimsFromExpiredToken(string token);
	}
}
