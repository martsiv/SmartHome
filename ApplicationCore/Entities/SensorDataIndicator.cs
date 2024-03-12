namespace ApplicationCore.Entities
{
	public class SensorDataIndicator
	{
        public int Id { get; set; }
        public int IndicatorId { get; set; }
        public Indicator? Indicator { get; set; }
        public int SensorDataId { get; set; }
        public SensorDataStamp? SensorData { get; set; }
        public decimal Value { get; set; }
    }
}
