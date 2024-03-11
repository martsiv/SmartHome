using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
	public class TelegramChatEntity
	{
        public int Id { get; set; }
        public long ChatId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }
		public virtual ICollection<Subscription> Subscriptions { get; set; } = new HashSet<Subscription>();
	}
}
