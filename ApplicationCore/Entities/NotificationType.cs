namespace ApplicationCore.Entities
{
	public class NotificationType
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int PriorityLevel { get; set; }
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
    }
}
