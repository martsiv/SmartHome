using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;
using static ApplicationCore.Specifications.SensorSettingsSpecs;

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

		public void AddSubscription(SubscriptionDto subscriptionDto)
		{
			var entity = mapper.Map<Subscription>(subscriptionDto);
			subscriptionsRepo.Insert(entity);
			subscriptionsRepo.Save();
		}

		public async Task AddSubscriptionAsync(SubscriptionDto subscriptionDto)
		{
			var entity = mapper.Map<Subscription>(subscriptionDto);
			await subscriptionsRepo.InsertAsync(entity);
			await subscriptionsRepo.SaveAsync();
		}

		public IEnumerable<SubscriptionDto> GetAllSubscriptions()
		{
			var subscriptionEntities = subscriptionsRepo.GetAll();
			return mapper.Map<IEnumerable<SubscriptionDto>>(subscriptionEntities);
		}

		public async Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync()
		{
			var subscriptionEntities = await subscriptionsRepo.GetAllAsync();
			return mapper.Map<IEnumerable<SubscriptionDto>>(subscriptionEntities);
		}

		public SubscriptionDto? GetSubscription(int subscriptionId)
		{
			var entity = subscriptionsRepo.GetByID(subscriptionId);
			if (entity == null) return null;
			return mapper.Map<SubscriptionDto>(entity);
		}

		public async Task<SubscriptionDto?> GetSubscriptionAsync(int subscriptionId)
		{
			var entity = await subscriptionsRepo.GetByIDAsync(subscriptionId);
			if (entity == null) return null;
			return mapper.Map<SubscriptionDto>(entity);
		}

		public IEnumerable<SubscriptionDto> GetSubscriptionsBySensor(int sensorId)
		{
			var subscriptionEntities = subscriptionsRepo.GetListBySpec(new SubscriptionSpecs.BySensor(sensorId));
			return mapper.Map<IEnumerable<SubscriptionDto>>(subscriptionEntities);
		}

		public async Task<IEnumerable<SubscriptionDto>> GetSubscriptionsBySensorAsync(int sensorId)
		{
			var subscriptionEntities = await subscriptionsRepo.GetListBySpecAsync(new SubscriptionSpecs.BySensor(sensorId));
			return mapper.Map<IEnumerable<SubscriptionDto>>(subscriptionEntities);
		}

		public IEnumerable<SubscriptionDto> GetSubscriptionsByTelegramChatId(int telegramChatId)
		{
			var subscriptionEntities = subscriptionsRepo.GetListBySpec(new SubscriptionSpecs.ByChat(telegramChatId));
			return mapper.Map<IEnumerable<SubscriptionDto>>(subscriptionEntities);
		}

		public async Task<IEnumerable<SubscriptionDto>> GetSubscriptionsByTelegramChatIdAsync(int telegramChatId)
		{
			var subscriptionEntities = await subscriptionsRepo.GetListBySpecAsync(new SubscriptionSpecs.ByChat(telegramChatId));
			return mapper.Map<IEnumerable<SubscriptionDto>>(subscriptionEntities);
		}

		public void RemoveSubscription(int subscriptionId)
		{
			var entity = subscriptionsRepo.GetByID(subscriptionId);
			if (entity != null)
			{
				subscriptionsRepo.Delete(subscriptionId);
				subscriptionsRepo.Save();
			}
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

		public void UpdateSubscription(int subscriptionId, SubscriptionDto subscriptionDto)
		{
			var existingEntity = subscriptionsRepo.GetByID(subscriptionId);
			if (existingEntity != null)
			{
				mapper.Map(subscriptionDto, existingEntity);
				subscriptionsRepo.Update(existingEntity);
				subscriptionsRepo.Save();
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
