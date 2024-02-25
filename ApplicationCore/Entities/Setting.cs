namespace ApplicationCore.Entities
{
	public class Setting
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public IEnumerable<SensorSetting> SensorSettings { get; set; }
    }
}
