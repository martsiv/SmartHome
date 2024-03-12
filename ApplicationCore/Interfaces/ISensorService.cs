using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISensorService
	{
		Task<SensorDto> RegisterSensorAsync(RegisterSensorModel registerSensorModel);
		LoginSensorResponseModel LoginSensor(SensorDto sensor);
		Task RemoveSensorAsync(int sensorId);
		Task UpdateSensorAsync(int sensorId, SensorDto sensor);
		Task<IEnumerable<SensorDto>> GetAllSensorsAsync();
		Task<SensorDto> GetSensorByIdAsync(int sensorId);
		Task<SensorDto> GetSensorByIPAsync(string ipAddress);
		Task<SensorDto> GetSensorByMacAsync(string macAddress);
	}
}
