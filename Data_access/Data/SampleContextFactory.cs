using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Data
{
	//For creating output connection using a json resource file
	internal class SampleContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
	{
		public ApplicationContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

			ConfigurationBuilder builder = new ConfigurationBuilder();
			builder.SetBasePath(Directory.GetCurrentDirectory());
			builder.AddJsonFile("appsettings.json");
			IConfigurationRoot config = builder.Build();

			string connectionString = config.GetConnectionString("DefaultConnection");
			optionsBuilder.UseSqlServer(connectionString);
			return new ApplicationContext(optionsBuilder.Options);
		}
	}
}
