using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Data.Entities
{
    internal class ValueName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<NotificationHistory> NotificationHistories { get; set; } = new HashSet<NotificationHistory>();

    }
}
