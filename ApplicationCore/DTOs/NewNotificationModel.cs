namespace ApplicationCore.DTOs
{
	public class NewNotificationModel
	{
		public string SensorMacAddress { get; set; }
        public string Message { get; set; }
        public int PriorityLevel { get; set; }
    }
}
