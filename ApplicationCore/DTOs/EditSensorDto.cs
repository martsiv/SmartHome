namespace ApplicationCore.DTOs
{
	public class EditSensorDto
	{
		public string Name { get; set; }
		public int? RoomId { get; set; }
		public int? SensorTypeId { get; set; }
		public int? StateId { get; set; }
		public string SensorIP { get; set; }
	}
}
