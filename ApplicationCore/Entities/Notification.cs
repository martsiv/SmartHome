namespace ApplicationCore.Entities
{
	public class Notification
    {
        public int Id { get; set; }
        public int SensorId { get; set; }
        public Sensor? Sensor { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public int NotificationTypeId { get; set; }
        public NotificationType? NotificationType { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; } = new HashSet<Subscription>();
    }
}
