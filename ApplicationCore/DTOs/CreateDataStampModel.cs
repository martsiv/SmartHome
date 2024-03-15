namespace ApplicationCore.DTOs
{
	public class CreateDataStampModel
	{
        public string SensorMacAddress { get; set; }
		public Dictionary<string, decimal> DataIndicators { get; set; }
    }
}
