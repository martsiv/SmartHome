using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISensorTypeService
	{
		void AddSensorType(SensorTypeDto sensorType);
		void RemoveSensorType(int sensorTypeId);
		void UpdateSensorType(int sensorTypeId, SensorTypeDto sensorType);
		IEnumerable<SensorTypeDto?> GetAllSensorTypes();
		SensorTypeDto? GetSensorTypeById(int sensorTypeId);
		Task AddSensorTypeAsync(SensorTypeDto sensorType);
		Task RemoveSensorTypeAsync(int sensorTypeId);
		Task UpdateSensorTypeAsync(int sensorTypeId, SensorTypeDto sensorType);
		Task<IEnumerable<SensorTypeDto?>> GetAllSensorTypesAsync();
		Task<SensorTypeDto?> GetSensorTypeByIdAsync(int sensorTypeId);
	}
}
