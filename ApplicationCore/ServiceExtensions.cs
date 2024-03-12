using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;

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
			services.AddScoped<IAccountsService, AccountsService>();
			services.AddScoped<IIndicatorService, IndicatorService>();
			services.AddScoped<IJwtService, JwtService>();
			services.AddScoped<INotificationService, NotificationService>();
			services.AddScoped<INotificationTypeService, NotificationTypeService>();
			services.AddScoped<IRoomService, RoomService>();
			services.AddScoped<ISensorDataIndicatorService, SensorDataIndicatorService>();
			services.AddScoped<ISensorDataStampService, SensorDataStampService>();
			services.AddScoped<ISensorService, SensorService>();
			services.AddScoped<ISensorSettingService, SensorSettingService>();
			services.AddScoped<ISensorTypeService, SensorTypeService>();
			services.AddScoped<ISettingService, SettingService>();
			services.AddScoped<IStateService, StateService>();
			services.AddScoped<ISubscriptionService, SubscriptionService>();
			services.AddScoped<ITelegramChatService, TelegramChatService>();
		}
	}
}
