using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;

namespace ApplicationCore.Services
{
	public class StateService : IStateService
	{
		private readonly IMapper mapper;
		private readonly IRepository<State> statesRepo;
        public StateService(IMapper mapper,
							IRepository<State> statesRepo)
        {
            this.mapper = mapper;
			this.statesRepo = statesRepo;
        }
		public async Task AddStateAsync(StateDto state)
		{
			var entity = mapper.Map<State>(state);
			await statesRepo.InsertAsync(entity);
			await statesRepo.SaveAsync();
		}

		public async Task<IEnumerable<StateDto>> GetAllStatesAsync()
		{
			var states = await statesRepo.GetAllAsync();
			return mapper.Map<IEnumerable<StateDto>>(states);
		}

		public async Task<StateDto> GetStateByIdAsync(int stateId)
		{
			var entity = await statesRepo.GetByIDAsync(stateId);
			return mapper.Map<StateDto>(entity);
		}

		public async Task RemoveStateAsync(int stateId)
		{
			var entity = await statesRepo.GetByIDAsync(stateId);
			if (entity != null)
			{
				await statesRepo.DeleteAsync(stateId);
				await statesRepo.SaveAsync();
			}
		}

		public async Task UpdateStateAsync(int stateId, StateDto state)
		{
			var existingentity = await statesRepo.GetByIDAsync(stateId);
			if (existingentity != null)
			{
				mapper.Map(state, existingentity);
				statesRepo.Update(existingentity);
				await statesRepo.SaveAsync();
			}
		}
	}
}
