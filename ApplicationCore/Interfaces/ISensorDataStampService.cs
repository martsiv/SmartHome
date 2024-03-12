﻿using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISensorDataStampService
	{
		Task AddSensorDataStampAsync(SensorDataStampDto sensorDataStamp);
		Task<IEnumerable<SensorDataStampDto>> GetAllSensorDataStampsAsync();
		Task<SensorDataStampDto> GetSensorDataStampByIdAsync(int sensorDataStampId);
		Task UpdateSensorDataStampAsync(int sensorDataStampId, SensorDataStampDto sensorDataStampDto);
		Task RemoveSensorDataStampAsync(int sensorDataStampId);
		Task<HttpResponseMessage> GetNewDataStamsAsync(SensorDto sensor);
	}
}
