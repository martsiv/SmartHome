using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISensorDataStampService
	{
		Task AddSensorDataStampAsync(SensorDataStampDto sensorDataStamp);
		Task<IEnumerable<SensorDataStampDto>> GetAllSensorDataStampsAsync();
		Task<IEnumerable<SensorDataStampDto>> GetAllSensorDataStampsByDateAsync(DateTime dateTime);
		Task<IEnumerable<SensorDataStampDto>> GetAllSensorDataStampsBySensorAsync(int sensorId);
		Task<SensorDataStampDto> GetSensorDataStampByIdAsync(int sensorDataStampId);
		Task UpdateSensorDataStampAsync(int sensorDataStampId, SensorDataStampDto sensorDataStampDto);
		Task RemoveSensorDataStampAsync(int sensorDataStampId);
		Task<HttpResponseMessage> GetNewDataStamsAsync(SensorDto sensor);
	}
}
