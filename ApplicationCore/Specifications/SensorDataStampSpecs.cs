using ApplicationCore.Entities;
using Ardalis.Specification;

namespace ApplicationCore.Specifications
{
	public static class SensorDataStampSpecs
	{
		public class ByDate : Specification<SensorDataStamp>
		{
			public ByDate(DateTime dateTime)
			{
				Query.Where(x => x.Date.Date == dateTime.Date).OrderByDescending(x => x.Date);
			}
		}
		public class BySensor : Specification<SensorDataStamp>
		{
			public BySensor(int sensorId)
			{
				Query.Where(x => x.SensorId == sensorId);
			}
		}
	}
}
