using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
	public class NewNotificationModel
	{
		public string Name { get; set; }
		public string SensorMacAddress { get; set; }
		public decimal Data { get; set; }
	}
}
