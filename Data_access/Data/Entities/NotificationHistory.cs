using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Data.Entities
{
    internal class NotificationHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ValueNameId { get; set; }
        public ValueName? ValueName { get; set; }
        public int SensorId { get; set; }
        public Sensor? Sensor { get; set; }
    }
}
