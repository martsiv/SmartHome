using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;

namespace ApplicationCore.Services
{
	public class IndicatorService : IIndicatorService
	{
		private readonly IMapper mapper;
		private readonly IRepository<Indicator> indicatorsRepo;
		public IndicatorService(IMapper mapper,
							IRepository<Indicator> indicatorsRepo)
        {
            this.mapper = mapper;
			this.indicatorsRepo = indicatorsRepo;
        }

		public void AddIndicator(IndicatorDto indicatorDto)
		{
			var entity = mapper.Map<Indicator>(indicatorDto);
			indicatorsRepo.Insert(entity);
			indicatorsRepo.Save();
		}

		public async Task AddIndicatorAsync(IndicatorDto indicatorDto)
		{
			var entity = mapper.Map<Indicator>(indicatorDto);
			await indicatorsRepo.InsertAsync(entity);
			await indicatorsRepo.SaveAsync();
		}

		public IEnumerable<IndicatorDto> GetAllIndicators()
		{
			var indicators = indicatorsRepo.GetAll();
			return mapper.Map<IEnumerable<IndicatorDto>>(indicators);
		}

		public async Task<IEnumerable<IndicatorDto>> GetAllIndicatorsAsync()
		{
			var indicators = await indicatorsRepo.GetAllAsync();
			return mapper.Map<IEnumerable<IndicatorDto>>(indicators);
		}

		public IndicatorDto? GetIndicator(int indicatorId)
		{
			var entity = indicatorsRepo.GetByID(indicatorId);
			if (entity == null) return null;
			return mapper.Map<IndicatorDto>(entity);
		}

		public async Task<IndicatorDto?> GetIndicatorAsync(int indicatorId)
		{
			var entity = await indicatorsRepo.GetByIDAsync(indicatorId);
			if (entity == null) return null;
			return mapper.Map<IndicatorDto>(entity);
		}

		public IndicatorDto? GetIndicatorByName(string name)
		{
			var entity = indicatorsRepo.GetItemBySpec(new IndicatorSpecs.ByName(name));
			if (entity == null) return null;
			return mapper.Map<IndicatorDto>(entity);
		}

		public async Task<IndicatorDto?> GetIndicatorByNameAsync(string name)
		{
			var entity = await indicatorsRepo.GetItemBySpecAsync(new IndicatorSpecs.ByName(name));
			if (entity == null) return null;
			return mapper.Map<IndicatorDto>(entity);
		}

		public void RemoveIndicator(int indicatorId)
		{
			var entity = indicatorsRepo.GetByID(indicatorId);
			if (entity != null)
			{
				indicatorsRepo.Delete(indicatorId);
				indicatorsRepo.Save();
			}
		}

		public async Task RemoveIndicatorAsync(int indicatorId)
		{
			var entity = await indicatorsRepo.GetByIDAsync(indicatorId);
			if (entity != null)
			{
				await indicatorsRepo.DeleteAsync(indicatorId);
				await indicatorsRepo.SaveAsync();
			}
		}

		public void UpdateIndicator(int indicatorId, IndicatorDto indicatorDto)
		{
			var existingEntity = indicatorsRepo.GetByID(indicatorId);
			if (existingEntity != null)
			{
				mapper.Map(indicatorDto, existingEntity);
				indicatorsRepo.Update(existingEntity);
				indicatorsRepo.Save();
			}
		}

		public async Task UpdateIndicatorAsync(int indicatorId, IndicatorDto indicatorDto)
		{
			var existingEntity = await indicatorsRepo.GetByIDAsync(indicatorId);
			if (existingEntity != null)
			{
				mapper.Map(indicatorDto, existingEntity);
				indicatorsRepo.Update(existingEntity);
				await indicatorsRepo.SaveAsync();
			}
		}
	}
}
