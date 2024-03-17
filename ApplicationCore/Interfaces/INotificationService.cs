using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface INotificationService
	{
		NotificationDto? GetLastNotifications(int sensorId);
		IEnumerable<NotificationDto> GetAllNotifications();
		NotificationDto? GetNotification(int notificationId);
		void InsertNotification(NotificationDto notificationDto);
		void RemoveNotification(int notificationId);
		Task<NotificationDto?> GetLastNotificationsAsync(int sensorId);
		Task<IEnumerable<NotificationDto>> GetAllNotificationsAsync();
		Task<NotificationDto?> GetNotificationAsync(int notificationId);
		Task InsertNotificationAsync(NotificationDto notificationDto);
		Task RemoveNotificationAsync(int notificationId);
	}
}
