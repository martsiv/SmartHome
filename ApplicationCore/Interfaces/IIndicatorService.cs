using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface IIndicatorService
	{
		Task<IEnumerable<IndicatorDto>> GetAllIndicatorsAsync();
		Task AddIndicatorAsync(IndicatorDto indicatorDto);
		Task RemoveIndicatorAsync(int indicatorId);
		Task<IndicatorDto> GetIndicatorAsync(int indicatorId);
		Task UpdateIndicatorAsync(int indicatorId, IndicatorDto indicatorDto);
	}
}
