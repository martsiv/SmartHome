using ApplicationCore.Entities;

namespace ApplicationCore.DTOs
{
	public class UserNotificationDto
	{
		public int Id { get; set; }
		public int TelegramChatId { get; set; }
		public int NotificationId { get; set; }
	}
}
