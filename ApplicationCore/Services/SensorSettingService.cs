using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;

namespace ApplicationCore.Services
{
	public class SensorSettingService : ISensorSettingService
	{
		private readonly IMapper mapper;
		private readonly IRepository<SensorSetting> sensorSettingsRepo;
        public SensorSettingService(IMapper mapper,
							IRepository<SensorSetting> sensorSettingsRepo)
        {
            this.mapper = mapper;
			this.sensorSettingsRepo = sensorSettingsRepo;
        }
		public async Task AddSensorSettingAsync(SensorSettingDto sensorSetting)
		{
			var entity = mapper.Map<SensorSetting>(sensorSetting);
			await sensorSettingsRepo.InsertAsync(entity);
			await sensorSettingsRepo.SaveAsync();
		}

		public async Task<IEnumerable<SensorSettingDto>> GetAllSensorSettingsAsync()
		{
			var sensorSettings = await sensorSettingsRepo.GetAllAsync();
			return mapper.Map<IEnumerable<SensorSettingDto>>(sensorSettings);
		}

		public async Task<SensorSettingDto> GetSensorSettingByIdAsync(int sensorSettingId)
		{
			var sensorSetting = await sensorSettingsRepo.GetByIDAsync(sensorSettingId);
			return mapper.Map<SensorSettingDto>(sensorSetting);
		}

		public async Task<IEnumerable<SensorSettingDto>> GetSensorSettingsBySensorIdAsync(int sensorId)
		{
			var sensorSettings = await sensorSettingsRepo.GetListBySpecAsync(new SensorSettingsSpecs.BySensorId(sensorId));
			return mapper.Map<IEnumerable<SensorSettingDto>>(sensorSettings);
		}

		public async Task RemoveSensorSettingAsync(int sensorSettingId)
		{
			var sensorSetting = await sensorSettingsRepo.GetByIDAsync(sensorSettingId);
			if (sensorSetting != null)
			{
				await sensorSettingsRepo.DeleteAsync(sensorSettingId);
				await sensorSettingsRepo.SaveAsync();
			}
		}

		public async Task RemoveSensorSettingsBySensorAsync(int sensorId)
		{
			var sensorSettings = await sensorSettingsRepo.GetListBySpecAsync(new SensorSettingsSpecs.BySensorId(sensorId));
			foreach (var setting in sensorSettings)
			{
				sensorSettingsRepo.Delete(setting);
			}
			await sensorSettingsRepo.SaveAsync();
		}

		public async Task UpdateSensorSettingAsync(int sensorSettingId, SensorSettingDto sensorSetting)
		{
			var existingSensorSetting = await sensorSettingsRepo.GetByIDAsync(sensorSettingId);
			if (existingSensorSetting != null)
			{
				// TODO Send new settings to sensor
				mapper.Map(sensorSetting, existingSensorSetting);
				sensorSettingsRepo.Update(existingSensorSetting);
				await sensorSettingsRepo.SaveAsync();
			}
		}
	}
}
