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

		public void AddState(StateDto state)
		{
			var entity = mapper.Map<State>(state);
			statesRepo.Insert(entity);
			statesRepo.Save();
		}

		public async Task AddStateAsync(StateDto state)
		{
			var entity = mapper.Map<State>(state);
			await statesRepo.InsertAsync(entity);
			await statesRepo.SaveAsync();
		}

		public IEnumerable<StateDto> GetAllStates()
		{
			var states = statesRepo.GetAll();
			return mapper.Map<IEnumerable<StateDto>>(states);
		}

		public async Task<IEnumerable<StateDto>> GetAllStatesAsync()
		{
			var states = await statesRepo.GetAllAsync();
			return mapper.Map<IEnumerable<StateDto>>(states);
		}

		public StateDto? GetStateById(int stateId)
		{
			var entity = statesRepo.GetByID(stateId);
			if (entity == null) return null;
			return mapper.Map<StateDto>(entity);
		}

		public async Task<StateDto?> GetStateByIdAsync(int stateId)
		{
			var entity = await statesRepo.GetByIDAsync(stateId);
			if (entity == null) return null;
			return mapper.Map<StateDto>(entity);
		}

		public void RemoveState(int stateId)
		{
			var entity = statesRepo.GetByID(stateId);
			if (entity != null)
			{
				statesRepo.Delete(stateId);
				statesRepo.Save();
			}
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

		public void UpdateState(int stateId, StateDto state)
		{
			var existingentity = statesRepo.GetByID(stateId);
			if (existingentity != null)
			{
				mapper.Map(state, existingentity);
				statesRepo.Update(existingentity);
				statesRepo.Save();
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
