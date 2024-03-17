using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISubscriptionService
	{
		void AddSubscription(SubscriptionDto subscriptionDto);
		IEnumerable<SubscriptionDto> GetAllSubscriptions();
		IEnumerable<SubscriptionDto> GetSubscriptionsBySensor(int sensorId);
		IEnumerable<SubscriptionDto> GetSubscriptionsByTelegramChatId(int telegramChatId);
		SubscriptionDto? GetSubscription(int subscriptionId);
		void UpdateSubscription(int subscriptionId, SubscriptionDto subscriptionDto);
		void RemoveSubscription(int subscriptionId);
		Task AddSubscriptionAsync(SubscriptionDto subscriptionDto);
		Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync();
		Task<IEnumerable<SubscriptionDto>> GetSubscriptionsBySensorAsync(int sensorId);
		Task<IEnumerable<SubscriptionDto>> GetSubscriptionsByTelegramChatIdAsync(int telegramChatId);
		Task<SubscriptionDto?> GetSubscriptionAsync(int subscriptionId);
		Task UpdateSubscriptionAsync(int subscriptionId, SubscriptionDto subscriptionDto);
		Task RemoveSubscriptionAsync(int subscriptionId);
	}
}
