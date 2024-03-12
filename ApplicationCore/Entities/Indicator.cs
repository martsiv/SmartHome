namespace ApplicationCore.Entities
{
	public class Indicator
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SensorDataIndicator> SensorDataIndicators { get; set; } = new HashSet<SensorDataIndicator>();
    }
}
