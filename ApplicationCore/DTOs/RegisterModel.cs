using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
	public class RegisterModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string? PhoneNumber { get; set; }
		public string TelegramId { get; set; }
		public string TelegramLogin { get; set; }
	}
}
