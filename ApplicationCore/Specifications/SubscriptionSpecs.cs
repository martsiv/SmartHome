using ApplicationCore.Entities;
using Ardalis.Specification;

namespace ApplicationCore.Specifications
{
	public static class SubscriptionSpecs
	{
		public class BySensor : Specification<Subscription>
		{
			public BySensor(int sensorId)
			{
				Query.Where(x => x.SensorId == sensorId);
			}
		}
		public class ByChat: Specification<Subscription>
		{
			public ByChat(int telegramChatId)
			{
				Query.Where(x => x.TelegramChatId == telegramChatId);
			}
		}
	}
}
