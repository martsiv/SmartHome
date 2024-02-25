using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
	public class NotificationDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int SensorId { get; set; }
        public DateTime Date { get; set; }
        public decimal Data { get; set; }
    }
}
