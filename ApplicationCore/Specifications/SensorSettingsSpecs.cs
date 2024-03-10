using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
