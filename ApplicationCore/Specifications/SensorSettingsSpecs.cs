using ApplicationCore.Entities;
using Ardalis.Specification;

namespace ApplicationCore.Specifications
{
	public static class SensorSettingsSpecs
	{
		public class BySensorId : Specification<SensorSetting>
		{
			public BySensorId(int sensorId)
			{
				Query.Where(x => x.SensorId == sensorId);
			}
		}
	}
}
