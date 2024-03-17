using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISensorService
	{
		SensorDto? RegisterSensor(RegisterSensorModel registerSensorModel);
		LoginSensorResponseModel LoginSensor(SensorDto sensor);
		void RemoveSensor(int sensorId);
		void UpdateSensor(int sensorId, SensorDto sensor);
		IEnumerable<SensorDto> GetAllSensors();
		SensorDto? GetSensorById(int sensorId);
		SensorDto? GetSensorByIP(string ipAddress);
		SensorDto? GetSensorByMac(string macAddress);
		Task<SensorDto?> RegisterSensorAsync(RegisterSensorModel registerSensorModel);
		Task RemoveSensorAsync(int sensorId);
		Task UpdateSensorAsync(int sensorId, SensorDto sensor);
		Task<IEnumerable<SensorDto>> GetAllSensorsAsync();
		Task<SensorDto?> GetSensorByIdAsync(int sensorId);
		Task<SensorDto?> GetSensorByIPAsync(string ipAddress);
		Task<SensorDto?> GetSensorByMacAsync(string macAddress);
	}
}
