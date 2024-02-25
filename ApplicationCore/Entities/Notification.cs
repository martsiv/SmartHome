namespace ApplicationCore.Entities
{
	public class Notification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SensorId { get; set; }
        public Sensor? Sensor { get; set; }
        public DateTime Date { get; set; }
        public decimal Data { get; set; }
    }
}
