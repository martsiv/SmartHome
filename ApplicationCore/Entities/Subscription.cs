using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
	public class Subscription
	{
        public int Id { get; set; }
        public int TelegramChatId { get; set; }
        public TelegramChatEntity? TelegramChat { get; set; }
        public int NotificationId { get; set; }
        public Notification? Notification { get; set; }
    }
}
