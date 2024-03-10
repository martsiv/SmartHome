using ApplicationCore.Entities;
using Ardalis.Specification;
using System.Security.Cryptography;

namespace ApplicationCore.Specifications
{
	public static class SensorSpecs
	{
		public class ByMac : Specification<Sensor>
		{
			public ByMac(string mac)
			{
				Query.Where(x => x.MacAddress == mac);
			}
		}
		public class ByIp : Specification<Sensor>
		{
			public ByIp(string ipAddress)
			{
				Query.Where(x => x.SensorIP == ipAddress);
			}
		}
	}
}
