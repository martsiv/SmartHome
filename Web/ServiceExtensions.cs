using ApplicationCore.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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

			services.AddSwaggerGen(setup =>
			{
				// Include 'SecurityScheme' to use JWT Authentication
				var jwtSecurityScheme = new OpenApiSecurityScheme
				{
					BearerFormat = "JWT",
					Name = "JWT Authentication",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = JwtBearerDefaults.AuthenticationScheme,
					Description = "Put _ONLY_ your JWT Bearer token on textbox below!",

					Reference = new OpenApiReference
					{
						Id = JwtBearerDefaults.AuthenticationScheme,
						Type = ReferenceType.SecurityScheme
					}
				};

				setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

				setup.AddSecurityRequirement(new OpenApiSecurityRequirement
				  {
					{ jwtSecurityScheme, Array.Empty<string>() }
				  });

			});
		}
	}
}
