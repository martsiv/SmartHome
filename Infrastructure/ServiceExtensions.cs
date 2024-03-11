using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class ServiceExtensions
	{
		public static void AddDbContext(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<ApplicationContext>(opts =>
				opts.UseSqlServer(connectionString));
		}

		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
		}

		public static void AddIdentity(this IServiceCollection services)
		{
			services.AddIdentity<IdentityUser, IdentityRole>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false;
			})
			   .AddDefaultTokenProviders()
			   .AddEntityFrameworkStores<ApplicationContext>();
		}
	}
}
