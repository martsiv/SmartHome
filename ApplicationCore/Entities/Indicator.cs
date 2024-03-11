using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
	public class Indicator
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SensorDataIndicator> SensorDataIndicators { get; set; } = new HashSet<SensorDataIndicator>();
    }
}
