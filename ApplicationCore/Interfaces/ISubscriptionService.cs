using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISubscriptionService
	{
		Task AddSubscriptionAsync(SubscriptionDto subscriptionDto);
		Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync();
		Task<IEnumerable<SubscriptionDto>> GetSubscriptionsBySensorAsync(int sensorId);
		Task<IEnumerable<SubscriptionDto>> GetSubscriptionsByTelegramChatIdAsync(int telegramChatId);
		Task<SubscriptionDto> GetSubscriptionAsync(int subscriptionId);
		Task UpdateSubscriptionAsync(int subscriptionId, SubscriptionDto subscriptionDto);
		Task RemoveSubscriptionAsync(int subscriptionId);
	}
}
