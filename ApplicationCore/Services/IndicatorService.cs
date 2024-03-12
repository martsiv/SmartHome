using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
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

		public async Task AddIndicatorAsync(IndicatorDto indicatorDto)
		{
			var entity = mapper.Map<Indicator>(indicatorDto);
			await indicatorsRepo.InsertAsync(entity);
			await indicatorsRepo.SaveAsync();
		}

		public async Task<IEnumerable<IndicatorDto>> GetAllIndicatorsAsync()
		{
			var indicators = await indicatorsRepo.GetAllAsync();
			return mapper.Map<IEnumerable<IndicatorDto>>(indicators);
		}

		public async Task<IndicatorDto> GetIndicatorAsync(int indicatorId)
		{
			var entity = await indicatorsRepo.GetByIDAsync(indicatorId);
			return mapper.Map<IndicatorDto>(entity);
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
