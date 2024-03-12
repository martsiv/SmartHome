using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISensorSettingService
	{
		Task AddSensorSettingAsync(SensorSettingDto sensorSetting);
		Task RemoveSensorSettingAsync(int sensorSettingId);
		Task RemoveSensorSettingsBySensorAsync(int sensorId);
		Task UpdateSensorSettingAsync(int sensorSettingId, SensorSettingDto sensorSetting);
		Task<IEnumerable<SensorSettingDto>> GetAllSensorSettingsAsync();
		Task<SensorSettingDto> GetSensorSettingByIdAsync(int sensorSettingId);
		Task<IEnumerable<SensorSettingDto>> GetSensorSettingsBySensorIdAsync(int sensorId);
	}
}
