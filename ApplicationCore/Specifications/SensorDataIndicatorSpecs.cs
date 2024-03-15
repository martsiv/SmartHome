using ApplicationCore.Entities;
using Ardalis.Specification;

namespace ApplicationCore.Specifications
{
	public static class SensorDataIndicatorSpecs
	{
		public class ByDataStampId : Specification<SensorDataIndicator>
		{
			public ByDataStampId(int dataStampId)
			{
				Query.Where(x => x.SensorDataId == dataStampId).Include(x => x.Indicator);
			}
		}
	}
}
