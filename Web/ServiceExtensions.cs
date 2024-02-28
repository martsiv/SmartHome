using ApplicationCore.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Web
{
	public static class ServiceExtensions
	{
		public static void AddJWT(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthorization();

			var jwtOpts = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>()!;

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(o =>
				{
					o.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = false,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = jwtOpts.Issuer,
						IssuerSigningKey = jwtOpts.GetSymmetricSecurityKey(),
						ClockSkew = TimeSpan.Zero
					};
				});
		}
	}
}
