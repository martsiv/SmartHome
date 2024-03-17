using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISensorDataIndicatorService
	{
		void AddSensorDataIndicator(SensorDataIndicatorDto sensorDataIndicatorDto);
		IEnumerable<SensorDataIndicatorDto> GetAllSensorDataIndicators();
		SensorDataIndicatorDto? GetSensorDataIndicatorById(int sensorDataIndicatorId);
		IEnumerable<GetSensorDataIndicatorModel> GetAllSensorDataIndicatorsByDataStampId(int dataStampId);
		void UpdateSensorDataIndicator(int sensorDataIndicatorId, SensorDataIndicatorDto sensorDataIndicatorDto);
		void RemoveSensorDataIndicator(int sensorDataIndicatorId);
		Task AddSensorDataIndicatorAsync(SensorDataIndicatorDto sensorDataIndicatorDto);
		Task<IEnumerable<SensorDataIndicatorDto>> GetAllSensorDataIndicatorsAsync();
		Task<SensorDataIndicatorDto?> GetSensorDataIndicatorByIdAsync(int sensorDataIndicatorId);
		Task<IEnumerable<GetSensorDataIndicatorModel>> GetAllSensorDataIndicatorsByDataStampIdAsync(int dataStampId);
		Task UpdateSensorDataIndicatorAsync(int sensorDataIndicatorId, SensorDataIndicatorDto sensorDataIndicatorDto);
		Task RemoveSensorDataIndicatorAsync(int sensorDataIndicatorId);
	}
}
