﻿namespace ApplicationCore.DTOs
{
	public class RegisterSensorModel
	{
		public string Name { get; set; }
		public int? SensorTypeId { get; set; }
		public int? StateId { get; set; }
		public string SensorIP { get; set; }
        public string MacAddress { get; set; }
        public string RegisterKey { get; set; }
    }
}
