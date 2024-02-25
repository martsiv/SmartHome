using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public static class ModelBuilderExtensions
	{
		public static void SeedData(this ModelBuilder builder)
		{
			builder.Entity<Room>().HasData(new[]
			{
				new Room() { Id = 1, Name = "Corridor" },
				new Room() { Id = 2, Name = "Bedroom" },
				new Room() { Id = 3, Name = "Living room" },
				new Room() { Id = 4, Name = "Kitchen" },
				new Room() { Id = 5, Name = "Loggia" },
			});

			builder.Entity<State>().HasData(new[]
			{
				new State() { Id = 1, Name = "On" },
				new State() { Id = 2, Name = "Off" },
				new State() { Id = 3, Name = "Set standby mode" },
				new State() { Id = 4, Name = "Set detection mode" },
			});

			builder.Entity<SensorType>().HasData(new[]
			{
				new SensorType() { Id = 1, Name = "Temperature and humidity sensor" },
				new SensorType() { Id = 2, Name = "Fire detector" },
				new SensorType() { Id = 3, Name = "Motion and sound sensor" },
				new SensorType() { Id = 4, Name = "Smart socket controller" },
				new SensorType() { Id = 5, Name = "Keypad controller" },
				new SensorType() { Id = 6, Name = "RFID sensor" },
				new SensorType() { Id = 7, Name = "Lightning controller" },
				new SensorType() { Id = 8, Name = "Fan controller" },				
			});
		}
	}
}
