using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISettingService
	{
		void AddSetting(SettingDto setting);
		void RemoveSetting(int settingId);
		void UpdateSetting(int settingId, SettingDto setting);
		IEnumerable<SettingDto> GetAllSettings();
		SettingDto? GetSettingById(int settingId);
		Task AddSettingAsync(SettingDto setting);
		Task RemoveSettingAsync(int settingId);
		Task UpdateSettingAsync(int settingId, SettingDto setting);
		Task<IEnumerable<SettingDto>> GetAllSettingsAsync();
		Task<SettingDto?> GetSettingByIdAsync(int settingId);
	}
}
