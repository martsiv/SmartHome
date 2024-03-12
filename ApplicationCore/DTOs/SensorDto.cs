namespace ApplicationCore.DTOs
{
	public class SensorDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int? RoomId { get; set; }
		public int? SensorTypeId { get; set; }
		public int? StateId { get; set; }
		public string SensorIP { get; set; }
        public string MacAddress { get; set; }
	}
}
