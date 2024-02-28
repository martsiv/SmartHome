using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
	public static class ServiceExtensions
	{
		public static void AddAutoMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
		}

		//public static void AddFluentValidator(this IServiceCollection services)
		//{
		//	//services.AddFluentValidationAutoValidation();
		//	// enable client-side validation
		//	//services.AddFluentValidationClientsideAdapters();
		//	// Load an assembly reference rather than using a marker type.
		//	services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
		//}

		public static void AddCustomServices(this IServiceCollection services)
		{
			services.AddScoped<ISensorService, SensorService>();
			services.AddScoped<IAccountsService, AccountsService>();
			services.AddScoped<IJwtService, JwtService>();
		}
	}
}
