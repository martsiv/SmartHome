using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISensorDataIndicatorService
	{
		Task AddSensorDataIndicatorAsync(SensorDataIndicatorDto sensorDataIndicatorDto);
		Task<IEnumerable<SensorDataIndicatorDto>> GetAllSensorDataIndicatorsAsync();
		Task<SensorDataIndicatorDto> GetSensorDataIndicatorByIdAsync(int sensorDataIndicatorId);
		Task<IEnumerable<GetSensorDataIndicatorModel>> GetAllSensorDataIndicatorsByDataStampIdAsync(int dataStampId);
		Task UpdateSensorDataIndicatorAsync(int sensorDataIndicatorId, SensorDataIndicatorDto sensorDataIndicatorDto);
		Task RemoveSensorDataIndicatorAsync(int sensorDataIndicatorId);
	}
}
