using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface IIndicatorService
	{
		IEnumerable<IndicatorDto> GetAllIndicators();
		void AddIndicator(IndicatorDto indicatorDto);
		void RemoveIndicator(int indicatorId);
		IndicatorDto? GetIndicator(int indicatorId);
		IndicatorDto? GetIndicatorByName(string name);
		void UpdateIndicator(int indicatorId, IndicatorDto indicatorDto);
		Task<IEnumerable<IndicatorDto>> GetAllIndicatorsAsync();
		Task AddIndicatorAsync(IndicatorDto indicatorDto);
		Task RemoveIndicatorAsync(int indicatorId);
		Task<IndicatorDto?> GetIndicatorAsync(int indicatorId);
		Task<IndicatorDto?> GetIndicatorByNameAsync(string name);
		Task UpdateIndicatorAsync(int indicatorId, IndicatorDto indicatorDto);
	}
}
