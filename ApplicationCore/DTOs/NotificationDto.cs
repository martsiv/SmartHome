namespace ApplicationCore.DTOs
{
	public class NotificationDto
	{
		public int Id { get; set; }
		public int SensorId { get; set; }
        public DateTime Date { get; set; }
		public string Message { get; set; }
        public int NotificationTypeId { get; set; }
    }
}
