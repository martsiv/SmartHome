using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISubscriptionService
	{
		Task AddSubscriptionAsync(SubscriptionDto subscriptionDto);
		Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync();
		Task<SubscriptionDto> GetSubscriptionAsync(int subscriptionId);
		Task UpdateSubscriptionAsync(int subscriptionId, SubscriptionDto subscriptionDto);
		Task RemoveSubscriptionAsync(int subscriptionId);
	}
}
