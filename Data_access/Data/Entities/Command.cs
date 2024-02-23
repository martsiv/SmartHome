using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Data.Entities
{
    internal class Command
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ControllsHystory> ControllsHystories { get; set; } = new HashSet<ControllsHystory>();
    }
}
