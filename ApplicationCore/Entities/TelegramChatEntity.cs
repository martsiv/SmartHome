namespace ApplicationCore.Entities
{
	public class TelegramChatEntity
	{
        public int Id { get; set; }
        public long ChatId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }
		public virtual ICollection<Subscription> Subscriptions { get; set; } = new HashSet<Subscription>();
		public virtual ICollection<UserNotification> UserNotifications { get; set; } = new HashSet<UserNotification>();
	}
}
