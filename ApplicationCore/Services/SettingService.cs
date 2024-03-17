using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;

namespace ApplicationCore.Services
{
	public class SettingService : ISettingService
	{
		private readonly IMapper mapper;
		private readonly IRepository<Setting> settingsRepo;
        public SettingService(IMapper mapper,
							IRepository<Setting> settingsRepo)
        {
            this.mapper = mapper;
			this.settingsRepo = settingsRepo;
        }

		public void AddSetting(SettingDto setting)
		{
			var entity = mapper.Map<Setting>(setting);
			settingsRepo.Insert(entity);
			settingsRepo.Save();
		}

		public async Task AddSettingAsync(SettingDto setting)
		{
			var entity = mapper.Map<Setting>(setting);
			await settingsRepo.InsertAsync(entity);
			await settingsRepo.SaveAsync();
		}

		public IEnumerable<SettingDto> GetAllSettings()
		{
			var settings = settingsRepo.GetAll();
			return mapper.Map<IEnumerable<SettingDto>>(settings);
		}

		public async Task<IEnumerable<SettingDto>> GetAllSettingsAsync()
		{
			var settings = await settingsRepo.GetAllAsync();
			return mapper.Map<IEnumerable<SettingDto>>(settings);
		}

		public SettingDto? GetSettingById(int settingId)
		{
			var entity = settingsRepo.GetByID(settingId);
			if (entity == null) return null;
			return mapper.Map<SettingDto>(entity);
		}

		public async Task<SettingDto?> GetSettingByIdAsync(int settingId)
		{
			var entity = await settingsRepo.GetByIDAsync(settingId);
			if (entity == null) return null;
			return mapper.Map<SettingDto>(entity);
		}

		public void RemoveSetting(int settingId)
		{
			var entity = settingsRepo.GetByID(settingId);
			if (entity != null)
			{
				settingsRepo.Delete(settingId);
				settingsRepo.Save();
			}
		}

		public async Task RemoveSettingAsync(int settingId)
		{
			var entity = await settingsRepo.GetByIDAsync(settingId);
			if (entity != null)
			{
				await settingsRepo.DeleteAsync(settingId);
				await settingsRepo.SaveAsync();
			}
		}

		public void UpdateSetting(int settingId, SettingDto setting)
		{
			var existingEntity = settingsRepo.GetByID(settingId);
			if (existingEntity != null)
			{
				mapper.Map(setting, existingEntity);
				settingsRepo.Update(existingEntity);
				settingsRepo.Save();
			}
		}

		public async Task UpdateSettingAsync(int settingId, SettingDto setting)
		{
			var existingEntity = await settingsRepo.GetByIDAsync(settingId);
			if (existingEntity != null)
			{
				mapper.Map(setting, existingEntity);
				settingsRepo.Update(existingEntity);
				await settingsRepo.SaveAsync();
			}
		}
	}
}
