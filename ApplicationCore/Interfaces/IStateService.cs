using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface IStateService
	{
		Task AddStateAsync(StateDto state);
		Task RemoveStateAsync(int stateId);
		Task UpdateStateAsync(int stateId, StateDto state);
		Task<IEnumerable<StateDto>> GetAllStatesAsync();
		Task<StateDto> GetStateByIdAsync(int stateId);
	}
}
