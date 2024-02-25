namespace ApplicationCore.Entities
{
	public class SensorSetting
	{
        public int Id { get; set; }
        public int SensorId { get; set; }
        public int SettingId { get; set; }
        public Sensor? Sensor { get; set; }
        public Setting? Setting { get; set; }
    }
}
