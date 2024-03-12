using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;

namespace ApplicationCore.Services
{
	public class SensorDataIndicatorService : ISensorDataIndicatorService
	{
		private readonly IMapper mapper;
		private readonly IRepository<SensorDataIndicator> sensorDataIndicatorsRepo;
        public SensorDataIndicatorService(IMapper mapper,
							IRepository<SensorDataIndicator> sensorDataIndicatorsRepo)
        {
            this.mapper = mapper;
			this.sensorDataIndicatorsRepo = sensorDataIndicatorsRepo;
        }

		public async Task AddSensorDataIndicatorAsync(SensorDataIndicatorDto sensorDataIndicatorDto)
		{
			var entity = mapper.Map<SensorDataIndicator>(sensorDataIndicatorDto);
			await sensorDataIndicatorsRepo.InsertAsync(entity);
			await sensorDataIndicatorsRepo.SaveAsync();
		}

		public async Task<IEnumerable<SensorDataIndicatorDto>> GetAllSensorDataIndicatorsAsync()
		{
			var telegramChatEntities = await sensorDataIndicatorsRepo.GetAllAsync();
			return mapper.Map<IEnumerable<SensorDataIndicatorDto>>(telegramChatEntities);
		}

		public async Task<SensorDataIndicatorDto> GetSensorDataIndicatorByIdAsync(int sensorDataIndicatorId)
		{
			var entity = await sensorDataIndicatorsRepo.GetByIDAsync(sensorDataIndicatorId);
			return mapper.Map<SensorDataIndicatorDto>(entity);
		}

		public async Task RemoveSensorDataIndicatorAsync(int sensorDataIndicatorId)
		{
			var entity = await sensorDataIndicatorsRepo.GetByIDAsync(sensorDataIndicatorId);
			if (entity != null)
			{
				await sensorDataIndicatorsRepo.DeleteAsync(sensorDataIndicatorId);
				await sensorDataIndicatorsRepo.SaveAsync();
			}
		}

		public async Task UpdateSensorDataIndicatorAsync(int sensorDataIndicatorId, SensorDataIndicatorDto sensorDataIndicatorDto)
		{
			var existingEntity = await sensorDataIndicatorsRepo.GetByIDAsync(sensorDataIndicatorId);
			if (existingEntity != null)
			{
				mapper.Map(sensorDataIndicatorDto, existingEntity);
				sensorDataIndicatorsRepo.Update(existingEntity);
				await sensorDataIndicatorsRepo.SaveAsync();
			}
		}
	}
}
