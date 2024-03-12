using ApplicationCore.Entities;
using Ardalis.Specification;

namespace ApplicationCore.Specifications
{
	public static class NotificationTypeSpecs
	{
		public class ByLevel : Specification<NotificationType>
		{
			public ByLevel(int level)
			{
				Query.Where(x => x.PriorityLevel == level);
			}
		}
	}
}
