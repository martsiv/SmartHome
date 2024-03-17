using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;

namespace ApplicationCore.Services
{
	public class SensorTypeService : ISensorTypeService
	{
		private readonly IMapper mapper;
		private readonly IRepository<SensorType> sensorTypesRepo;
        public SensorTypeService(IMapper mapper,
							IRepository<SensorType> sensorTypesRepo)
        {
            this.mapper = mapper;
			this.sensorTypesRepo = sensorTypesRepo;
        }

		public void AddSensorType(SensorTypeDto sensorType)
		{
			var entity = mapper.Map<SensorType>(sensorType);
			sensorTypesRepo.Insert(entity);
			sensorTypesRepo.Save();
		}

		public async Task AddSensorTypeAsync(SensorTypeDto sensorType)
		{
			var entity = mapper.Map<SensorType>(sensorType);
			await sensorTypesRepo.InsertAsync(entity);
			await sensorTypesRepo.SaveAsync();
		}

		public IEnumerable<SensorTypeDto?> GetAllSensorTypes()
		{
			var sensorTypes = sensorTypesRepo.GetAll();
			return mapper.Map<IEnumerable<SensorTypeDto>>(sensorTypes);
		}

		public async Task<IEnumerable<SensorTypeDto>> GetAllSensorTypesAsync()
		{
			var sensorTypes = await sensorTypesRepo.GetAllAsync();
			return mapper.Map<IEnumerable<SensorTypeDto>>(sensorTypes);
		}

		public SensorTypeDto? GetSensorTypeById(int sensorTypeId)
		{
			var entity = sensorTypesRepo.GetByID(sensorTypeId);
			if (entity == null) return null;
			return mapper.Map<SensorTypeDto>(entity);
		}

		public async Task<SensorTypeDto?> GetSensorTypeByIdAsync(int sensorTypeId)
		{
			var entity = await sensorTypesRepo.GetByIDAsync(sensorTypeId);
			if (entity == null) return null;
			return mapper.Map<SensorTypeDto>(entity);
		}

		public void RemoveSensorType(int sensorTypeId)
		{
			var entity = sensorTypesRepo.GetByID(sensorTypeId);
			if (entity != null)
			{
				sensorTypesRepo.Delete(sensorTypeId);
				sensorTypesRepo.Save();
			}
		}

		public async Task RemoveSensorTypeAsync(int sensorTypeId)
		{
			var entity = await sensorTypesRepo.GetByIDAsync(sensorTypeId);
			if (entity != null)
			{
				await sensorTypesRepo.DeleteAsync(sensorTypeId);
				await sensorTypesRepo.SaveAsync();
			}
		}

		public void UpdateSensorType(int sensorTypeId, SensorTypeDto sensorType)
		{
			var existingEntity = sensorTypesRepo.GetByID(sensorTypeId);
			if (existingEntity != null)
			{
				mapper.Map(sensorType, existingEntity);
				sensorTypesRepo.Update(existingEntity);
				sensorTypesRepo.Save();
			}
		}

		public async Task UpdateSensorTypeAsync(int sensorTypeId, SensorTypeDto sensorType)
		{
			var existingEntity = await sensorTypesRepo.GetByIDAsync(sensorTypeId);
			if (existingEntity != null)
			{
				mapper.Map(sensorType, existingEntity);
				sensorTypesRepo.Update(existingEntity);
				await sensorTypesRepo.SaveAsync();
			}
		}
	}
}
