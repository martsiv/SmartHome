using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface INotificationService
	{
		Task<NotificationDto> GetLastNotificationsAsync(int sensorId);
		Task<IEnumerable<NotificationDto>> GetAllNotificationsAsync();
		Task<NotificationDto> GetNotificationAsync(int notificationId);
		Task InsertNotificationAsync(NotificationDto notificationDto);
		Task RemoveNotificationAsync(int notificationId);
	}
}
