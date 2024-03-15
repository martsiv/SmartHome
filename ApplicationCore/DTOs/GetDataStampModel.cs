namespace ApplicationCore.DTOs
{
	public class GetDataStampModel
	{
		public int Id { get; set; }
        public int SensorId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<GetSensorDataIndicatorModel> GetSensorDataIndicators { get; set; } = new List<GetSensorDataIndicatorModel>();
    }
}
