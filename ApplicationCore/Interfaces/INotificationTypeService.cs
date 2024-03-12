using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface INotificationTypeService
	{
		Task AddNotificationTypeAsync(NotificationTypeDto notificationTypeDto);
		Task<IEnumerable<NotificationTypeDto>> GetAllNotificationTypesAsync();
		Task<NotificationTypeDto> GetNotificationTypeAsync(int notificationTypeId);
		Task<NotificationTypeDto> GetNotificationTypeByLevelAsync(int level);
		Task UpdateNotificationTypeAsync(int notificationTypeId, NotificationTypeDto notificationTypeDto);
		Task RemoveNotificationTypeAsync(int notificationTypeId);
	}
}
