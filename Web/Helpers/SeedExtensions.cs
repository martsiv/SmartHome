﻿using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace Web.Helpers
{
	public static class Roles
	{
		public const string Admin = "Admin";
		public const string User = "User";
		public const string Microcontroller = "Microcontroller";
	}

	public static class Seeder
	{
		public static async Task SeedRoles(this IServiceProvider app)
		{
			var roleManager = app.GetRequiredService<RoleManager<IdentityRole>>();

			var roles = typeof(Roles).GetFields(BindingFlags.Public | BindingFlags.Static |
						   BindingFlags.FlattenHierarchy).Select(x => (string)x.GetValue(null)!);

			foreach (var role in roles)
			{
				if (!await roleManager.RoleExistsAsync(role))
				{
					await roleManager.CreateAsync(new IdentityRole(role));
				}
			}
		}

		public static async Task SeedAdmin(this IServiceProvider app)
		{
			var userManager = app.GetRequiredService<UserManager<IdentityUser>>();

			const string USERNAME = "myadmin@myadmin.com";
			const string PASSWORD = "Admin1@";

			var existingUser = await userManager.FindByNameAsync(USERNAME);

			if (existingUser == null)
			{
				var user = new IdentityUser
				{
					UserName = USERNAME,
					Email = USERNAME
				};

				var result = await userManager.CreateAsync(user, PASSWORD);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
				}
			}
		}
	}
}
