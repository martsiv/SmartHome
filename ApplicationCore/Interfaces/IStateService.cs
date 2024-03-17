using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface IStateService
	{
		void AddState(StateDto state);
		void RemoveState(int stateId);
		void UpdateState(int stateId, StateDto state);
		IEnumerable<StateDto> GetAllStates();
		StateDto? GetStateById(int stateId);
		Task AddStateAsync(StateDto state);
		Task RemoveStateAsync(int stateId);
		Task UpdateStateAsync(int stateId, StateDto state);
		Task<IEnumerable<StateDto>> GetAllStatesAsync();
		Task<StateDto?> GetStateByIdAsync(int stateId);
	}
}
