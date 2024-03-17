using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISensorDataStampService
	{
		void AddSensorDataStamp(SensorDataStampDto sensorDataStamp);
		IEnumerable<SensorDataStampDto> GetAllSensorDataStamps();
		IEnumerable<SensorDataStampDto> GetAllSensorDataStampsByDate(DateTime dateTime);
		IEnumerable<SensorDataStampDto> GetAllSensorDataStampsBySensor(int sensorId);
		SensorDataStampDto? GetSensorDataStampById(int sensorDataStampId);
		SensorDataStampDto? GetLastSensorDataStampByDate(DateTime dateTime);
		void UpdateSensorDataStamp(int sensorDataStampId, SensorDataStampDto sensorDataStampDto);
		void RemoveSensorDataStamp(int sensorDataStampId);
		Task AddSensorDataStampAsync(SensorDataStampDto sensorDataStamp);
		Task<IEnumerable<SensorDataStampDto>> GetAllSensorDataStampsAsync();
		Task<IEnumerable<SensorDataStampDto>> GetAllSensorDataStampsByDateAsync(DateTime dateTime);
		Task<IEnumerable<SensorDataStampDto>> GetAllSensorDataStampsBySensorAsync(int sensorId);
		Task<SensorDataStampDto?> GetSensorDataStampByIdAsync(int sensorDataStampId);
		Task<SensorDataStampDto?> GetLastSensorDataStampByDateAsync(DateTime dateTime);
		Task UpdateSensorDataStampAsync(int sensorDataStampId, SensorDataStampDto sensorDataStampDto);
		Task RemoveSensorDataStampAsync(int sensorDataStampId);
		Task<HttpResponseMessage> GetNewDataStamsAsync(SensorDto sensor);
	}
}
