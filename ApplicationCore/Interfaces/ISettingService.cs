using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISettingService
	{
		Task AddSettingAsync(SettingDto setting);
		Task RemoveSettingAsync(int settingId);
		Task UpdateSettingAsync(int settingId, SettingDto setting);
		Task<IEnumerable<SettingDto>> GetAllSettingsAsync();
		Task<SettingDto> GetSettingByIdAsync(int settingId);
	}
}
