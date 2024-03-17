using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface INotificationTypeService
	{
		void AddNotificationType(NotificationTypeDto notificationTypeDto);
		IEnumerable<NotificationTypeDto> GetAllNotificationTypes();
		NotificationTypeDto? GetNotificationType(int notificationTypeId);
		NotificationTypeDto? GetNotificationTypeByLevel(int level);
		void UpdateNotificationType(int notificationTypeId, NotificationTypeDto notificationTypeDto);
		void RemoveNotificationType(int notificationTypeId);
		Task AddNotificationTypeAsync(NotificationTypeDto notificationTypeDto);
		Task<IEnumerable<NotificationTypeDto>> GetAllNotificationTypesAsync();
		Task<NotificationTypeDto?> GetNotificationTypeAsync(int notificationTypeId);
		Task<NotificationTypeDto?> GetNotificationTypeByLevelAsync(int level);
		Task UpdateNotificationTypeAsync(int notificationTypeId, NotificationTypeDto notificationTypeDto);
		Task RemoveNotificationTypeAsync(int notificationTypeId);
	}
}
