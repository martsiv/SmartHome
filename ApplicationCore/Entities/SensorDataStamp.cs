using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
	public class SensorDataStamp
	{
        public int Id { get; set; }
        public int SensorId { get; set; }
        public Sensor? Sensor { get; set; }
        public DateTime Date { get; set; }
        public ICollection<SensorDataIndicator> SensorDataIndicators { get; set; } = new HashSet<SensorDataIndicator>();
    }
}
