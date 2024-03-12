using ApplicationCore.Entities;
using Ardalis.Specification;

namespace ApplicationCore.Specifications
{
	public static class NotificationSpecs
	{
		public class LastBySensor : Specification<Notification>
		{
			public LastBySensor(int sensorId)
			{
				Query.Where(x => x.SensorId == sensorId).OrderByDescending(x => x.Date);
			}
		}
	}
}
