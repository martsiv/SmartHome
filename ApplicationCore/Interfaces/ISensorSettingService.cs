using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISensorSettingService
	{
		void AddSensorSetting(SensorSettingDto sensorSetting);
		void RemoveSensorSetting(int sensorSettingId);
		void RemoveSensorSettingsBySensor(int sensorId);
		void UpdateSensorSetting(int sensorSettingId, SensorSettingDto sensorSetting);
		IEnumerable<SensorSettingDto> GetAllSensorSettings();
		SensorSettingDto? GetSensorSettingById(int sensorSettingId);
		IEnumerable<SensorSettingDto> GetSensorSettingsBySensorId(int sensorId);
		Task AddSensorSettingAsync(SensorSettingDto sensorSetting);
		Task RemoveSensorSettingAsync(int sensorSettingId);
		Task RemoveSensorSettingsBySensorAsync(int sensorId);
		Task UpdateSensorSettingAsync(int sensorSettingId, SensorSettingDto sensorSetting);
		Task<IEnumerable<SensorSettingDto>> GetAllSensorSettingsAsync();
		Task<SensorSettingDto?> GetSensorSettingByIdAsync(int sensorSettingId);
		Task<IEnumerable<SensorSettingDto>> GetSensorSettingsBySensorIdAsync(int sensorId);
	}
}
