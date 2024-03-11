namespace ApplicationCore.Entities
{
	public class Sensor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SensorTypeId { get; set; }
        public SensorType? SensorType { get; set; }
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
        public int? StateId { get; set; }
        public State? State { get; set; }
        public string SensorIP { get; set; }
        public string MacAddress { get; set; }
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        public ICollection<SensorSetting> SensorSettings { get; set; } = new HashSet<SensorSetting>();
        public ICollection<SensorDataStamp> SensorDataStamps { get; set; } = new HashSet<SensorDataStamp>();
    }
}
