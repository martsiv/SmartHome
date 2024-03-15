namespace ApplicationCore.Entities
{
	public class UserNotification
	{
        public int Id { get; set; }
        public int TelegramChatId { get; set; }
        public TelegramChatEntity? TelegramChat { get; set; }
        public int NotificationId { get; set; }
        public Notification? Notification { get; set; }
    }
}
