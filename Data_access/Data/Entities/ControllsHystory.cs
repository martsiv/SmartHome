using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Data.Entities
{
    internal class ControllsHystory
    {
        public int Id { get; set; }
        public int SensorId { get; set; }
        public Sensor? Sensor { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
        public DateTime Timestamp { get; set; }
        public int CommandId { get; set; }
        public Command? Command { get; set; }
        public bool IsSuccess { get; set; }
    }
}
