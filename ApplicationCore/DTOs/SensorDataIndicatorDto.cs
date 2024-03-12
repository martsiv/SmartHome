namespace ApplicationCore.DTOs
{
	public class SensorDataIndicatorDto
	{
		public int Id { get; set; }
		public int IndicatorId { get; set; }
		public int SensorDataId { get; set; }
		public decimal Value { get; set; }
	}
}
