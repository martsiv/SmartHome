using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;

namespace ApplicationCore.Services
{
	public class SubscriptionService : ISubscriptionService
	{
		private readonly IMapper mapper;
		private readonly IRepository<Subscription> subscriptionsRepo;
        public SubscriptionService(IMapper mapper,
							IRepository<Subscription> subscriptionsRepo)
        {
            this.mapper = mapper;
			this.subscriptionsRepo = subscriptionsRepo;
        }

		public async Task AddSubscriptionAsync(SubscriptionDto subscriptionDto)
		{
			var entity = mapper.Map<Subscription>(subscriptionDto);
			await subscriptionsRepo.InsertAsync(entity);
			await subscriptionsRepo.SaveAsync();
		}

		public async Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync()
		{
			var subscriptionEntities = await subscriptionsRepo.GetAllAsync();
			return mapper.Map<IEnumerable<SubscriptionDto>>(subscriptionEntities);
		}

		public async Task<SubscriptionDto> GetSubscriptionAsync(int subscriptionId)
		{
			var entity = await subscriptionsRepo.GetByIDAsync(subscriptionId);
			return mapper.Map<SubscriptionDto>(entity);
		}

		public async Task RemoveSubscriptionAsync(int subscriptionId)
		{
			var entity = await subscriptionsRepo.GetByIDAsync(subscriptionId);
			if (entity != null)
			{
				await subscriptionsRepo.DeleteAsync(subscriptionId);
				await subscriptionsRepo.SaveAsync();
			}
		}

		public async Task UpdateSubscriptionAsync(int subscriptionId, SubscriptionDto subscriptionDto)
		{
			var existingEntity = await subscriptionsRepo.GetByIDAsync(subscriptionId);
			if (existingEntity != null)
			{
				mapper.Map(subscriptionDto, existingEntity);
				subscriptionsRepo.Update(existingEntity);
				await subscriptionsRepo.SaveAsync();
			}
		}
	}
}
