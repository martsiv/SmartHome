using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISensorTypeService
	{
		Task AddSensorTypeAsync(SensorTypeDto sensorType);
		Task RemoveSensorTypeAsync(int sensorTypeId);
		Task UpdateSensorTypeAsync(int sensorTypeId, SensorTypeDto sensorType);
		Task<IEnumerable<SensorTypeDto>> GetAllSensorTypesAsync();
		Task<SensorTypeDto> GetSensorTypeByIdAsync(int sensorTypeId);
	}
}
