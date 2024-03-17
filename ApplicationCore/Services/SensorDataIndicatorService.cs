using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
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

		public void AddSensorDataIndicator(SensorDataIndicatorDto sensorDataIndicatorDto)
		{
			var entity = mapper.Map<SensorDataIndicator>(sensorDataIndicatorDto);
			sensorDataIndicatorsRepo.Insert(entity);
			sensorDataIndicatorsRepo.Save();
		}

		public async Task AddSensorDataIndicatorAsync(SensorDataIndicatorDto sensorDataIndicatorDto)
		{
			var entity = mapper.Map<SensorDataIndicator>(sensorDataIndicatorDto);
			await sensorDataIndicatorsRepo.InsertAsync(entity);
			await sensorDataIndicatorsRepo.SaveAsync();
		}

		public IEnumerable<SensorDataIndicatorDto> GetAllSensorDataIndicators()
		{
			var telegramChatEntities = sensorDataIndicatorsRepo.GetAll();
			return mapper.Map<IEnumerable<SensorDataIndicatorDto>>(telegramChatEntities);
		}

		public async Task<IEnumerable<SensorDataIndicatorDto>> GetAllSensorDataIndicatorsAsync()
		{
			var telegramChatEntities = await sensorDataIndicatorsRepo.GetAllAsync();
			return mapper.Map<IEnumerable<SensorDataIndicatorDto>>(telegramChatEntities);
		}

		public IEnumerable<GetSensorDataIndicatorModel> GetAllSensorDataIndicatorsByDataStampId(int dataStampId)
		{
			var entities = sensorDataIndicatorsRepo.GetListBySpec(new SensorDataIndicatorSpecs.ByDataStampId(dataStampId));
			return mapper.Map<IEnumerable<GetSensorDataIndicatorModel>>(entities);
		}

		public async Task<IEnumerable<GetSensorDataIndicatorModel>> GetAllSensorDataIndicatorsByDataStampIdAsync(int dataStampId)
		{
			var entities = await sensorDataIndicatorsRepo.GetListBySpecAsync(new SensorDataIndicatorSpecs.ByDataStampId(dataStampId));
			return mapper.Map<IEnumerable<GetSensorDataIndicatorModel>>(entities);
		}

		public SensorDataIndicatorDto? GetSensorDataIndicatorById(int sensorDataIndicatorId)
		{
			var entity = sensorDataIndicatorsRepo.GetByID(sensorDataIndicatorId);
			if (entity == null) return null;
			return mapper.Map<SensorDataIndicatorDto>(entity);
		}

		public async Task<SensorDataIndicatorDto?> GetSensorDataIndicatorByIdAsync(int sensorDataIndicatorId)
		{
			var entity = await sensorDataIndicatorsRepo.GetByIDAsync(sensorDataIndicatorId);
			if (entity == null) return null;
			return mapper.Map<SensorDataIndicatorDto>(entity);
		}

		public void RemoveSensorDataIndicator(int sensorDataIndicatorId)
		{
			var entity = sensorDataIndicatorsRepo.GetByID(sensorDataIndicatorId);
			if (entity != null)
			{
				sensorDataIndicatorsRepo.Delete(sensorDataIndicatorId);
				sensorDataIndicatorsRepo.Save();
			}
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

		public void UpdateSensorDataIndicator(int sensorDataIndicatorId, SensorDataIndicatorDto sensorDataIndicatorDto)
		{
			var existingEntity = sensorDataIndicatorsRepo.GetByID(sensorDataIndicatorId);
			if (existingEntity != null)
			{
				mapper.Map(sensorDataIndicatorDto, existingEntity);
				sensorDataIndicatorsRepo.Update(existingEntity);
				sensorDataIndicatorsRepo.Save();
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
