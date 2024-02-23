using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Data.Entities
{
    internal class User : IdentityUser
    {
        public string TelegramId { get; set; }
        public string TelegramLogin { get; set; }
        public ICollection<ControllsHystory> ControllsHystories { get; set; } = new HashSet<ControllsHystory>();
    }
}
