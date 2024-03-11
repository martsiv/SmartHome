using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApplicationCore.Services
{
	internal class JwtService : IJwtService
	{
		private readonly IConfiguration configuration;

		public JwtService(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public IEnumerable<Claim> GetClaims(IdentityUser user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id),
				new Claim(ClaimTypes.Name, user.UserName),
			};

			//var roles = userManager.GetRolesAsync(user).Result;
			//claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

			return claims;
		}
		public IEnumerable<Claim> GetClaims(SensorDto sensorDto)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, sensorDto.Id.ToString()),
				new Claim(ClaimTypes.Name, sensorDto.Name),
			};

			string role = "SensorRole";
			claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));

			return claims;
		}

		public string CreateToken(IEnumerable<Claim> claims)
		{
			var jwtOpts = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

			var token = new JwtSecurityToken(
				issuer:		jwtOpts.Issuer,
				claims:		claims,
				expires:	DateTime.UtcNow.AddDays(jwtOpts.Lifetime),
				signingCredentials: new SigningCredentials(jwtOpts.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

	}
}
