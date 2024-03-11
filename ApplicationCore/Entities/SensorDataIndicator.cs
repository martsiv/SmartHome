using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
	public class SensorDataIndicator
	{
        public int Id { get; set; }
        public int IndicatorId { get; set; }
        public Indicator? Indicator { get; set; }
        public int SensorDataId { get; set; }
        public SensorDataStamp? SensorData { get; set; }
        public decimal Value { get; set; }
    }
}
