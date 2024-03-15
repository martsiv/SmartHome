using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface IIndicatorService
	{
		Task<IEnumerable<IndicatorDto>> GetAllIndicatorsAsync();
		Task AddIndicatorAsync(IndicatorDto indicatorDto);
		Task RemoveIndicatorAsync(int indicatorId);
		Task<IndicatorDto> GetIndicatorAsync(int indicatorId);
		Task<IndicatorDto> GetIndicatorByNameAsync(string name);
		Task UpdateIndicatorAsync(int indicatorId, IndicatorDto indicatorDto);
	}
}
