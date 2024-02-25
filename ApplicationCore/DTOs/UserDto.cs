using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
	public class UserDto
	{
        public string Id { get; set; }
		public string Name { get; set; }
        public int TelegramId { get; set; }
		public string TelegramName { get; set;}
    }
}
