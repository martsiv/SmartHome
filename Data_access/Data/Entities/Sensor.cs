using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Data.Entities
{
    internal class Sensor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SensorTypeId { get; set; }
        public SensorType? SensorType { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        public int? StateId { get; set; }
        public State? State { get; set; }
        public ICollection<ControllsHystory> ControllsHystories { get; set; } = new HashSet<ControllsHystory>();
        public ICollection<NotificationHistory> NotificationHistories { get; set; } = new HashSet<NotificationHistory>();
    }
}
