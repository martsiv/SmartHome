namespace ApplicationCore.DTOs
{
	public class GetSensorDataIndicatorModel
	{
        public int Id { get; set; }
        public int IndicatorId { get; set; }
        public string IndicatorName { get; set; }
        public int SensorDataStampId { get; set; }
        public decimal Value { get; set; }
    }
}
